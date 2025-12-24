using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Sales.Columns
{
    [ColumnsScript("Sales.SalesDeliveryDetail")]
    [BasedOnRow(typeof(SalesDeliveryDetailRow), CheckNames = true)]
    public class SalesDeliveryDetailColumns
    {
        [EditLink]
        public String ProductName { get; set; }
        public Double QtyDelivered { get; set; }
    }
}