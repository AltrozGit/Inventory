using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Sales.Columns
{
    [ColumnsScript("Sales.InvoiceDetail")]
    [BasedOnRow(typeof(InvoiceDetailRow), CheckNames = true)]
    public class InvoiceDetailColumns
    {
        [EditLink]
        public String ProductName { get; set; }

        [Width(200)]
        public String InternalCode { get; set; }
        public Double Price { get; set; }
        public Double Qty { get; set; }
        public Double SubTotal { get; set; }
        public Double Discount { get; set; }



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
    }
}