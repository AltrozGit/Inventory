using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Inventory.Columns
{
    [ColumnsScript("Inventory.PositiveAdjustmentDetail")]
    [BasedOnRow(typeof(PositiveAdjustmentDetailRow), CheckNames = true)]
    public class PositiveAdjustmentDetailColumns
    {
        [EditLink]
        public String ProductName { get; set; }
        public Double Qty { get; set; }
    }
}