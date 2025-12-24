using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.WhatsApp.Forms
{
    [FormScript("WhatsApp.WhatsAppTemplate")]
    [BasedOnRow(typeof(WhatsAppTemplateRow), CheckNames = true)]
    public class WhatsAppTemplateForm
    {
        public String Name { get; set; }
        public String PhoneNumber { get; set; }
        public String TemplateName { get; set; }
        public String BroadcastName { get; set; }
        public String Url { get; set; }
        public Boolean IsAttachmentReq { get; set; }
		public Boolean IsSent { get; set; }
		//public Boolean IsActive { get; set; }
        public Int32 TenantId { get; set; }
      
    }
}