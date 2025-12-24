using Indotalent.Administration.Entities;
using Indotalent.Projects;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Web;

namespace Indotalent.Web.Modules.Projects.Project
{

    [LookupScript]
    public sealed class ProjectLookup : RowLookupScript<ProjectRow>
    {
        public ProjectLookup(ISqlConnections sqlConnections)
            : base(sqlConnections)
        {
            //IdField = ProjectRow.Fields.Id.PropertyName;
            //Permission = "*";
        }

        //protected override void PrepareQuery(SqlQuery query)
        //{
        //    //base.PrepareQuery(query.OrderBy("Name"));           

        //    query.Select(ProjectRow.Fields.Id);
        //}
    }
}
