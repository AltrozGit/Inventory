using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Inventory.Columns
{
    [ColumnsScript("Inventory.PositiveAdjustment")]
    [BasedOnRow(typeof(PositiveAdjustmentRow), CheckNames = true)]
    public class PositiveAdjustmentColumns
    {
        [EditLink]
        [SortOrder(1, descending: true)]
        [Width(200)]
        public String Number { get; set; }
        [Width(200)]
        public DateTime AdjustmentDate { get; set; }
        [Width(200)]
        public String ProjectName { get; set; }
        [Width(200)]
        public String WarehouseName { get; set; }
        [Width(200)]
        public String LocationName { get; set; }
        [Width(200)]
        public Double TotalQty { get; set; }
        [Width(200)]
        public String TenantName { get; set; }
    }
}