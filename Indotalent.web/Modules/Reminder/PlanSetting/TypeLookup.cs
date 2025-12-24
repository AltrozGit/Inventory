using DocumentFormat.OpenXml.Spreadsheet;
using Serenity.ComponentModel;
using Serenity.Web;
using System.Collections.Generic;

namespace Indotalent.Web.Modules.Reminder.PlanSetting
{
    [LookupScript("Type.TypeLookup")]
    public class TypeLookup : LookupScript
    {
        public TypeLookup()
        {
            IdField = "Id";
            TextField = "Text";
        }

        protected override IEnumerable<object> GetItems()
        {
            return new List<object>
            {
                new { Id = "Regular", Text = "Regular (New)" },
                new { Id = "Renewal", Text = "Renewal" },
                new { Id = "Topup", Text = "Topup" }
            };
        }
    }
}

