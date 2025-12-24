using Indotalent.Administration.Entities;
using Indotalent.Settings;
using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;
using System.IO;

namespace Indotalent.Administration
{
    [ConnectionKey("Default"), Module("Administration"), TableName("[dbo].[Tenant]")]
    [DisplayName("Tenant"), InstanceName("Tenant"), TwoLevelCached]
    [ReadPermission("Administration:Tenant")]
   // [ModifyPermission("TenantConfiguration:TenantConfiguration")]
    //[ReadPermission("Administration:Tenant:Read")]
    //[InsertPermission("Administration:Tenant:Insert")]
    //[UpdatePermission("Administration:Tenant:Update")]
    //[DeletePermission("Administration:Tenant:Delete")]
    [LookupScript("Administration.Tenant", Permission = "*")]
    public sealed class TenantRow : LoggingRow<TenantRow.RowFields>, IIdRow, INameRow
    {
        [DisplayName("Tenant Id"), Identity, IdProperty]
        public Int32? TenantId
        {
            get => fields.TenantId[this];
            set => fields.TenantId[this] = value;
        }

        [DisplayName("Tenant Name"), Size(100), NotNull, QuickSearch, NameProperty]
        public String TenantName
        {
            get => fields.TenantName[this];
            set => fields.TenantName[this] = value;
        }

        [DisplayName("Description"), Size(1000)]
        public String Description
        {
            get => fields.Description[this];
            set => fields.Description[this] = value;
        }

        [DisplayName("Street"), Size(200)]
        public String Street
        {
            get => fields.Street[this];
            set => fields.Street[this] = value;
        }

        [DisplayName("City"), Size(200)]
        public String City
        {
            get => fields.City[this];
            set => fields.City[this] = value;
        }



        [DisplayName("Country"), NotNull, ForeignKey("Country", "Id"), LookupInclude, LeftJoin("jCountry"), TextualField("CountryName"), QuickSearch]
        //[DisplayName("Country"), Size(200)]
        public Int32? CountryId
        {
            get => fields.CountryId[this];
            set => fields.CountryId[this] = value;
        }


        [DisplayName("Country"), Expression("jCountry.[Name]"), MinSelectLevel(SelectLevel.List), QuickSearch]
        public String CountryName
        {
            get => fields.CountryName[this];
            set => fields.CountryName[this] = value;
        }



        [DisplayName("State"), NotNull, ForeignKey("State", "Id"), LookupInclude, LeftJoin("jState"), TextualField("StateName"), QuickSearch]
        //[DisplayName("State"), Size(200)]
        public Int32? StateId
        {
            get => fields.StateId[this];
            set => fields.StateId[this] = value;
        }

        [DisplayName("State"), Expression("jState.[Name]"), MinSelectLevel(SelectLevel.List), QuickSearch]
        public String StateName
        {
            get => fields.StateName[this];
            set => fields.StateName[this] = value;
        }

        [DisplayName("Zip Code"), Size(50)]
        public String ZipCode
        {
            get => fields.ZipCode[this];
            set => fields.ZipCode[this] = value;
        }

        [DisplayName("Phone"), Size(50)]
        public String Phone
        {
            get => fields.Phone[this];
            set => fields.Phone[this] = value;
        }

        [DisplayName("Email"), Size(200)]
        public String Email
        {
            get => fields.Email[this];
            set => fields.Email[this] = value;
        }

        [DisplayName("Currency"), NotNull, Size(5)]
        public String Currency
        {
            get => fields.Currency[this];
            set => fields.Currency[this] = value;
        }

        [DisplayName("User Max"), NotNull]
        public Int32? MaximumUser
        {
            get => fields.MaximumUser[this];
            set => fields.MaximumUser[this] = value;
        }


        [DisplayName("Reminder In Days")]
        public Int32? ReminderInDays
        {
            get => fields.ReminderInDays[this];
            set => fields.ReminderInDays[this] = value;
        }
        [DisplayName("Total Reminder Count")]
        public Int32? TotalReminderCount
        {
            get => fields.TotalReminderCount[this];
            set => fields.TotalReminderCount[this] = value;
        }
        [DisplayName("Product Prefix"), Size(5), DefaultValue("ART")]
        public String ProductNumberPrefix
        {
            get => fields.ProductNumberPrefix[this];
            set => fields.ProductNumberPrefix[this] = value;
        }

