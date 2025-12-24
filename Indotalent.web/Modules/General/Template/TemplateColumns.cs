using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.General.Columns
{
    [ColumnsScript("General.Template")]
    [BasedOnRow(typeof(TemplateRow), CheckNames = true)]
    public class TemplateColumns
    {
        [EditLink]
        [Width (150)]
        public String TemplateName { get; set; }
        
        [EditLink]
        [Width (1000)]
        public String Body { get; set; }

        [EditLink]
        [Width (150)]
        public String Parameter { get; set; }
        
    }
}