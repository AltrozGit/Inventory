using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.General.Forms
{
    [FormScript("General.ActionNotification")]
    [BasedOnRow(typeof(ActionNotificationRow), CheckNames = true)]
    public class ActionNotificationForm
    {
        public Int32 ActionId { get; set; }
        public Int32 TemplateId { get; set; }
        public String EmailRecipient { get; set; }
        public String WhatsappRecipient { get; set; }
       
    }
}