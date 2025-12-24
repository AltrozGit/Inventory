using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;
using Indotalent.Inventory;

namespace Indotalent.Purchase.Forms
{
    [FormScript("Purchase.PurchaseReceipt")]
    [BasedOnRow(typeof(PurchaseReceiptRow), CheckNames = true)]
    public class PurchaseReceiptForm
    {
        [Tab("General")]
        [Category("Purchase Receipt")]
        [HalfWidth]
        public String Number { get; set; }
        [HalfWidth]
        [DefaultValue("now")]
        public DateTime ReceiptDate { get; set; }
        [HalfWidth]
        [TextAreaEditor(Rows = 3)]
        public String Description { get; set; }
        [HalfWidth]
        public Int32 PurchaseOrderId { get; set; }
        [HalfWidth]
        public String VendorName { get; set; }
        [HalfWidth]
        public String InvoiceNumber { get; set; }
        [HalfWidth]
        public DateTime? InvoiceDate { get; set; }
        [Hidden]
        public Boolean IsBillCreate { get; set; }

        [Category("External")]
        public String ExternalReferenceNumber { get; set; }

        [Category("Inbound")]
        public Int32 ProjectId { get; set; }

        public Int32 WarehouseId { get; set; }
        public Int32 LocationId { get; set; }


        [Category("Detail")]
        [PurchaseReceiptDetailEditor]
        public List<PurchaseReceiptDetailRow> ItemList { get; set; }


        [Category("Summary")]
        public Double TotalQtyReceive { get; set; }
    }
}