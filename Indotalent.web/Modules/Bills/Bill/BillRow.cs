using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using Indotalent.Purchase;
using System;
using System.Collections.Generic;
using Serenity.Extensions.Entities;
using System.ComponentModel;
using System.IO;
using Indotalent.Web.Modules.Settings.PurchaseTax.LookUp;
using Indotalent.Web.Modules.Bills.Bill;
using Indotalent.Projects;

namespace Indotalent.Bills
{
    [ConnectionKey("Default"), Module("Bills"), TableName("[dbo].[Bill]")]
    [DisplayName("Purchase Bill"), InstanceName("Purchase Bill")]
    [LookupScript(LookupType = typeof(MultiTenantRowLookupScript<>))]
    [ReadPermission("Bills:Bill")]
    [ModifyPermission("Bills:Bill")]
    public sealed class BillRow : Row<BillRow.RowFields>, IIdRow, INameRow, IMultiTenantRow
    {

        [DisplayName("Id"), Identity, IdProperty]
        public Int32? Id
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
        }

        [DisplayName("Number"), Size(200), NotNull, QuickSearch, NameProperty]

        [DefaultValue("auto")]
        public String Number
        {
            get => fields.Number[this];
            set => fields.Number[this] = value;
        }

        [DisplayName("Description"), Size(1000)]
        public String Description
        {
            get => fields.Description[this];
            set => fields.Description[this] = value;
        }

        [DisplayName("External Reference Number"), Size(200)]
        public String ExternalReferenceNumber
        {
            get => fields.ExternalReferenceNumber[this];
            set => fields.ExternalReferenceNumber[this] = value;
        }

        [DisplayName("Bill Date"), NotNull,QuickSearch]
        public DateTime? BillDate
        {
            get => fields.BillDate[this];
            set => fields.BillDate[this] = value;
        }

        [DisplayName("Purchase Order"), ForeignKey("[dbo].[PurchaseOrder]", "Id"), LeftJoin("jPurchaseOrder"), TextualField("PurchaseOrderNumber")]
        [LookupEditor(typeof(PurchaseOrderRow))]
        [Updatable(false)]
        public Int32? PurchaseOrderId
        {
            get => fields.PurchaseOrderId[this];
            set => fields.PurchaseOrderId[this] = value;
        }

        [DisplayName("Project Name"), ForeignKey("[dbo].[Project]", "Id"), LeftJoin("jProject"), TextualField("ProjectName")]
        [LookupEditor(typeof(ProjectRow))]
        [Updatable(false)]
        public Int32? ProjectId
        {
            get => fields.PurchaseOrderId[this];
            set => fields.PurchaseOrderId[this] = value;
        }

        [DisplayName("Is Bill Payment Generated"), NotNull]
        [DefaultValue(0)]
        public bool? IsBillPaymentGenerated
        {
            get => fields.IsBillPaymentGenerated[this];
            set => fields.IsBillPaymentGenerated[this] = value;
        }

        [DisplayName("Purchase Order"), Expression("jPurchaseOrder.[Number]"), MinSelectLevel(SelectLevel.List)]
        [Insertable(false), Updatable(false)]
        public String PurchaseOrderNumber
        {
            get => fields.PurchaseOrderNumber[this];
            set => fields.PurchaseOrderNumber[this] = value;
        }

        [DisplayName("Purchase Receipt"), ForeignKey("[dbo].[PurchaseReceipt]", "Id"), LeftJoin("jPurchaseReceipt"), TextualField("PurchaseReceiptNumber")]
        [LookupEditor(typeof(PurchaseReceiptRow))]
        [Updatable(false)]
        public Int32? PurchaseReceiptId
        {
            get => fields.PurchaseReceiptId[this];
            set => fields.PurchaseReceiptId[this] = value;
        }

        [DisplayName("Purchase Receipt"), Expression("jPurchaseReceipt.[Number]"), MinSelectLevel(SelectLevel.List)]
        [Insertable(false), Updatable(false)]
        public String PurchaseReceiptNumber
        {
            get => fields.PurchaseReceiptNumber[this];
            set => fields.PurchaseReceiptNumber[this] = value;
        }


        [DisplayName("Before Tax"), NotNull]
        [DefaultValue(0), Insertable(false), Updatable(false)]
        public Double? SubTotal
        {
            get => fields.SubTotal[this];
            set => fields.SubTotal[this] = value;
        }

        [DisplayName("Discount"), NotNull]
        [DefaultValue(0), Insertable(false), Updatable(false)]
        public Double? Discount
        {
            get => fields.Discount[this];
            set => fields.Discount[this] = value;
        }

        [DisplayName("Sub Total"), NotNull]
        [DefaultValue(0), Insertable(false), Updatable(false)]
        public Double? BeforeTax
        {
            get => fields.BeforeTax[this];
            set => fields.BeforeTax[this] = value;
        }

        [DisplayName("Tax Amount"), NotNull]
        [DefaultValue(0), Insertable(false), Updatable(false)]
        public Double? TaxAmount
        {
            get => fields.TaxAmount[this];
            set => fields.TaxAmount[this] = value;
        }

