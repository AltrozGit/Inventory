using Indotalent.Settings;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Web;
using static Indotalent.Web.Common.Enums;
using Indotalent.Administration;
using Serenity.Abstractions;
using Serenity.Services;
using System;

namespace Indotalent.Web.Modules.Settings.PurchaseTax.LookUp
{
    [LookupScript]
    public sealed class PurchaseTaxGstLookup : RowLookupScript<PurchaseTaxRow>
    {
        private readonly ISqlConnections _sqlConnections;
        protected IUserRetrieveService UserRetrieveService { get; }
        protected IUserAccessor UserAccessor { get; }

        public PurchaseTaxGstLookup(ISqlConnections sqlConnections, IUserRetrieveService userRetrieveService, IUserAccessor userAccessor)
            : base(sqlConnections)
        {
            UserRetrieveService = userRetrieveService ?? throw new ArgumentNullException(nameof(userRetrieveService));
            UserAccessor = userAccessor ?? throw new ArgumentNullException(nameof(userAccessor));
           _sqlConnections = sqlConnections;
        }

        protected override void PrepareQuery(SqlQuery query)
        {
            base.PrepareQuery(query);

            var username = UserAccessor.User?.Identity?.Name;
            var user = UserRetrieveService.ByUsername(username) as UserDefinition;

            if (user != null)
            {
                var tenantId = user.TenantId;

                query.Where(
                    PurchaseTaxRow.Fields.TaxType == (int)PurchaseTaxType.GST &&
                    PurchaseTaxRow.Fields.TenantId == tenantId);
            }
            
        }
    }
}