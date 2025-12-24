using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Serenity.Data.Mapping;
using Indotalent.Web.Common;
using static Indotalent.Web.Common.Enums;


namespace Indotalent.Reminder.Columns
{
    [ColumnsScript("Reminder.BulkEmailSenderStatus")]
    [BasedOnRow(typeof(BulkEmailSenderStatusRow), CheckNames = true)]
    public class BulkEmailSenderStatusColumns
    {
       
       public String BulkEmailSenderTitle { get; set; }
        [Width(200)]
        public String ToEmail { get; set; }
        [Width(200)]
        public String Subject { get; set; }
        [Width(200)]
        [DisplayFormat("yyyy-MM-dd HH:mm:ss")]
        public DateTime SentOn { get; set; }
     
        public Int32 RetryCount { get; set; }
        [Width(150)]
        [QuickSearch]
        public String IsSentDisplay { get; set; }

    }
}