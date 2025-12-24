using Serenity;
using Serenity.ComponentModel;
using Serenity.Web;
using System.Collections.Generic;

namespace Indotalent.Web.Modules.Reminder.SmtpConfiguration
{
    [LookupScript("SmtpConfiguration.SmtpHostLookup")]
    public class SmtpHostLookup : LookupScript
    {
        public SmtpHostLookup()
        {
            IdField = "Id";
            TextField = "Text";
        }

        protected override IEnumerable<object> GetItems()
        {
            return new List<object>
            {
                new { Id = "smtp.gmail.com", Text = "Gmail" },
                new { Id = "smtp.office365.com", Text = "Office 365" },
                new { Id = "smtp.mail.yahoo.com", Text = "Yahoo" },
              
            };
        }
    }
}
