using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Bills.Forms
{
    [FormScript("Bills.BillDetail")]
    [BasedOnRow(typeof(BillDetailRow), CheckNames = true)]
    public class BillDetailForm
    {
        [Tab("General")]
        [Category("Main")]
        public Int32 ProductId { get; set; }
        public String InternalCode { get; set; }

        [HalfWidth]
        public Double Price { get; set; }
        [HalfWidth]
        public Double Qty { get; set; }
        [HalfWidth]
        public Double Discount { get; set; }
       
        [HalfWidth]
        [Hidden]
        public Int32? PurchaseOrderId { get; set; }
        [HalfWidth]
        public Int32? QuanityofBillCreated { get; set; }

        [Category("TaxDetails")]

        [HalfWidth]
        public Double TaxPercentage { get; set; }
        [Hidden]
         public bool IsBillPaymentGenerated { get; set; }
 
        [HalfWidth]
        public Double IGST { get; set; }

        [HalfWidth]
        public Double IGSTAmount { get; set; }

        [HalfWidth]
        public Double SGST { get; set; }

        [HalfWidth]
        public Double SGSTAmount { get; set; }


        [HalfWidth]
        public Double CGST { get; set; }

        [HalfWidth]
        public Double CGSTAmount { get; set; }

        [Category("Summary")]
        public Double SubTotal { get; set; }
        public Double BeforeTax { get; set; }
        public Double TaxAmount { get; set; }
        public Double Total { get; set; }
    }
}