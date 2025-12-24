using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Reminder.Columns
{
    [ColumnsScript("Reminder.WhatsApp")]
    [BasedOnRow(typeof(WhatsAppRow), CheckNames = true)]
    public class WhatsAppColumns
    {
        [EditLink]
        public String TemplateName { get; set; }
        public String BroadcastName { get; set; }
        public String Url { get; set; }
        public Boolean IsActive { get; set; }
        public String TenantName { get; set; }
    }
}