        [DisplayName("Product Use Date"), DefaultValue(false)]
        public Boolean? ProductNumberUseDate
        {
            get => fields.ProductNumberUseDate[this];
            set => fields.ProductNumberUseDate[this] = value;
        }

        [DisplayName("Product Length"), DefaultValue(16), NotNull, IntegerEditor(MinValue = 2, MaxValue = 50)]
        public Int16? ProductNumberLength
        {
            get => fields.ProductNumberLength[this];
            set => fields.ProductNumberLength[this] = value;
        }
        [DisplayName("Material Request Prefix"), Size(5), DefaultValue("MRPF")]
        public String MaterialRequestNumberPrefix
        {
            get => fields.MaterialRequestNumberPrefix[this];
            set => fields.MaterialRequestNumberPrefix[this] = value;
        }
        [DisplayName("Material Request Use Date"), DefaultValue(true)]
        public Boolean? MaterialRequestNumberUseDate
        {
            get => fields.MaterialRequestNumberUseDate[this];
            set => fields.MaterialRequestNumberUseDate[this] = value;
        }
        [DisplayName("Material Request Length"), DefaultValue(16), NotNull, IntegerEditor(MinValue = 2, MaxValue = 50)]
        public Int16? MaterialRequestNumberLength
        {
            get => fields.MaterialRequestNumberLength[this];
            set => fields.MaterialRequestNumberLength[this] = value;
        }


        [DisplayName("Material Issue Prefix"), Size(5), DefaultValue("MIPF")]
        public String MaterialIssueNumberPrefix
        {
            get => fields.MaterialIssueNumberPrefix[this];
            set => fields.MaterialIssueNumberPrefix[this] = value;
        }
        [DisplayName("Material Issue Use Date"), DefaultValue(true)]
        public Boolean? MaterialIssueNumberUseDate
        {
            get => fields.MaterialIssueNumberUseDate[this];
            set => fields.MaterialIssueNumberUseDate[this] = value;
        }
        [DisplayName("Material Issue Length"), DefaultValue(16), NotNull, IntegerEditor(MinValue = 2, MaxValue = 50)]
        public Int16? MaterialIssueNumberLength
        {
            get => fields.MaterialIssueNumberLength[this];
            set => fields.MaterialIssueNumberLength[this] = value;
        }
        [DisplayName("Customer Prefix"), Size(5), DefaultValue("CST")]
        public String CustomerNumberPrefix
        {
            get => fields.CustomerNumberPrefix[this];
            set => fields.CustomerNumberPrefix[this] = value;
        }

        [DisplayName("Customer Use Date"), DefaultValue(true)]
        public Boolean? CustomerNumberUseDate
        {
            get => fields.CustomerNumberUseDate[this];
            set => fields.CustomerNumberUseDate[this] = value;
        }

        [DisplayName("Customer Length"), DefaultValue(16), NotNull, IntegerEditor(MinValue = 2, MaxValue = 50)]
        public Int16? CustomerNumberLength
        {
            get => fields.CustomerNumberLength[this];
            set => fields.CustomerNumberLength[this] = value;
        }

        [DisplayName("Sales Prefix"), Size(5), DefaultValue("SO")]
        public String SalesNumberPrefix
        {
            get => fields.SalesNumberPrefix[this];
            set => fields.SalesNumberPrefix[this] = value;
        }

        [DisplayName("Sales Use Date"), DefaultValue(true)]
        public Boolean? SalesNumberUseDate
        {
            get => fields.SalesNumberUseDate[this];
            set => fields.SalesNumberUseDate[this] = value;
        }

        [DisplayName("Sales Length"), DefaultValue(16), NotNull, IntegerEditor(MinValue = 2, MaxValue = 50)]
        public Int16? SalesNumberLength
        {
            get => fields.SalesNumberLength[this];
            set => fields.SalesNumberLength[this] = value;
        }

        [DisplayName("Invoice Prefix"), Size(5), DefaultValue("INV")]
        public String InvoiceNumberPrefix
        {
            get => fields.InvoiceNumberPrefix[this];
            set => fields.InvoiceNumberPrefix[this] = value;
        }

        [DisplayName("Invoice Use Date"), DefaultValue(true)]
        public Boolean? InvoiceNumberUseDate
        {
            get => fields.InvoiceNumberUseDate[this];
            set => fields.InvoiceNumberUseDate[this] = value;
        }

