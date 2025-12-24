using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Settings.Forms
{
    [FormScript("Settings.SalesTax")]
    [BasedOnRow(typeof(SalesTaxRow), CheckNames = true)]
    public class SalesTaxForm
    {
        [Tab("General")]
        [Category("Sales Tax Info")]

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