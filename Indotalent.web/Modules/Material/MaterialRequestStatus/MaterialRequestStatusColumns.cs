using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Material.Columns
{
    [ColumnsScript("Material.MaterialRequestStatus")]
    [BasedOnRow(typeof(MaterialRequestStatusRow), CheckNames = true)]
    public class MaterialRequestStatusColumns
    {
        [Width(200)]
        public String MaterialRequestStatusName { get; set; }
      
     
        [Width(200)]
        public DateTime InsertDate { get; set; }

        [Width(200)]
        public String InsertUserDisplayName { get; set; }
    }
}