        [DisplayName("Invoice Length"), DefaultValue(16), NotNull, IntegerEditor(MinValue = 2, MaxValue = 50)]
        public Int16? InvoiceNumberLength
        {
            get => fields.InvoiceNumberLength[this];
            set => fields.InvoiceNumberLength[this] = value;
        }

        [DisplayName("Invoice Payment Prefix"), Size(5), DefaultValue("IVPY")]
        public String InvoicePaymentNumberPrefix
        {
            get => fields.InvoicePaymentNumberPrefix[this];
            set => fields.InvoicePaymentNumberPrefix[this] = value;
        }

        [DisplayName("Invoice Payment Use Date"), DefaultValue(true)]
        public Boolean? InvoicePaymentNumberUseDate
        {
            get => fields.InvoicePaymentNumberUseDate[this];
            set => fields.InvoicePaymentNumberUseDate[this] = value;
        }

        [DisplayName("Invoice Payment Length"), DefaultValue(16), NotNull, IntegerEditor(MinValue = 2, MaxValue = 50)]
        public Int16? InvoicePaymentNumberLength
        {
            get => fields.InvoicePaymentNumberLength[this];
            set => fields.InvoicePaymentNumberLength[this] = value;
        }

        [DisplayName("Vendor Prefix"), Size(5), DefaultValue("VND")]
        public String VendorNumberPrefix
        {
            get => fields.VendorNumberPrefix[this];
            set => fields.VendorNumberPrefix[this] = value;
        }

        [DisplayName("Vendor Use Date"), DefaultValue(true)]
        public Boolean? VendorNumberUseDate
        {
            get => fields.VendorNumberUseDate[this];
            set => fields.VendorNumberUseDate[this] = value;
        }

        [DisplayName("Vendor Length"), DefaultValue(16), NotNull, IntegerEditor(MinValue = 2, MaxValue = 50)]
        public Int16? VendorNumberLength
        {
            get => fields.VendorNumberLength[this];
            set => fields.VendorNumberLength[this] = value;
        }

        [DisplayName("Purchase Prefix"), Size(5), DefaultValue("PO")]
        public String PurchaseNumberPrefix
        {
            get => fields.PurchaseNumberPrefix[this];
            set => fields.PurchaseNumberPrefix[this] = value;
        }

        [DisplayName("Purchase Use Date"), DefaultValue(true)]
        public Boolean? PurchaseNumberUseDate
        {
            get => fields.PurchaseNumberUseDate[this];
            set => fields.PurchaseNumberUseDate[this] = value;
        }

        [DisplayName("Purchase Length"), DefaultValue(16), NotNull, IntegerEditor(MinValue = 2, MaxValue = 50)]
        public Int16? PurchaseNumberLength
        {
            get => fields.PurchaseNumberLength[this];
            set => fields.PurchaseNumberLength[this] = value;
        }

        [DisplayName("Bill Prefix"), Size(5), DefaultValue("BLL")]
        public String BillNumberPrefix
        {
            get => fields.BillNumberPrefix[this];
            set => fields.BillNumberPrefix[this] = value;
        }

        [DisplayName("Bill Use Date"), DefaultValue(true)]
        public Boolean? BillNumberUseDate
        {
            get => fields.BillNumberUseDate[this];
            set => fields.BillNumberUseDate[this] = value;
        }

        [DisplayName("Bill Length"), DefaultValue(16), NotNull, IntegerEditor(MinValue = 2, MaxValue = 50)]
        public Int16? BillNumberLength
        {
            get => fields.BillNumberLength[this];
            set => fields.BillNumberLength[this] = value;
        }

        [DisplayName("Quotation Prefix"), Size(5), DefaultValue("QUOT")]
        public String QuotationNumberPrefix
        {
            get => fields.QuotationNumberPrefix[this];
            set => fields.QuotationNumberPrefix[this] = value;
        }

        [DisplayName("Quotation Use Date"), DefaultValue(true)]
        public Boolean? QuotationNumberUseDate
        {
            get => fields.QuotationNumberUseDate[this];
            set => fields.QuotationNumberUseDate[this] = value;
        }

        [DisplayName("Quotation Length"), DefaultValue(16), NotNull, IntegerEditor(MinValue = 2, MaxValue = 50)]
        public Int16? QuotationNumberLength
        {
            get => fields.QuotationNumberLength[this];
            set => fields.QuotationNumberLength[this] = value;
        }

      
        [DisplayName("Bill Payment Prefix"), Size(5), DefaultValue("BLPY")]

