using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;
using Indotalent.Bills;
using Org.BouncyCastle.Utilities;
using System.Text.RegularExpressions;
using Indotalent.Web.Modules.Purchase.PurchaseOrder;


namespace Indotalent.Purchase.Forms
{
    [FormScript("Purchase.PurchaseOrder")]
    [BasedOnRow(typeof(PurchaseOrderRow), CheckNames = true)]
    public class PurchaseOrderForm
    {
        [Tab("General")]
        [Category("Purchase Order")]

        [HalfWidth]
        public String Number { get; set; }

        [HalfWidth]
        [DefaultValue("now")]
        public DateTime OrderDate { get; set; }

        [HalfWidth]
        public Int32 VendorId { get; set; }

        [HalfWidth]
        public String QuotationReferenceNumber { get; set; }   
        
        [HalfWidth]
        [TextAreaEditor(Rows = 3)]
        public String Description { get; set; }
        
        [HalfWidth]
		public Int32 MaterialRequestId { get; set; }

        [HalfWidth]
        public string UploadQuotation { get; set; }

        [Hidden]
        public Boolean IsPRCreate { get; set; }

        [Hidden]
        public Boolean IsBillCreated { get; set; }

        [Hidden]
        public Status? Status { get; set; }

        [Category("Detail")]
        [PurchaseOrderDetailEditor]
        public List<PurchaseOrderDetailRow> ItemList { get; set; }

        [Category("Dispatch Details")]       
        
        [TextAreaEditor(Rows = 4)]
        [HalfWidth]
        public String DispatchedTo { get; set; }

        [HalfWidth]
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

        //[HalfWidth]
        //public EnumField<Status> Status { get; set; }

        [Tab("Vendor")]
        [Category("Name")]

        public String VendorName { get; set; }

        [Category("Address")]
        public String VendorStreet { get; set; }
        public String VendorCity { get; set; }
        public String VendorCountryName { get; set; }
        public String VendorStateName { get; set; }
        public String VendorZipCode { get; set; }
        public String VendorPhone { get; set; }
        public String VendorEmail { get; set; }

        [Category("Financial Details")]
        public String VendorGSTNumber { get; set; }
        public String VendorAccountNumber { get; set; }
        public String VendorIFSCCode { get; set; }

        [Tab("Bills")]
        [Category("Related Bills")]
        [BillEditor]
        public List<BillRow> BillList { get; set; }
    }
}