        [DisplayName("TDS"), ForeignKey("[dbo].[PurchaseTax]", "Id"), TextualField("PurchaseTaxName")]
        [LookupEditor(typeof(PurchaseTaxTDSLookup), InplaceAdd = true, DialogType = "Indotalent.Settings.PurchaseTaxDialog")]
        public Int32? TDS
        {
            get => fields.TDS[this];
            set => fields.TDS[this] = value;

        }

        [DisplayName("TCS"), ForeignKey("[dbo].[PurchaseTax]", "Id"), TextualField("PurchaseTaxName")]
        [LookupEditor(typeof(PurchaseTaxTCSLookup), InplaceAdd = true, DialogType = "Indotalent.Settings.PurchaseTaxDialog")]
        public Int32? TCS
        {
            get => fields.TCS[this];
            set => fields.TCS[this] = value;

        }

        [DisplayName("Tax Type")]
        [Updatable(false)]
        [EnumEditor]
        public TaxTypeTDSTCS? TaxType
        {
            get => (TaxTypeTDSTCS?)fields.TaxType[this];
            set => fields.TaxType[this] = (int?)value;
        }

        [DisplayName("TCS/TDS Tax Amount"), DecimalEditor(Decimals = 2, MinValue = 0), DisplayFormat("#,##0.##")]
        [DefaultValue(0), Updatable(false)]
        public Double? TcsTdsTaxAmount
        {
            get => fields.TcsTdsTaxAmount[this];
            set => fields.TcsTdsTaxAmount[this] = value;
        }

        [DisplayName("Total Before TCS/TDS"), NotNull, DecimalEditor(Decimals = 2, MinValue = 0), DisplayFormat("#,##0.##")]
        [DefaultValue(0), Insertable(false), Updatable(false)]
        public Double? Total
        {
            get => fields.Total[this];
            set => fields.Total[this] = value;
        }


        [DisplayName("Total"), DecimalEditor(Decimals = 2, MinValue = 0), DisplayFormat("#,##0.##")]
        [DefaultValue(0), Updatable(false)]
        public Double? FinalTotalPostTDS_TCS
        {
            get => fields.FinalTotalPostTDS_TCS[this];
            set => fields.FinalTotalPostTDS_TCS[this] = value;
        }

        [DisplayName("Other Charge"), NotNull]
        [DefaultValue(0)]
        public Double? OtherCharge
        {
            get => fields.OtherCharge[this];
            set => fields.OtherCharge[this] = value;
        }

        [DisplayName("Dispatched By"), Size(1000), Expression("jPurchaseOrder.[DispatchedBy]")]
        public String DispatchedBy
        {
            get => fields.DispatchedBy[this];
            set => fields.DispatchedBy[this] = value;
        }
        [DisplayName("Dispatched To"), Size(1000), Expression("jPurchaseOrder.[DispatchedTo]")]
        public String DispatchedTo
        {
            get => fields.DispatchedTo[this];
            set => fields.DispatchedTo[this] = value;
        }
        [DisplayName("Dispatched Details"), Size(1000), Expression("jPurchaseOrder.[DispatchDetails]")]
        public String DispatchDetails
        {
            get => fields.DispatchDetails[this];
            set => fields.DispatchDetails[this] = value;
        }


        [DisplayName("Vendor"), Expression("jPurchaseOrder.[VendorId]"), ForeignKey("[dbo].[Vendor]", "Id"), LeftJoin("jVendor")]
        public Int32? VendorId
        {
            get => fields.VendorId[this];
            set => fields.VendorId[this] = value;
        }

        [DisplayName("Vendor Name"), Expression("jVendor.[Name]"), MinSelectLevel(SelectLevel.List)]
        [Insertable(false), Updatable(false)]
        public String VendorName
        {
            get => fields.VendorName[this];
            set => fields.VendorName[this] = value;
        }

        [DisplayName("Vendor Street"), Expression("jVendor.[Street]"), MinSelectLevel(SelectLevel.List)]
        [Insertable(false), Updatable(false)]
        public String VendorStreet
        {
            get => fields.VendorStreet[this];
            set => fields.VendorStreet[this] = value;
        }

        [DisplayName("Vendor City"), Expression("jVendor.[City]"), MinSelectLevel(SelectLevel.List)]
        [Insertable(false), Updatable(false)]
        public String VendorCity
        {
            get => fields.VendorCity[this];
            set => fields.VendorCity[this] = value;
        }

        [DisplayName("Vendor State"), Expression("jVendor.[StateId]"), ForeignKey("[dbo].[State]", "Id"), LeftJoin("jState"), TextualField("StateName")]
        [Insertable(false), Updatable(false)]
        public Int32? VendorState
        {
            get => fields.VendorState[this];
            set => fields.VendorState[this] = value;
        }

        [DisplayName("Vendor State"), Expression("jState.[Name]")]
        [Insertable(false), Updatable(false)]
        public String VendorStateName
        {
            get => fields.VendorStateName[this];
            set => fields.VendorStateName[this] = value;
        }