        public String BillPaymentNumberPrefix
        {
            get => fields.BillPaymentNumberPrefix[this];
            set => fields.BillPaymentNumberPrefix[this] = value;
        }

        [DisplayName("Bill Payment Use Date"), DefaultValue(true)]
        public Boolean? BillPaymentNumberUseDate
        {
            get => fields.BillPaymentNumberUseDate[this];
            set => fields.BillPaymentNumberUseDate[this] = value;
        }

        [DisplayName("Bill Payment Length"), DefaultValue(16), NotNull, IntegerEditor(MinValue = 2, MaxValue = 50)]
        public Int16? BillPaymentNumberLength
        {
            get => fields.BillPaymentNumberLength[this];
            set => fields.BillPaymentNumberLength[this] = value;
        }

        [DisplayName("Sales Delivery"), Size(5), DefaultValue("DO")]
        public String SalesDeliveryNumberPrefix
        {
            get => fields.SalesDeliveryNumberPrefix[this];
            set => fields.SalesDeliveryNumberPrefix[this] = value;
        }

        [DisplayName("Sales Delivery Use Date"), DefaultValue(true)]
        public Boolean? SalesDeliveryNumberUseDate
        {
            get => fields.SalesDeliveryNumberUseDate[this];
            set => fields.SalesDeliveryNumberUseDate[this] = value;
        }

        [DisplayName("Sales Delivery Length"), DefaultValue(16), NotNull, IntegerEditor(MinValue = 2, MaxValue = 50)]
        public Int16? SalesDeliveryNumberLength
        {
            get => fields.SalesDeliveryNumberLength[this];
            set => fields.SalesDeliveryNumberLength[this] = value;
        }

        [DisplayName("Sales Return Prefix"), Size(5), DefaultValue("DORN")]
        public String SalesReturnNumberPrefix
        {
            get => fields.SalesReturnNumberPrefix[this];
            set => fields.SalesReturnNumberPrefix[this] = value;
        }

        [DisplayName("Sales Return Use Date"), DefaultValue(true)]
        public Boolean? SalesReturnNumberUseDate
        {
            get => fields.SalesReturnNumberUseDate[this];
            set => fields.SalesReturnNumberUseDate[this] = value;
        }

        [DisplayName("Sales Return Length"), DefaultValue(16), NotNull, IntegerEditor(MinValue = 2, MaxValue = 50)]
        public Int16? SalesReturnNumberLength
        {
            get => fields.SalesReturnNumberLength[this];
            set => fields.SalesReturnNumberLength[this] = value;
        }

        [DisplayName("Purchase Receipt Prefix"), Size(5), DefaultValue("GR")]
        public String PurchaseReceiptNumberPrefix
        {
            get => fields.PurchaseReceiptNumberPrefix[this];
            set => fields.PurchaseReceiptNumberPrefix[this] = value;
        }

        [DisplayName("Purchase Receipt Use Date"), DefaultValue(true)]
        public Boolean? PurchaseReceiptNumberUseDate
        {
            get => fields.PurchaseReceiptNumberUseDate[this];
            set => fields.PurchaseReceiptNumberUseDate[this] = value;
        }

        [DisplayName("Purchase Receipt Length"), DefaultValue(16), NotNull, IntegerEditor(MinValue = 2, MaxValue = 50)]
        public Int16? PurchaseReceiptNumberLength
        {
            get => fields.PurchaseReceiptNumberLength[this];
            set => fields.PurchaseReceiptNumberLength[this] = value;
        }

        [DisplayName("Purchase Return Prefix"), Size(5), DefaultValue("GRRN")]
        public String PurchaseReturnNumberPrefix
        {
            get => fields.PurchaseReturnNumberPrefix[this];
            set => fields.PurchaseReturnNumberPrefix[this] = value;
        }

        [DisplayName("PurchaseReturn Use Date"), DefaultValue(true)]
        public Boolean? PurchaseReturnNumberUseDate
        {
            get => fields.PurchaseReturnNumberUseDate[this];
            set => fields.PurchaseReturnNumberUseDate[this] = value;
        }

