using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Sales.Columns
{
    [ColumnsScript("Sales.SalesDelivery")]
    [BasedOnRow(typeof(SalesDeliveryRow), CheckNames = true)]
    public class SalesDeliveryColumns
    {
        [EditLink]
        [SortOrder(1, descending: true)]
        [Width(200)]
        public String Number { get; set; }
        [Width(200)]
        public DateTime DeliveryDate { get; set; }
        [Width(200)]

        [DisplayName("Quotation")]
        public String SalesOrderNumber { get; set; }
        [Width(200)]
        public Double TotalQtyDelivered { get; set; }   
        [Width(200)]
        public String TenantName { get; set; }
    }
}