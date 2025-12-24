using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;
using Indotalent.Settings;

namespace Indotalent.Administration.Forms
{
    [FormScript("Administration.Tenant")]
    [BasedOnRow(typeof(TenantRow), CheckNames = true)]
    public class TenantForm
    {
        [Tab("General")]
        [Category("Identity")]
        public String TenantName { get; set; }
        [TextAreaEditor(Rows = 3)]
        public String Description { get; set; }
        public String Currency { get; set; }

        [Category("Address")]
        public String Street { get; set; }
        public String City { get; set; }

        [LookupEditor(typeof(CountryRow))]
        public Int32? CountryId { get; set; }

        [LookupEditor(typeof(StateRow), CascadeFrom = "CountryId")]
        public Int32? StateId { get; set; }
        public String ZipCode { get; set; }
        public String Phone { get; set; }
        public String Email { get; set; }
        [Category("Reminder Information")]
        public int  ReminderInDays { get; set; }
        public int  TotalReminderCount { get; set; }


        [Tab("Number Sequence")]
        [Category("Projects")]
        [OneThirdWidth]
        public String QuotationNumberPrefix { get; set; }
        [OneThirdWidth]
        public Boolean QuotationNumberUseDate { get; set; }
        [OneThirdWidth]
        public Int16 QuotationNumberLength { get; set; }
        [Category("Merchandise")]

        [OneThirdWidth]
        public String ProductNumberPrefix { get; set; }
        [OneThirdWidth]
        public Boolean ProductNumberUseDate { get; set; }
        [OneThirdWidth]
        public Int16 ProductNumberLength { get; set; }
        [Category("Sales")]
        [OneThirdWidth]
        public String CustomerNumberPrefix { get; set; }
        [OneThirdWidth]
        public Boolean CustomerNumberUseDate { get; set; }
        [OneThirdWidth]
        public Int16 CustomerNumberLength { get; set; }
        [OneThirdWidth]
        public String SalesNumberPrefix { get; set; }
        [OneThirdWidth]
        public Boolean SalesNumberUseDate { get; set; }
        [OneThirdWidth]
        public Int16 SalesNumberLength { get; set; }
        [OneThirdWidth]
        public String InvoiceNumberPrefix { get; set; }
        [OneThirdWidth]
        public Boolean InvoiceNumberUseDate { get; set; }
        [OneThirdWidth]
        public Int16 InvoiceNumberLength { get; set; }
        [OneThirdWidth]
        public String InvoicePaymentNumberPrefix { get; set; }
        [OneThirdWidth]
        public Boolean InvoicePaymentNumberUseDate { get; set; }
        [OneThirdWidth]
        public Int16 InvoicePaymentNumberLength { get; set; }
        [Category("Purchase")]
        [OneThirdWidth]
        public String VendorNumberPrefix { get; set; }
        [OneThirdWidth]
        public Boolean VendorNumberUseDate { get; set; }
        [OneThirdWidth]
        public Int16 VendorNumberLength { get; set; }
        [OneThirdWidth]
        public String PurchaseNumberPrefix { get; set; }
        [OneThirdWidth]
        public Boolean PurchaseNumberUseDate { get; set; }
        [OneThirdWidth]
        public Int16 PurchaseNumberLength { get; set; }
        [OneThirdWidth]
        public String BillNumberPrefix { get; set; }
        [OneThirdWidth]
        public Boolean BillNumberUseDate { get; set; }
        [OneThirdWidth]
        public Int16 BillNumberLength { get; set; }
        [OneThirdWidth]
        public String BillPaymentNumberPrefix { get; set; }
        [OneThirdWidth]
        public Boolean BillPaymentNumberUseDate { get; set; }
        [OneThirdWidth]
        public Int16 BillPaymentNumberLength { get; set; }
        [Category("Inventory")]
        [OneThirdWidth]
        public String MaterialRequestNumberPrefix { get; set; }
        [OneThirdWidth]
        public Boolean MaterialRequestNumberUseDate { get; set; }
        [OneThirdWidth]
        public Int16 MaterialRequestNumberLength { get; set; }

        [OneThirdWidth]
        public String MaterialIssueNumberPrefix { get; set; }
        [OneThirdWidth]
        public Boolean MaterialIssueNumberUseDate { get; set; }
        [OneThirdWidth]
        public Int16 MaterialIssueNumberLength { get; set; }
        [OneThirdWidth]
        public String SalesDeliveryNumberPrefix { get; set; }
        [OneThirdWidth]
        public Boolean SalesDeliveryNumberUseDate { get; set; }
        [OneThirdWidth]
        public Int16 SalesDeliveryNumberLength { get; set; }
        [OneThirdWidth]
        public String SalesReturnNumberPrefix { get; set; }
        [OneThirdWidth]
        public Boolean SalesReturnNumberUseDate { get; set; }
        [OneThirdWidth]
        public Int16 SalesReturnNumberLength { get; set; }
        [OneThirdWidth]
        public String PurchaseReceiptNumberPrefix { get; set; }
        [OneThirdWidth]
        public Boolean PurchaseReceiptNumberUseDate { get; set; }
        [OneThirdWidth]
        public Int16 PurchaseReceiptNumberLength { get; set; }
        [OneThirdWidth]
        public String PurchaseReturnNumberPrefix { get; set; }
        [OneThirdWidth]
        public Boolean PurchaseReturnNumberUseDate { get; set; }
        [OneThirdWidth]
        public Int16 PurchaseReturnNumberLength { get; set; }
        [OneThirdWidth]
        public String MaterialReturnNumberPrefix { get; set; }
        [OneThirdWidth]
        public Boolean MaterialReturnNumberUseDate { get; set; }
        [OneThirdWidth]
        public Int16 MaterialReturnNumberLength { get; set; }
        [OneThirdWidth]
        public String PositiveAdjustmentNumberPrefix { get; set; }
        [OneThirdWidth]
        public Boolean PositiveAdjustmentNumberUseDate { get; set; }
        [OneThirdWidth]
        public Int16 PositiveAdjustmentNumberLength { get; set; }
        [OneThirdWidth]
        public String NegativeAdjustmentNumberPrefix { get; set; }
        [OneThirdWidth]
        public Boolean NegativeAdjustmentNumberUseDate { get; set; }
        [OneThirdWidth]
        public Int16 NegativeAdjustmentNumberLength { get; set; }
        [OneThirdWidth]
        public String TransferOrderNumberPrefix { get; set; }
        [OneThirdWidth]
        public Boolean TransferOrderNumberUseDate { get; set; }
        [OneThirdWidth]
        public Int16 TransferOrderNumberLength { get; set; }
        [OneThirdWidth]
        public String BulkFileUploadNumberPrefix { get; set; }
        [OneThirdWidth]
        public Boolean BulkFileUploadNumberUseDate { get; set; }
        [OneThirdWidth]
        public Int16 BulkFileUploadNumberLength { get; set; }

        [Tab("Package")]
        [Category("Provisioning")]
        public int MaximumUser { get; set; }
    }
}