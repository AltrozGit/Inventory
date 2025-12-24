using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Purchase.Forms
{
    [FormScript("Purchase.PurchaseReceiptDetail")]
    [BasedOnRow(typeof(PurchaseReceiptDetailRow), CheckNames = true)]
    public class PurchaseReceiptDetailForm
    {
        [Tab("General")]
        [Category("Main")]
        public Int32 ProductId { get; set; }
        public Double QtyRequest { get; set; }
        public Double Qty { get; set; }
        public String InternalCode { get; set; }

        [Hidden]
        [HalfWidth]
        public Int32? PurchaseOrderId { get; set; }
        [HalfWidth]
        public Int32? QuanityofPRCreated { get; set; }

        [Category("Receive")]
        [HalfWidth]
        public Double QtyReceive { get; set; }

        [HalfWidth]
        public Decimal PendingReceivableQty { get; set; }

        [Hidden]
        public Int32 QuanityOfBillCreated { get; set; }
        [Hidden]
        public Boolean IsBillCreate { get; set; }

        [Hidden]
        public Int32 QuanityOfIssueCreated { get; set; }
        [Hidden]
        public Boolean IsIssueCreated { get; set; }
    }
}