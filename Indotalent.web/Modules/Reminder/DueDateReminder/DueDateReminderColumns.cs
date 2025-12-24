using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Reminder.Columns
{
    [ColumnsScript("Reminder.DueDateReminder")]
    [BasedOnRow(typeof(DueDateReminderRow), CheckNames = true)]
    public class DueDateReminderColumns
    {
       
       
        [EditLink]
        public String RelatedCustomerName { get; set; }
        public String CustomerPhone { get; set; }
        public String ToEmail { get; set; }

        public String TenantEmail { get; set; }
        public String Subject { get; set; }

        [Width(180), SortOrder(1, descending: true)]
        public DateTime ConsentDueDate { get; set; }

        public DateTime Remainder1 { get; set; }
        public DateTime Remainder2 { get; set; }
        public String TemplateName { get; set; }
        public Boolean SendRemainderOnEmail { get; set; }
        public Boolean SendRemainderOnWhatsapp { get; set; }
        public Boolean IsActionComplete { get; set; }
        public Boolean IsEnable { get; set; }    


        public String TenantName { get; set; }
    }
}