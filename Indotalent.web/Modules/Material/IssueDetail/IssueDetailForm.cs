using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Material.Forms
{
    [FormScript("Material.IssueDetail")]
    [BasedOnRow(typeof(IssueDetailRow), CheckNames = true)]
    public class IssueDetailForm
    {
        [Tab("General")]
        [Category("Product to Issue")]
        public Int32 ProductId { get; set; }

        [HalfWidth]
        public String InternalCode { get; set; }
        public Double? PurchasePrice { get; set; }

        public Double AvailableStock { get; set; }

        [HalfWidth]
        public Int32? QuanityOfIssueCreated { get; set; }

        [Hidden]
        public Int32 PurchaseReceiptId { get; set; }

        [Category("Quantity Requested")]
        public Double QtyRequest { get; set; }
        //public Double Qty { get; set; }

        public Int32 UomId { get; set; }
        public Double? PurchasedQty { get; set; }
        [Category("Quantity Issue")]
        [HalfWidth]
        public Double QtyIssue { get; set; }

        [HalfWidth]
        public Double SubTotal { get; set; }
    }
}
