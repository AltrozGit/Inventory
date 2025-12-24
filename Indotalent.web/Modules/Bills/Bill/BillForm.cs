using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;
using Indotalent.Web.Modules.Bills.Bill;


namespace Indotalent.Bills.Forms
{
    [FormScript("Bills.Bill")]
    [BasedOnRow(typeof(BillRow), CheckNames = true)]
    public class BillForm
    {
        [Tab("General")]
        [Category("Bill Info")]
        [HalfWidth]
        public String Number { get; set; }
        [HalfWidth]
        [DefaultValue("now")]
        public DateTime BillDate { get; set; }
        [HalfWidth]
        [TextAreaEditor(Rows = 3)]
        public String Description { get; set; }
        [HalfWidth]
        public Int32 PurchaseOrderId { get; set; }

        [HalfWidth]
        public Int32 ProjectId { get; set; }

        

        [Category("External")]
        public String ExternalReferenceNumber { get; set; }


        [Category("Detail")]
        [BillDetailEditor]
        public List<BillDetailRow> ItemList { get; set; }
        [Category("Dispatch Details")]

       
        [HalfWidth]
        [TextAreaEditor(Rows = 3)]
        public String DispatchedTo { get; set; }

        [Category("Adjustment")]

        [HalfWidth]
        public String CurrencyName { get; set; }

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




        [Tab("Vendor")]
        [Category("Name")]
        public String VendorName { get; set; }
        [Category("Address")]
        public String VendorStreet { get; set; }
        public String VendorCity { get; set; }
        public String VendorStateName { get; set; }
        public String VendorZipCode { get; set; }
        public String VendorPhone { get; set; }
        public String VendorEmail { get; set; }

        [Category("Financial Details")]
        public String VendorGSTNumber { get; set; }
        public String VendorAccountNumber { get; set; }
        public String VendorIFSCCode { get; set; }

        [Tab("Payments")]
        [Category("Related Payments")]
        [BillPaymentEditor]
        public List<BillPaymentRow> BillPaymentList { get; set; }
    }
}