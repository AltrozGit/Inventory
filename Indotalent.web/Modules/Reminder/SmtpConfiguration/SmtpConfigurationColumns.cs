using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Reminder.Columns
{
    [ColumnsScript("Reminder.SmtpConfiguration")]
    [BasedOnRow(typeof(SmtpConfigurationRow), CheckNames = true)]
    public class SmtpConfigurationColumns
    {

        [EditLink]
        [Width(150)]
        public String Host { get; set; }
        [Width(150)]

        public Int32 Port { get; set; }
        [Width(150)]

        public String FromAddress { get; set; }
        [Width(150)]

        public String UserName { get; set; }
        [Width(150)]

        public Boolean EnableSsl { get; set; }
       
        [Width(150)]

        public String TenantName { get; set; }
        [Width(150)]

        public String SourceSystem { get; set; }
        [Width(150)]

        public Boolean IsSmtpActive { get; set; }
       
    }
}