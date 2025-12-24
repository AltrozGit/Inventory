using Indotalent.Settings;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Web;
using static Indotalent.Web.Common.Enums;
using Indotalent.Administration;
using Serenity.Abstractions;
using System;

namespace Indotalent.Web.Modules.Settings.PurchaseTax.LookUp
{
    [LookupScript]
    public sealed class PurchaseTaxTCSLookup : RowLookupScript<PurchaseTaxRow>
    {
        private readonly ISqlConnections _sqlConnections;
        private readonly IUserRetrieveService _userRetrieveService;
        private readonly IUserAccessor _userAccessor;

        public PurchaseTaxTCSLookup(ISqlConnections sqlConnections, IUserRetrieveService userRetrieveService, IUserAccessor userAccessor)
            : base(sqlConnections)
        {
            _userRetrieveService = userRetrieveService ?? throw new ArgumentNullException(nameof(userRetrieveService));
            _userAccessor = userAccessor ?? throw new ArgumentNullException(nameof(userAccessor));
            _sqlConnections = sqlConnections;
        }

        protected override void PrepareQuery(SqlQuery query)
        {
            base.PrepareQuery(query);

            var username = _userAccessor.User?.Identity?.Name;
            var user = _userRetrieveService.ByUsername(username) as UserDefinition;

            if (user != null)
            {
                var tenantId = user.TenantId;
                query.Where(
                    PurchaseTaxRow.Fields.TaxType == (int)PurchaseTaxType.TCS &&
                    PurchaseTaxRow.Fields.TenantId == tenantId);
            }
           
        }
    }
}
