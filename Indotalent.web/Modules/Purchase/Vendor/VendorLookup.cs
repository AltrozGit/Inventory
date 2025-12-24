using Indotalent.Administration.Entities;
using Indotalent.Projects;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Web;
using Indotalent.Administration.Lookups;
using Indotalent.Purchase;
namespace Indotalent.Web.Modules.Purchase.Vendor
{

    [LookupScript]
    public sealed class VendorLookup : RowLookupScript<VendorRow>
    {
        public VendorLookup(ISqlConnections sqlConnections)
            : base(sqlConnections)
        {
        //    IdField = ProjectRow.Fields.Id.PropertyName;
        //    Permission = "*";
        }

        //protected override void PrepareQuery(SqlQuery query)
        //{
        //    base.PrepareQuery(query.OrderBy("Name"));           

        //    query.Select(ProjectRow.Fields.Id);
        //}
    }
}
