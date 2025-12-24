using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Purchase.Columns
{
    [ColumnsScript("Purchase.PurchaseReceiptDetail")]
    [BasedOnRow(typeof(PurchaseReceiptDetailRow), CheckNames = true)]
    public class PurchaseReceiptDetailColumns
    {
        [EditLink]
        public String ProductName { get; set; }
        [Width(200)]
        public String InternalCode { get; set; }
        [Width(100)]
        public Double QtyRequest { get; set; }
        [Width(100)]
        public Double QtyReceive { get; set; }
        [Width(100)]
        public Double Qty { get; set; }

        //[Width(150)]
        //public Int32 QuanityOfBillCreated { get; set; }
        //[Width(150)]
        //public Boolean IsBillCreate { get; set; }

        [Width(150)]
        public Int32 QuanityOfIssueCreated { get; set; }
        [Width(150)]
        public Boolean IsIssueCreated { get; set; }

    }
}