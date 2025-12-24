using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.General.Columns
{
    [ColumnsScript("General.ActionNotification")]
    [BasedOnRow(typeof(ActionNotificationRow), CheckNames = true)]
    public class ActionNotificationColumns
    {
        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        //public Int32 Id { get; set; }

        [EditLink]
        
        public String ActionActionName { get; set; }
        [EditLink]
        public String TemplateTemplateName { get; set; }
        [EditLink]
        public String EmailRecipient { get; set; }
        public String WhatsappRecipient { get; set; }
        
    }
}