        [DisplayName("Vendor Zip Code"), Expression("jVendor.[ZipCode]"), MinSelectLevel(SelectLevel.List)]
        [Insertable(false), Updatable(false)]
        public String VendorZipCode
        {
            get => fields.VendorZipCode[this];
            set => fields.VendorZipCode[this] = value;
        }

        [DisplayName("Vendor Phone"), Expression("jVendor.[Phone]"), MinSelectLevel(SelectLevel.List)]
        [Insertable(false), Updatable(false)]
        public String VendorPhone
        {
            get => fields.VendorPhone[this];
            set => fields.VendorPhone[this] = value;
        }

        [DisplayName("Vendor Email"), Expression("jVendor.[Email]"), MinSelectLevel(SelectLevel.List)]
        [Insertable(false), Updatable(false)]
        public String VendorEmail
        {
            get => fields.VendorEmail[this];
            set => fields.VendorEmail[this] = value;
        }

        [DisplayName("Vendor GST Number"), Expression("jVendor.[GSTNumber]")]
        [Insertable(false), Updatable(false)]
        public String VendorGSTNumber
        {
            get => fields.VendorGSTNumber[this];
            set => fields.VendorGSTNumber[this] = value;
        }

        [DisplayName("Vendor Account Number"), Expression("jVendor.[AccountNumber]")]
        [Insertable(false), Updatable(false)]
        public String VendorAccountNumber
        {
            get => fields.VendorAccountNumber[this];
            set => fields.VendorAccountNumber[this] = value;
        }

        [DisplayName("Vendor IFSC Code"), Expression("jVendor.[IFSCCode]")]
        [Insertable(false), Updatable(false)]
        public String VendorIFSCCode
        {
            get => fields.VendorIFSCCode[this];
            set => fields.VendorIFSCCode[this] = value;
        }

        [DisplayName("Items"), MasterDetailRelation(foreignKey: "BillId"), MinSelectLevel(SelectLevel.List), NotMapped]
        public List<BillDetailRow> ItemList
        {
            get => fields.ItemList[this];
            set => fields.ItemList[this] = value;
        }

        [DisplayName("Bill Payments"), MasterDetailRelation(foreignKey: "BillId"), NotMapped]
        public List<BillPaymentRow> BillPaymentList
        {
            get => fields.BillPaymentList[this];
            set => fields.BillPaymentList[this] = value;
        }

        [DisplayName("Procurement"), Size(200)]
        public String ProcurementGroup
        {
            get => fields.ProcurementGroup[this];
            set => fields.ProcurementGroup[this] = value;
        }

        [DisplayName("Tenant"), ForeignKey("Tenant", "TenantId"), LeftJoin("jTenant")]
        [Insertable(false), Updatable(false)]
        public Int32? TenantId
        {
            get { return Fields.TenantId[this]; }
            set { Fields.TenantId[this] = value; }
        }

        [DisplayName("Tenant"), Expression("jTenant.TenantName")]
        public String TenantName
        {
            get { return Fields.TenantName[this]; }
            set { Fields.TenantName[this] = value; }
        }

        [DisplayName("Currency"), Size(10), Expression("jTenant.Currency"), MinSelectLevel(SelectLevel.List), Insertable(false), Updatable(false)]
        public String CurrencyName
        {
            get => fields.CurrencyName[this];
            set => fields.CurrencyName[this] = value;
        }

        public Int32Field TenantIdField
        {
            get { return Fields.TenantId; }
        }

        public BillRow()
            : base()
        {
        }

        public BillRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field Id;
            public StringField Number;
            public StringField Description;
            public StringField ExternalReferenceNumber;
            public DateTimeField BillDate;
            public Int32Field PurchaseOrderId;
            public Int32Field ProjectId;
            public BooleanField IsBillPaymentGenerated;
            public StringField PurchaseOrderNumber;

            public Int32Field PurchaseReceiptId;
            public StringField PurchaseReceiptNumber;

            public DoubleField SubTotal;
            public DoubleField Discount;
            public DoubleField BeforeTax;
            public DoubleField TaxAmount;
            public Int32Field TDS;
            public Int32Field TCS;
            public Int32Field TaxType;
            public DoubleField TcsTdsTaxAmount;
            public DoubleField Total;
            public DoubleField FinalTotalPostTDS_TCS;
            public DoubleField OtherCharge;

            public StringField DispatchedBy;
            public StringField DispatchedTo;
            public StringField DispatchDetails;


            public Int32Field VendorId;
            public StringField VendorName;
            public StringField VendorStreet;
            public StringField VendorCity;
            public Int32Field VendorState;
            public StringField VendorStateName;
            public StringField VendorZipCode;
            public StringField VendorPhone;
            public StringField VendorEmail;
            public StringField VendorGSTNumber;
            public StringField VendorAccountNumber;
            public StringField VendorIFSCCode;
            public StringField ProcurementGroup;

            public StringField CurrencyName;
            public Int32Field TenantId;
            public StringField TenantName;

            public RowListField<BillDetailRow> ItemList;
            public RowListField<BillPaymentRow> BillPaymentList;

        }
    }
}
