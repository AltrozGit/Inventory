using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Inventory.Columns
{
    [ColumnsScript("Inventory.TransferOrder")]
    [BasedOnRow(typeof(TransferOrderRow), CheckNames = true)]
    public class TransferOrderColumns
    {
        [EditLink]
        [SortOrder(1, descending: true)]
        [Width(200)]
        public String Number { get; set; }
        [Width(200)]
        public DateTime TransferDate { get; set; }
        [Width(200)]
        public String ProjectFromName { get; set; }
        [Width(200)]
        public String ProjectToName { get; set; }
        [Width(200)]
        public String FromName { get; set; }
        [Width(200)]
        public String ToName { get; set; }
        [Width(200)]
        public Double TotalQty { get; set; }
        [Width(200)]
        public String TenantName { get; set; }
    }
}