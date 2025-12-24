using DocumentFormat.OpenXml.Spreadsheet;
using Serenity.ComponentModel;
using Serenity.Web;
using System.Collections.Generic;

namespace Indotalent.Web.Modules.Reminder.PlanSetting
{
    [LookupScript("Frequency.FrequencyLookup")]
    public class FrequencyLookup : LookupScript
    {
        public FrequencyLookup()
        {
            IdField = "Id";
            TextField = "Text";
        }

        protected override IEnumerable<object> GetItems()
        {
            return new List<object>
            {
                new { Id = "Monthly", Text = "Monthly" },
                new { Id = "Quarterly", Text = "Quarterly" },
                new { Id = "Yearly", Text = "Yearly" }
            };
        }
    }
}

