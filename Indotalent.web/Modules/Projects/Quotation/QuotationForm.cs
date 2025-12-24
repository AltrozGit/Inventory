using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;



namespace Indotalent.Projects.Forms
{
    [FormScript("Projects.Quotation")]
    [BasedOnRow(typeof(QuotationRow), CheckNames = true)]
    public class QuotationForm
    {
        [Tab("General")]
        [Category("Quotation Info")]
        [HalfWidth]
        public String Number { get; set; }
        [HalfWidth]
        [DefaultValue("now")]
        public DateTime QuotationDate { get; set; }
        [HalfWidth]
        [TextAreaEditor(Rows = 3)]
        public String Description { get; set; }
        [HalfWidth]
        public Int32 ProjectId { get; set; }

        [HalfWidth]
        public Int32 CustomerId { get; set; }

        [HalfWidth]
        public String TenantState { get; set; }

        [Category("External")]
        public String ExternalReferenceNumber { get; set; }


        [Category("Detail")]
        [QuotationDetailEditor]
    public List<QuotationDetailRow> ItemList { get; set; }

        [Category("Currency")]
        public String CurrencyName { get; set; }

        


        [Category("Summary")]
        public Double SubTotal { get; set; }
        public Double Discount { get; set; }
        public Double BeforeTax { get; set; }
        public Double TaxAmount { get; set; }
        public Double OtherCharge { get; set; }
        public Double Total { get; set; }

        [Tab("Customer")]
        [Category("Name")]
        public String CustomerName { get; set; }
        [Category("Address")]
        public String CustomerStreet { get; set; }
        public String CustomerCity { get; set; }
        public String CustomerCountryName { get; set; }
        public String CustomerStateName { get; set; }
        public String CustomerZipCode { get; set; }
        public String CustomerPhone { get; set; }
        public String CustomerEmail { get; set; }

        public String BillingAddress { get; set; }

        public String ShippingAddress { get; set; }

    }

   
}