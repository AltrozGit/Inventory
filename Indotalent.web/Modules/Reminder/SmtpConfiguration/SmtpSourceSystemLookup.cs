using Serenity;
using Serenity.ComponentModel;
using Serenity.Web;
using System.Collections.Generic;

namespace Indotalent.Web.Modules.Reminder.SmtpConfiguration
{
    [LookupScript("SmtpConfiguration.SmtpSourceSystemLookup")]
    public class SmtpSourceSystemLookup : LookupScript
    {
        public SmtpSourceSystemLookup()
        {
            IdField = "Id";
            TextField = "Text";
        }

        protected override IEnumerable<object> GetItems()
        {
            return new List<object>
            {
                new { Id = "Inventory", Text = "Inventory" },
                new { Id = "HRMS", Text = "HRMS" },
                new { Id = "Notification", Text = "Notification" }
            };
        }
    }
}
