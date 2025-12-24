using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Inventory.Columns
{
    [ColumnsScript("Inventory.NegativeAdjustmentDetail")]
    [BasedOnRow(typeof(NegativeAdjustmentDetailRow), CheckNames = true)]
    public class NegativeAdjustmentDetailColumns
    {
        [EditLink]
        public String ProductName { get; set; }
        public Double Qty { get; set; }
    }
}