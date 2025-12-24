using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Material.Columns
{
    [ColumnsScript("Material.MaterialReturnDetail")]
    [BasedOnRow(typeof(MaterialReturnDetailRow), CheckNames = true)]
    public class MaterialReturnDetailColumns
    {
        [EditLink]
        public String ProductName { get; set; }
        public Double QtyReturn { get; set; }
      
    }
}