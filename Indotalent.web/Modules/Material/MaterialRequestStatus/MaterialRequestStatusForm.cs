using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Material.Forms
{
    [FormScript("Material.MaterialRequestStatus")]
    [BasedOnRow(typeof(MaterialRequestStatusRow), CheckNames = true)]
    public class MaterialRequestStatusForm
    {
       
        public Int32 StatustId { get; set; }
        [TextAreaEditor(Rows = 3)]
        public String Description { get; set; }
       
    }
}