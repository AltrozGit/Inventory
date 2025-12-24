using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Inventory.Columns
{
    [ColumnsScript("Inventory.Movement")]
    [BasedOnRow(typeof(MovementRow), CheckNames = true)]
    public class MovementColumns
    {
        [Width(80)]
        public String Period { get; set; }
        [Width(90)]
        public String Module { get; set; }
        [Width(150)]
        public String Number { get; set; }
        [Width(150)]
        public DateTime TransactionDate { get; set; }
        [Width(150)]
        public String ProductName { get; set; }
        [Width(150)]
        public String InternalCode { get; set; }
        [Width(100)]
        public String Barcode { get; set; }
        [Width(100)]
        public String ProjectName { get; set; }
        [Width(150)]
        public String WarehouseName { get; set; }
        [Width(50)]
        public Double Qty { get; set; }
        [Width(50)]
        public String Uom { get; set; }

    }
}