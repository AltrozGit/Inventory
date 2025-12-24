using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Reminder.Forms
{
    [FormScript("Reminder.SmtpConfiguration")]
    [BasedOnRow(typeof(SmtpConfigurationRow), CheckNames = true)]
    public class SmtpConfigurationForm
    {
        [HalfWidth]
        [LookupEditor("SmtpConfiguration.SmtpHostLookup")]
        public String Host { get; set; }
        [HalfWidth]
        [LookupEditor("SmtpConfiguration.SmtpPortLookup")]

        public Int32 Port { get; set; }
        [HalfWidth]

        public String FromAddress { get; set; }
        [HalfWidth]

        public String UserName { get; set; }
        [HalfWidth]
        [PasswordEditor]
        public String Password { get; set; }
        [HalfWidth]

        public Boolean EnableSsl { get; set; }
        [HalfWidth]
        public Boolean IsSmtpActive { get; set; }
        [HalfWidth]
       
        public Boolean IsDefault { get; set; }
        [TextAreaEditor(Rows = 3)]
        public String Description { get; set; }
        [TextAreaEditor(Rows = 3)]
        public String Address { get; set; }
        [HalfWidth]

        public String Phone { get; set; }
        [HalfWidth]
        [LookupEditor("SmtpConfiguration.SmtpSourceSystemLookup")]

        public String SourceSystem { get; set; }
    }
}