using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Purchase.Columns
{
    [ColumnsScript("Purchase.PurchaseReturnDetail")]
    [BasedOnRow(typeof(PurchaseReturnDetailRow), CheckNames = true)]
    public class PurchaseReturnDetailColumns
    {
        [EditLink]
        public String ProductName { get; set; }
        public Double QtyReturn { get; set; }
    }
}