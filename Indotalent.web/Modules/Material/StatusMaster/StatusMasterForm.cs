using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;


namespace Indotalent.Material.Forms
{
    [FormScript("Material.StatusMaster")]
    [BasedOnRow(typeof(StatusMasterRow), CheckNames = true)]
    public class StatusMasterForm
    {
        [Tab("General")]
        [Category("Status")]
        public String MaterialRequestStatusName { get; set; }
        [TextAreaEditor(Rows = 3)]
        public String MaterialRequestStatusDescription { get; set; }
      
    }
}