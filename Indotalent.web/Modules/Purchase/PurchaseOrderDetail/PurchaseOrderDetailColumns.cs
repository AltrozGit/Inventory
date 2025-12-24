using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;
using Serenity.Data.Mapping;
using System.ComponentModel.DataAnnotations;

namespace Indotalent.Purchase.Columns
{
    [ColumnsScript("Purchase.PurchaseOrderDetail")]
    [BasedOnRow(typeof(PurchaseOrderDetailRow), CheckNames = true)]
    public class PurchaseOrderDetailColumns
    {
        //// Add the checkbox column
        //[Width(30), Sortable(false), HeaderCssClass("align-center"), CssClass("align-center")]
        //public Boolean Select { get; set; }

        [EditLink]
		public String ProductName { get; set; }

        [Width(200)]
        public String InternalCode { get; set; }

        [Width(100)]
        public Double QtyRequest { get; set; }

		public Double Price { get; set; }
        public Double Qty { get; set; }
        public Double SubTotal { get; set; }
        public Double Discount { get; set; }

        [Width(150)]
        public Int32 QuanityOfPRCreated { get; set; }
        [Width(150)]
        public Boolean IsPRCreate { get; set; }

        [Width(150)]
        public Int32 QuanityOfBillCreated { get; set; }
        [Width(150)]
        public Boolean IsBillCreated { get; set; }


        [Visible(false)]
        public Double BeforeTax { get; set; }
        public Double TaxPercentage { get; set; }

        [Visible(false)]
        public Double IGST { get; set; }

        [Visible(false)]
        public Double SGST { get; set; }
        [Visible(false)]
        public Double CGST { get; set; }

        [Visible(false)]
        public Double IGSTAmount { get; set; }

        [Visible(false)]
        public Double SGSTAmount { get; set; }

        [Visible(false)]
        public Double CGSTAmount { get; set; }

        public Double TaxAmount { get; set; }
        public Double Total { get; set; }

        [Visible(false)]
        public Double AvailableStock { get; set; }

         
      
    }
}