using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;

namespace Indotalent.Reminder.Forms
{
    [FormScript("Reminder.DueDateReminder")]
    [BasedOnRow(typeof(DueDateReminderRow), CheckNames = true)]
    public class DueDateReminderForm
    {

        [Category("WhatsApp Message Details")]
       
        public Boolean SendRemainderOnWhatsapp { get; set; }

        [HalfWidth]
        public Int32 CustomerId { get; set; }
        [HalfWidth]
        public String CustomerPhone { get; set; }
        [HalfWidth]
        public String TenantPhone { get; set; }
        public int WhatsAppId { get; set; }

        [Category("Email Message Details")]
      
        public Boolean SendRemainderOnEmail { get; set; }
        [HalfWidth]
        public String TenantEmail { get; set; }
        [HalfWidth]
        public String ToEmail { get; set; }
        [HalfWidth]
        public String ReminderInCC { get; set; }
       
        [HalfWidth]
        public String Subject { get; set; }
        [TextAreaEditor(Rows = 3)]
        public String MessageBody { get; set; }
        [Category("Due Dates")]

        [DefaultValue("now")]
        public DateTime ConsentDueDate { get; set; }
        [HalfWidth]
        public DateTime? Remainder1 { get; set; }
        [HalfWidth]
        public DateTime? Remainder2 { get; set; }


        [Category("Attachments")]
        public String Attachment { get; set; }

        
       
        [Category("Notification Settings")]
        [HalfWidth]
        public Boolean IsEnable { get; set; }
        [HalfWidth]
        public Boolean IsActionComplete { get; set; }
    }
}
