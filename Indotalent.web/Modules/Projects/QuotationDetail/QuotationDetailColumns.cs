using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Projects.Columns
{
    [ColumnsScript("Projects.QuotationDetail")]
    [BasedOnRow(typeof(QuotationDetailRow), CheckNames = true)]
    public class QuotationDetailColumns
    {
     
      
       
        [EditLink]
        public String ProductName { get; set; }

        [Width(200)]
        public String InternalCode { get; set; }
        public Double Price { get; set; }
        public Double Qty { get; set; }
        public Double SubTotal { get; set; }
        public Double Discount { get; set; }
        public Double BeforeTax { get; set; }
        public Double TaxPercentage { get; set; }
        public Double TaxAmount { get; set; }
        public Double Total { get; set; }
    }
}