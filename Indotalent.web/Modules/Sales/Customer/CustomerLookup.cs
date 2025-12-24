using Indotalent.Administration.Entities;
using Indotalent.Projects;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Web;

using Indotalent.Administration.Lookups;
using Indotalent.Sales;
namespace Indotalent.Web.Modules.Sales.Customer
{

    [LookupScript]
    public sealed class CustomerLookup : RowLookupScript<CustomerRow>
    {
        public CustomerLookup(ISqlConnections sqlConnections)
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
