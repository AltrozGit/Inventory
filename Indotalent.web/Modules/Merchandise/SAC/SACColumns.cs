using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Merchandise.Columns
{
    [ColumnsScript("Merchandise.SAC")]
    [BasedOnRow(typeof(SACRow), CheckNames = true)]
    public class SACColumns
    {
        [Width(200)]
        public String SacCode { get; set; }
        [Width(200)]
        public String SacDescription { get; set; }
        [Width(200)]
        public String SacName { get; set; }
    }
}