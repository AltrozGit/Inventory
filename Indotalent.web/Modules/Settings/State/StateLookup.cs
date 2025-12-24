using Indotalent.Settings;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Services;
using Serenity.Web;

namespace Indotalent.Web.Modules.Settings.State
{
    [LookupScript]
    public class StateLookup : RowLookupScript<StateRow>
    {
       

        public StateLookup(ISqlConnections sqlConnections)
            : base(sqlConnections)
        {
        }

        protected override void PrepareQuery(SqlQuery query)
        {
            base.PrepareQuery(query);

            //var sr = StateRow.Fields.As("sr");
            //var cr = CountryRow.Fields.As("cr");


            //query
            //    .Select(sr.Name)
            //    .From(sr)
            //    .InnerJoin(cr, cr.Id == sr.CountryId)
            //    .Where(new Criteria(cr.Id) == 1)
            //    .OrderBy(sr.Name)
            //    .Distinct(true);
        }
    }
}
