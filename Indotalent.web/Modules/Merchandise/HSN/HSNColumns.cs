using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Merchandise.Columns
{
    [ColumnsScript("Merchandise.HSN")]
    [BasedOnRow(typeof(HSNRow), CheckNames = true)]
    public class HSNColumns
    {
        [Width(200)]
        public String HsnCode { get; set; }
        [Width(200)]
        public String HsnDescription { get; set; }
        [Width(200)]
        public String HsnName { get; set; }
    }
}