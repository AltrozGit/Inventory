using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.General.Forms
{
    [FormScript("General.Template")]
    [BasedOnRow(typeof(TemplateRow), CheckNames = true)]
    public class TemplateForm
    {
        public String TemplateName { get; set; }

        [TextAreaEditor(Rows =10)]
        public String Body { get; set; }
        public String Parameter { get; set; }
        
    }
}