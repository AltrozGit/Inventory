using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Sales.Columns
{
    [ColumnsScript("Sales.SalesReturn")]
    [BasedOnRow(typeof(SalesReturnRow), CheckNames = true)]
    public class SalesReturnColumns
    {
        [EditLink]
        [SortOrder(1, descending: true)]
        [Width(200)]
        public String Number { get; set; }
        [Width(200)]
        public DateTime ReturnDate { get; set; }
        [Width(200)]
        public String SalesDeliveryNumber { get; set; }
        [Width(200)]
        public Double TotalQtyReturn { get; set; }
        [Width(200)]
        public String TenantName { get; set; }
    }
}