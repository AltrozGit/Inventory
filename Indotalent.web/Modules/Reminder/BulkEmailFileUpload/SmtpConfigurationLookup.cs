using Indotalent.Reminder;
using Microsoft.AspNetCore.Http;
using Serenity;
using Serenity.Abstractions;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Services;
using Serenity.Web;
using System;

namespace Indotalent.Reminder
{
    [LookupScript("Reminder.SmtpConfigurationLookup")]
    public class SmtpConfigurationLookup : RowLookupScript<SmtpConfigurationRow>
    {
        private readonly IUserRetrieveService _userRetrieveService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SmtpConfigurationLookup(ISqlConnections connections, IUserRetrieveService userRetrieveService, IHttpContextAccessor httpContextAccessor)
            : base(connections)
        {
            IdField = SmtpConfigurationRow.Fields.FromAddress.PropertyName;
            TextField = SmtpConfigurationRow.Fields.FromAddress.PropertyName;
            _userRetrieveService = userRetrieveService;
            _httpContextAccessor = httpContextAccessor;
        }

        // Method to get the current user's TenantId
        private int? GetCurrentTenantId()
        {
            var username = _httpContextAccessor.HttpContext?.User?.Identity?.Name;
            if (string.IsNullOrEmpty(username))
                return null;

            var user = _userRetrieveService.ByUsername(username) as UserDefinition;
            var tenantId = user?.TenantId;
            Console.WriteLine($"Current Tenant ID: {tenantId}"); // Logging tenant ID
            return tenantId;
        }

        protected override void PrepareQuery(SqlQuery query)
        {
            base.PrepareQuery(query);

            var fld = SmtpConfigurationRow.Fields;
            query.Select(fld.FromAddress,fld.IsDefault)
                 .Where(fld.IsSmtpActive == 1); // Include only active SMTP configurations

            var tenantId = GetCurrentTenantId();
            if (tenantId.HasValue)
            {
                query.Where(fld.TenantId == tenantId.Value); // Apply filtering based on TenantId
            }
        }
    }
}
