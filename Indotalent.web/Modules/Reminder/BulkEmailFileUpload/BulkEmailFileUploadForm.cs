using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;
using Microsoft.Office.Interop.Excel;


namespace Indotalent.Reminder.Forms
{
    [FormScript("Reminder.BulkEmailFileUpload")]
    [BasedOnRow(typeof(BulkEmailFileUploadRow), CheckNames = true)]
    public class BulkEmailFileUploadForm
    {

        [LookupEditor("Reminder.SmtpConfigurationLookup")]

        [HalfWidth]
        public String FromAddress { get; set; }
        [HalfWidth]
        [DefaultValue("now")]


        [DateTimeEditor]
        public DateTime? ScheduledDate { get; set; }
       

        public String FilePath { get; set; }
        [MultipleFileUploadEditor(FilenameFormat = "Emails/~")]
        public String UploadAttachments { get; set; }
        public String Title { get; set; }
                

        [TextAreaEditor(Rows = 3)]
        public String Description { get; set; }


    }
}