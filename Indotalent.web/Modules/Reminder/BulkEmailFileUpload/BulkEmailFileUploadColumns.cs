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
    [ColumnsScript("Reminder.BulkEmailFileUpload")]
    [BasedOnRow(typeof(BulkEmailFileUploadRow), CheckNames = true)]
    public class BulkEmailFileUploadColumns
    {

        [EditLink]
        [Width(300)]
        [DisplayName("View File")]
      public String Title { get; set; }
        [Width(200)]
      
        [DisplayFormat("yyyy-MM-dd HH:mm:ss")]
        [DisplayName("Upload Date")]
        public DateTime InsertDate { get; set; }
        [Width(200)]
        public DateTime ScheduledDate { get; set; }
    }
}