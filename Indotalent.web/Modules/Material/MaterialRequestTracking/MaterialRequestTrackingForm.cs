using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Material.Forms
{
    [FormScript("Material.MaterialRequestTracking")]
    [BasedOnRow(typeof(MaterialRequestTrackingRow), CheckNames = true)]
    public class MaterialRequestTrackingForm
    {
       
        [TextAreaEditor(Rows = 3)]
        
        public String Comment { get; set; }
      
    }
}