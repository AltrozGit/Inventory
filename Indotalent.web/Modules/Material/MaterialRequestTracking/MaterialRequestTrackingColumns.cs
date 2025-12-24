using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;
using Indotalent.Material;
using Serenity.Data.Mapping;
namespace Indotalent.Material.Columns
{
    [ColumnsScript("Material.MaterialRequestTracking")]
    [BasedOnRow(typeof(MaterialRequestTrackingRow), CheckNames = true)]
    public class MaterialRequestTrackingColumns
    {


        [Width(200)]
        public String Comment { get; set; }
        [Width(200)]
        public DateTime InsertDate { get; set; }

        [Width(200)]
        public String InsertUserDisplayName { get; set; }
     
    }
}