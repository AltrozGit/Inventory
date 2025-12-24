using Indotalent.Administration.Entities;
using Indotalent.Projects;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Web;

using Indotalent.Administration.Lookups;
using Indotalent.Settings;
using Indotalent.Merchandise;

namespace Indotalent.Web.Modules.Merchandise.Category
{ 

    [LookupScript]
    public sealed class CategoryLookup : RowLookupScript<CategoryRow>
    {
        public CategoryLookup(ISqlConnections sqlConnections)
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
