using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;
using Indotalent.Material;

namespace Indotalent.Material.Columns
{
    [ColumnsScript("Material.StatusMaster")]
    [BasedOnRow(typeof(StatusMasterRow), CheckNames = true)]
    public class StatusMasterColumns
    {
        
        [EditLink]
        public String MaterialRequestStatusName { get; set; }
        public String MaterialRequestStatusDescription { get; set; }
        
    }
}