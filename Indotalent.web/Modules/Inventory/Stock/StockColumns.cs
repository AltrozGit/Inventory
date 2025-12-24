using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Inventory.Columns
{
    [ColumnsScript("Inventory.Stock")]
    [BasedOnRow(typeof(StockRow), CheckNames = true)]
    public class StockColumns
    {

        public String ProductName { get; set; }
        public String ProjectName { get; set; }
        public String WarehouseName { get; set; }
       
        public Double Qty { get; set; }
        [Width(150)]
        public String InternalCode { get; set; }
        public String Barcode { get; set; }
        public String Uom { get; set; }
        [Width(150)]
        //public Double TotalPrice { get; set; }

        public Double TotalPrice { get; set; }
    }
}