using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Merchandise.Forms
{
    [FormScript("Merchandise.Product")]
    [BasedOnRow(typeof(ProductRow), CheckNames = true)]
    public class ProductForm
    {
        [Tab("General")]
        [Category("Product Info")]

        public String Name { get; set; }

        [HalfWidth]
        public Int32 ProductType { get; set; }

        [HalfWidth]
        public Int32 HsnId { get; set; }

      [HalfWidth]
        public Int32 SacId { get; set; }       

        [OneThirdWidth]
        public Int32 UomId { get; set; }

        [OneThirdWidth]
        public String Barcode { get; set; }


        [TextAreaEditor(Rows = 3)]
        public String Description { get; set; }
     
        
        [HalfWidth]
        public Double MinimumQty { get; set; }

        [Category("Product Picture")]
        public String Picture { get; set; }

        [Category("Merchandise Hierarchy")]
       
        [HalfWidth]
        public Int32 BrandId { get; set; }
       
        [HalfWidth]
        public Int32 CategoryId { get; set; }

        [Category("Product Variant")]

        [OneThirdWidth]
        public Int32 SizeId { get; set; }
        
        [OneThirdWidth]
        public Int32 ColourId { get; set; }
        
        [OneThirdWidth]
        public Int32 FlavourId { get; set; }

        [Category("Currency")]
        public string CurrencyName { get; set; }

        [Category("Retail")]
       
        [HalfWidth]
        public Double PurchasePrice { get; set; }
       
        [HalfWidth]
        public Int32 PurchaseTaxId { get; set; }
        
        [HalfWidth]
        public Double SalesPrice { get; set; }
       
        [HalfWidth]
        public Int32 SalesTaxId { get; set; }

        public String InternalCode { get; set; }
    }
}