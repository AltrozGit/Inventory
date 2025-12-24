using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Settings.Forms
{
    [FormScript("Settings.PurchaseTax")]
    [BasedOnRow(typeof(PurchaseTaxRow), CheckNames = true)]
    public class PurchaseTaxForm
    {
        [Tab("General")]
        [Category("Purchase Tax Info")]

        public Int32 TaxType { get; set; }

        public String Name { get; set; }
        [TextAreaEditor(Rows = 3)]
        public String Description { get; set; }
        [Category("Rate")]
        public Double TaxRatePercentage { get; set; }



        [HalfWidth]
        public Double SGST { get; set; }

        [HalfWidth]
        public Double CGST { get; set; }

        public Double IGST { get; set; }



    }
}