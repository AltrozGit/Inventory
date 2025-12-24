using DocumentFormat.OpenXml.Spreadsheet;
using Indotalent.Merchandise;
using Indotalent.Reminder;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Web;

namespace Indotalent.Web.Modules.Reminder.AddBalance
{
    [LookupScript("PlanSetting:PlanSettingLookup")]
    public class PlanSettingLookup : RowLookupScript<PlanSettingRow>
    {
        public PlanSettingLookup(ISqlConnections connections)
           : base(connections)
        {
            IdField = PlanSettingRow.Fields.Id.PropertyName;
            TextField = PlanSettingRow.Fields.PlanName.PropertyName;
        }

        protected override void PrepareQuery(SqlQuery query)
        {
            base.PrepareQuery(query);

            var fld = PlanSettingRow.Fields;
            query.Select(fld.Id, fld.PlanName,fld.ProductId,fld.ProductName, fld.Cost, fld.Units, fld.Frequency, fld.Type)
                 .Where(fld.IsActive == 1);

            if (LookupParams.TryGetValue("ProductId", out var prdIdObj) &&
                int.TryParse(prdIdObj?.ToString(), out int prdId))
            {
                query.Where(fld.ProductId == prdId);
            }
        }
    }
}


