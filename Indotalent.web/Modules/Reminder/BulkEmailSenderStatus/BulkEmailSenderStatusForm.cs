using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Reminder.Forms
{
    [FormScript("Reminder.BulkEmailSenderStatus")]
    [BasedOnRow(typeof(BulkEmailSenderStatusRow), CheckNames = true)]
    public class BulkEmailSenderStatusForm
    {
        public String ToEmail { get; set; }
        public String Subject { get; set; }
        public String Body { get; set; }
        public String Attachment { get; set; }
        public Boolean IsSent { get; set; }
        public DateTime SentOn { get; set; }
        public Int32 RetryCount { get; set; }
        public DateTime InsertDate { get; set; }
        public Int32 TenantId { get; set; }
        public Int32 BulkEmailSenderId { get; set; }
    }
}