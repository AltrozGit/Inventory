using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Sales.Columns
{
    [ColumnsScript("Sales.SalesReturnDetail")]
    [BasedOnRow(typeof(SalesReturnDetailRow), CheckNames = true)]
    public class SalesReturnDetailColumns
    {
        [EditLink]
        public String ProductName { get; set; }
        public Double QtyReturn { get; set; }
    }
}