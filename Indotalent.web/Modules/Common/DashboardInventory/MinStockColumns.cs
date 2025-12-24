using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Common.DashboardInventory.Columns
{
    [ColumnsScript("Common.MinStock")]
    [BasedOnRow(typeof(MinStockRow), CheckNames = true)]
    public class MinStockColumns
    {
        [Width(150)]
        public String ProductName { get; set; }
        [Width(100)]
        public String WarehouseName { get; set; }
        [Width(50)]
        public Double Qty { get; set; }
        [Width(70)]
        public Double MinimumQty { get; set; }
        [Width(50)]
        public String Uom { get; set; }

    }
}