        [DisplayName("Purchase Return Length"), DefaultValue(16), NotNull, IntegerEditor(MinValue = 2, MaxValue = 50)]
        public Int16? PurchaseReturnNumberLength
        {
            get => fields.PurchaseReturnNumberLength[this];
            set => fields.PurchaseReturnNumberLength[this] = value;
        }

        [DisplayName("Material Return Prefix"), Size(5), DefaultValue("MTRN")]
        public String MaterialReturnNumberPrefix
        {
            get => fields.MaterialReturnNumberPrefix[this];
            set => fields.MaterialReturnNumberPrefix[this] = value;
        }

        [DisplayName("MaterialReturn Use Date"), DefaultValue(true)]
        public Boolean? MaterialReturnNumberUseDate
        {
            get => fields.MaterialReturnNumberUseDate[this];
            set => fields.MaterialReturnNumberUseDate[this] = value;
        }

        [DisplayName("Material Return Length"), DefaultValue(16), NotNull, IntegerEditor(MinValue = 2, MaxValue = 50)]
        public Int16? MaterialReturnNumberLength
        {
            get => fields.MaterialReturnNumberLength[this];
            set => fields.MaterialReturnNumberLength[this] = value;
        }


        [DisplayName("Positive Adjustment Prefix"), Size(5), DefaultValue("AJPF")]
        public String PositiveAdjustmentNumberPrefix
        {
            get => fields.PositiveAdjustmentNumberPrefix[this];
            set => fields.PositiveAdjustmentNumberPrefix[this] = value;
        }

        [DisplayName("Positive Adjustment Use Date"), DefaultValue(true)]
        public Boolean? PositiveAdjustmentNumberUseDate
        {
            get => fields.PositiveAdjustmentNumberUseDate[this];
            set => fields.PositiveAdjustmentNumberUseDate[this] = value;
        }

        [DisplayName("Positive Adjustment Length"), DefaultValue(16), NotNull, IntegerEditor(MinValue = 2, MaxValue = 50)]
        public Int16? PositiveAdjustmentNumberLength
        {
            get => fields.PositiveAdjustmentNumberLength[this];
            set => fields.PositiveAdjustmentNumberLength[this] = value;
        }

        [DisplayName("Negative Adjustment Prefix"), Size(5), DefaultValue("AJNF")]
        public String NegativeAdjustmentNumberPrefix
        {
            get => fields.NegativeAdjustmentNumberPrefix[this];
            set => fields.NegativeAdjustmentNumberPrefix[this] = value;
        }

        [DisplayName("Negative Adjustment Use Date"), DefaultValue(true)]
        public Boolean? NegativeAdjustmentNumberUseDate
        {
            get => fields.NegativeAdjustmentNumberUseDate[this];
            set => fields.NegativeAdjustmentNumberUseDate[this] = value;
        }

        [DisplayName("Negative Adjustment Length"), DefaultValue(16), NotNull, IntegerEditor(MinValue = 2, MaxValue = 50)]
        public Int16? NegativeAdjustmentNumberLength
        {
            get => fields.NegativeAdjustmentNumberLength[this];
            set => fields.NegativeAdjustmentNumberLength[this] = value;
        }

        [DisplayName("Transfer Order Prefix"), Size(5), DefaultValue("TO")]
        public String TransferOrderNumberPrefix
        {
            get => fields.TransferOrderNumberPrefix[this];
            set => fields.TransferOrderNumberPrefix[this] = value;
        }
        [DisplayName("Transfer Order Use Date"), DefaultValue(true)]
        public Boolean? TransferOrderNumberUseDate
        {
            get => fields.TransferOrderNumberUseDate[this];
            set => fields.TransferOrderNumberUseDate[this] = value;
        }
        

        [DisplayName("Transfer Order Length"), DefaultValue(16), NotNull, IntegerEditor(MinValue = 2, MaxValue = 50)]
        public Int16? TransferOrderNumberLength
        {
            get => fields.TransferOrderNumberLength[this];
            set => fields.TransferOrderNumberLength[this] = value;
        }
        [DisplayName("Bulk File Upload Prefix"), Size(30), DefaultValue("EmailSender")]
        public String BulkFileUploadNumberPrefix
        {
            get => fields.BulkFileUploadNumberPrefix[this];
            set => fields.BulkFileUploadNumberPrefix[this] = value;
        }

        [DisplayName("Bulk File Upload Use Date"), DefaultValue(true)]
        public Boolean? BulkFileUploadNumberUseDate
        {
            get => fields.BulkFileUploadNumberUseDate[this];
            set => fields.BulkFileUploadNumberUseDate[this] = value;
        }

