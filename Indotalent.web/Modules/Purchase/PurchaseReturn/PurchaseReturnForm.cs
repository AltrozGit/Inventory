using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Purchase.Forms
{
    [FormScript("Purchase.PurchaseReturn")]
    [BasedOnRow(typeof(PurchaseReturnRow), CheckNames = true)]
    public class PurchaseReturnForm
    {
        [Tab("General")]
        [Category("Purchase Return")]
        [HalfWidth]
        public String Number { get; set; }
        [HalfWidth]
        [DefaultValue("now")]
        public DateTime ReturnDate { get; set; }
        [HalfWidth]
        [TextAreaEditor(Rows = 3)]
        public String Description { get; set; }
        [HalfWidth]
        public Int32 PurchaseReceiptId { get; set; }

        [Category("Outbound")]
        public Int32 ProjectId { get; set; }
        public Int32 WarehouseId { get; set; }
        public Int32 LocationId { get; set; }

        [Category("Detail")]
        [PurchaseReturnDetailEditor]
        public List<PurchaseReturnDetailRow> ItemList { get; set; }


        [Category("Summary")]
        public Double TotalQtyReturn { get; set; }
    }
}