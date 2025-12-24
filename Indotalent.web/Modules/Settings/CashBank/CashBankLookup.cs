using Indotalent.Administration.Entities;
using Indotalent.Projects;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Web;

using Indotalent.Administration.Lookups;
using Indotalent.Settings;

namespace Indotalent.Web.Modules.Settings.CashBank
{

    [LookupScript]
    public sealed class CashBankLookup : RowLookupScript<CashBankRow>
    {
        public CashBankLookup(ISqlConnections sqlConnections)
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
