using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;
using Indotalent.Web.Modules.Sales.Invoice;

namespace Indotalent.Sales.Forms
{
    [FormScript("Sales.Invoice")]
    [BasedOnRow(typeof(InvoiceRow), CheckNames = true)]
    public class InvoiceForm
    {
        [Tab("General")]
        [Category("Invoice Info")]
        [HalfWidth]
        public String Number { get; set; }
        [HalfWidth]
        [DefaultValue("now")]
        public DateTime InvoiceDate { get; set; }
        
        [HalfWidth]
        //[ReadOnly(true)]
        public Int32 SalesOrderId { get; set; }

        [HalfWidth]
        public String CustomerPONumber { get; set; }
        [HalfWidth]
        public DateTime PONumberDate { get; set; }

        [HalfWidth]
        public String PyamentTerm { get; set; }
        [HalfWidth]
        [TextAreaEditor(Rows = 3)]
        public String Description { get; set; }


        [Category("Detail")]
        [InvoiceDetailEditor]
        public List<InvoiceDetailRow> ItemList { get; set; }

        [Category("Dispatch Details")]
        [HalfWidth]
        [TextAreaEditor(Rows = 4)]
        public String DispatchedBy { get; set; }

        [HalfWidth]
        [TextAreaEditor(Rows = 4)]
        public String DispatchedTo { get; set; }

        [HalfWidth]
        public String PlaceOfSupply { get; set; }

       
        public String TenantState { get; set; }

        [Category("Adjustment")]

        [HalfWidth]
        public string CurrencyName { get; set; }


        [HalfWidth]
        public Double Discount { get; set; }

        [HalfWidth]
        public Double OtherCharge { get; set; }

        [Category("Tax")]

        [HalfWidth]
        [EnumEditor]
        public TaxTypeTDSTCS? TaxType { get; set; }

        [HalfWidth]
        public Double TaxAmount { get; set; }

        [HalfWidth]
        public Int32 TDS { get; set; }

        [HalfWidth]
        public Int32 TCS { get; set; }

        [HalfWidth]
        public Double TcsTdsTaxAmount { get; set; }


        [Category("Summary")]

        [HalfWidth]
        [Hidden]
        public Double SubTotal { get; set; }

       
        [HalfWidth]
        public Double BeforeTax { get; set; }

     
        [HalfWidth]
        [Hidden]
        public Double Total { get; set; }


        [HalfWidth]
        public Double FinalTotalPostTDS_TCS { get; set; }

       

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

        [Tab("Payments")]
        [Category("Related Payments")]
        [InvoicePaymentEditor]
        public List<InvoicePaymentRow> InvoicePaymentList { get; set; }
    }
}