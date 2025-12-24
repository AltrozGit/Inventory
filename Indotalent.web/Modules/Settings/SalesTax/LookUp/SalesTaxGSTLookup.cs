using Indotalent.Settings;
using Serenity.Abstractions;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Web;
using System;
using static Indotalent.Web.Common.Enums;


namespace Indotalent.Web.Modules.Settings.SalesTax.LookUp
{
    [LookupScript]
    public sealed class SalesTaxGSTLookup : RowLookupScript<SalesTaxRow>
    {
        private readonly ISqlConnections _sqlConnections;
        protected IUserRetrieveService UserRetrieveService { get; }
        protected IUserAccessor UserAccessor { get; }
      
        public SalesTaxGSTLookup(ISqlConnections sqlConnections, IUserRetrieveService userRetrieveService, IUserAccessor userAccessor)
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
                    SalesTaxRow.Fields.TaxType == (int)SalesTaxType.GST &&
                    SalesTaxRow.Fields.TenantId == tenantId);
            }

        }
    }
}
