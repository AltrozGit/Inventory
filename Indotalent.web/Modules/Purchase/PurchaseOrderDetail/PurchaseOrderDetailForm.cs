using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Purchase.Forms
{
    [FormScript("Purchase.PurchaseOrderDetail")]
    [BasedOnRow(typeof(PurchaseOrderDetailRow), CheckNames = true)]
    public class PurchaseOrderDetailForm
    {
        [Tab("General")]
        [Category("Main")]
		//public Boolean IsSelected { get; set; }
		public Int32 ProductId { get; set; }
        public Double AvailableStock { get; set; }

        public String InternalCode { get; set; }

        //[TextAreaEditor(Rows = 3)]
        //public String Description { get; set; }
        [Category("Quantity Requested")]
        [HalfWidth]
        public Double QtyRequest { get; set; }
        [HalfWidth]
        public Int32? QuanityofPOCreated { get; set; }
        [Hidden]
        [HalfWidth]
        public Int32? MaterialRequestId { get; set; }
      
        [HalfWidth]
        public Double Price { get; set; }
        [HalfWidth]
        public Double Qty { get; set; }
        [HalfWidth]
        [DefaultValue(0.00)]
        public Double Discount { get; set; }

        [Hidden]
        public Int32 QuanityOfPRCreated { get; set; }
        [Hidden]
        public Boolean IsPRCreate { get; set; }


        [Hidden]
        public Int32 QuanityOfBillCreated { get; set; }
        [Hidden]
        public Boolean IsBillCreated { get; set; }


        [Category("TaxDetails")]

        [HalfWidth]
        public Double TaxPercentage { get; set; }

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