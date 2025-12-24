using Serenity;
using Serenity.ComponentModel;
using Serenity.Web;
using System.Collections.Generic;

namespace Indotalent.Web.Modules.Reminder.SmtpConfiguration
{
    [LookupScript("SmtpConfiguration.SmtpPortLookup")]
    public class SmtpPortLookup : LookupScript
    {
        public SmtpPortLookup()
        {
            IdField = "Id";
            TextField = "Text";
        }

        protected override IEnumerable<object> GetItems()
        {
            return new List<object>
            {
                new { Id = "25", Text = "Port 25 (Non-SSL)" },
                new { Id = "465", Text = "Port 465 (SSL)" },
                new { Id = "587", Text = "Port 587 (TLS)" }
            };
        }
    }
}