        [DisplayName("Bulk File Upload Length"), DefaultValue(16), NotNull, IntegerEditor(MinValue = 2, MaxValue = 50)]
        public Int16? BulkFileUploadNumberLength
        {
            get => fields.BulkFileUploadNumberLength[this];
            set => fields.BulkFileUploadNumberLength[this] = value;
        }

        public TenantRow()
            : base()
        {
        }

        public TenantRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : LoggingRowFields
        {
            public Int32Field TenantId;
            public StringField TenantName;
            public StringField Description;
            public StringField Street;
            public StringField City;
            public Int32Field CountryId;
            public StringField CountryName;
            public Int32Field StateId;
            public StringField StateName;
            public StringField ZipCode;
            public StringField Phone;
            public StringField Email;
            public StringField Currency;
            public Int32Field MaximumUser;
            public Int32Field ReminderInDays; 
            public Int32Field TotalReminderCount;
            public BooleanField MaterialRequestNumberUseDate;
            public StringField MaterialRequestNumberPrefix;
            public BooleanField MaterialIssueNumberUseDate;
            public StringField MaterialIssueNumberPrefix;
            public Int16Field MaterialIssueNumberLength;
            public Int16Field ProductNumberLength;

            public StringField ProductNumberPrefix;
            public BooleanField ProductNumberUseDate;
            public Int16Field MaterialRequestNumberLength;
            public StringField CustomerNumberPrefix;
            public BooleanField CustomerNumberUseDate;
            public Int16Field CustomerNumberLength;
            public StringField SalesNumberPrefix;
            public BooleanField SalesNumberUseDate;
            public Int16Field SalesNumberLength;
            public StringField InvoiceNumberPrefix;
            public BooleanField InvoiceNumberUseDate;
            public Int16Field InvoiceNumberLength;
            public StringField InvoicePaymentNumberPrefix;
            public BooleanField InvoicePaymentNumberUseDate;
            public Int16Field InvoicePaymentNumberLength;
            public StringField VendorNumberPrefix;
            public BooleanField VendorNumberUseDate;
            public Int16Field VendorNumberLength;
            public StringField PurchaseNumberPrefix;
            public BooleanField PurchaseNumberUseDate;
            public Int16Field PurchaseNumberLength;
            public StringField BillNumberPrefix;
            public BooleanField BillNumberUseDate;
            public Int16Field BillNumberLength;
            public StringField BillPaymentNumberPrefix;
            public BooleanField BillPaymentNumberUseDate;
            public Int16Field BillPaymentNumberLength;
            public StringField SalesDeliveryNumberPrefix;
            public BooleanField SalesDeliveryNumberUseDate;
            public Int16Field SalesDeliveryNumberLength;
            public StringField SalesReturnNumberPrefix;
            public BooleanField SalesReturnNumberUseDate;
            public Int16Field SalesReturnNumberLength;
            public StringField PurchaseReceiptNumberPrefix;
            public BooleanField PurchaseReceiptNumberUseDate;
            public Int16Field PurchaseReceiptNumberLength;
            public StringField PurchaseReturnNumberPrefix;
            public BooleanField PurchaseReturnNumberUseDate;
            public Int16Field PurchaseReturnNumberLength;
            public StringField MaterialReturnNumberPrefix;
            public BooleanField MaterialReturnNumberUseDate;
            public Int16Field MaterialReturnNumberLength;
            public StringField PositiveAdjustmentNumberPrefix;
            public BooleanField PositiveAdjustmentNumberUseDate;
            public Int16Field PositiveAdjustmentNumberLength;
            public StringField NegativeAdjustmentNumberPrefix;
            public BooleanField NegativeAdjustmentNumberUseDate;
            public Int16Field NegativeAdjustmentNumberLength;
            public StringField TransferOrderNumberPrefix;
            public BooleanField TransferOrderNumberUseDate;
            public Int16Field TransferOrderNumberLength;
            public StringField QuotationNumberPrefix;
            public BooleanField QuotationNumberUseDate;
            public Int16Field QuotationNumberLength;
            public StringField BulkFileUploadNumberPrefix;
            public BooleanField BulkFileUploadNumberUseDate;
            public Int16Field BulkFileUploadNumberLength;
        }
    }
}
