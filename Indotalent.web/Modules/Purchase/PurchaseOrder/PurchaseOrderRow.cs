using Indotalent.Bills;
using Indotalent.Material;
using Indotalent.Web.Modules.Material.Request;
using Indotalent.Web.Modules.Purchase.PurchaseOrder;
using Indotalent.Web.Modules.Purchase.Vendor;
using Indotalent.Web.Modules.Settings.PurchaseTax.LookUp;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using Serenity.Extensions.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Indotalent.Purchase
{
    [ConnectionKey("Default"), Module("Purchase"), TableName("[dbo].[PurchaseOrder]")]
    [DisplayName("Purchase Orders"), InstanceName("Purchase Order")]
    [LookupScript(LookupType = typeof(MultiTenantRowLookupScript<>))]
    [ReadPermission("Purchase:PurchaseOrder")]
    [ModifyPermission("Purchase:PurchaseOrder")]
    public sealed class PurchaseOrderRow : LoggingRow<PurchaseOrderRow.RowFields>, IIdRow, INameRow, IMultiTenantRow
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

        [DisplayName("Vendor"), NotNull, ForeignKey("[dbo].[Vendor]", "Id"), LeftJoin("jVendor"), TextualField("VendorName")]
        [LookupEditor(typeof(VendorLookup), InplaceAdd = true, DialogType = "Indotalent.Purchase.VendorDialog")]
        public Int32? VendorId
        {
            get => fields.VendorId[this];
            set => fields.VendorId[this] = value;
        }

        [DisplayName("Dispatched By"), Size(1000)]
        public String DispatchedBy
        {
            get => fields.DispatchedBy[this];
            set => fields.DispatchedBy[this] = value;
        }

        [DisplayName("Dispatch To"), Size(1000)]
        public String DispatchedTo
        {
            get => fields.DispatchedTo[this];
            set => fields.DispatchedTo[this] = value;
        }

        [DisplayName("Dispatched Details"), Size(1000)]
        public String DispatchDetails
        {
            get => fields.DispatchDetails[this];
            set => fields.DispatchDetails[this] = value;
        }

        [DisplayName("Quotation Reference Number"), Size(200)]

        public String QuotationReferenceNumber
        {
            get => fields.QuotationReferenceNumber[this];
            set => fields.QuotationReferenceNumber[this] = value;
        }

        [DisplayName("Order Date"), NotNull,QuickSearch]
        public DateTime? OrderDate
        {
            get => fields.OrderDate[this];
            set => fields.OrderDate[this] = value;
        }

        [DisplayName("Description"), Size(1000)]
        public String Description
        {
            get => fields.Description[this];
            set => fields.Description[this] = value;
        }

        [DisplayName("Request No"), NotNull, ForeignKey("[dbo].[MaterialRequest]", "Id"), LeftJoin("jMaterialRequest"), TextualField("MaterialRequestNumber"), QuickSearch]
        [LookupEditor(typeof(RequestRow), InplaceAdd = true)]
        public Int32? MaterialRequestId
        {
            get => fields.MaterialRequestId[this];
            set => fields.MaterialRequestId[this] = value;
        }

        [DisplayName("Request No"), Expression("jMaterialRequest.[Number]"), MinSelectLevel(SelectLevel.List), QuickSearch]
        [Insertable(false), Updatable(false)]
        public String MaterialRequestNumber
        {
            get => fields.MaterialRequestNumber[this];
            set => fields.MaterialRequestNumber[this] = value;
        }

        [DisplayName("Project"), ForeignKey("[dbo].[Project]", "Id"), Expression("jMaterialRequest.[ProjectId]"), LeftJoin("jProject"), TextualField("ProjectName"), Updatable(false), QuickSearch]
        public Int32? ProjectId
        {
            get => fields.ProjectId[this];
            set => fields.ProjectId[this] = value;
        }

        

        [DisplayName("Status"), QuickSearch]
        [DefaultValue(1)]
        public Status? Status
        {
            get => fields.Status[this];
            set => Fields.Status[this] = value;
        }


        [DisplayName("Project"), Expression("jProject.[Name]")]
        public String ProjectName
        {
            get => fields.ProjectName[this];
            set => fields.ProjectName[this] = value;
        }

        [DisplayName("IsPRCreated")]
        public Boolean? IsPRCreate
        {
            get => fields.IsPRCreate[this];
            set => fields.IsPRCreate[this] = value;
        }

        [DisplayName("IsBillCreated")]
        public Boolean? IsBillCreated
        {
            get => fields.IsBillCreated[this];
            set => fields.IsBillCreated[this] = value;
        }


        [DisplayName("Upload Quotation")]
        [MultipleFileUploadEditor(FilenameFormat = "Document/PurchaseOrder/~")]
        public string UploadQuotation
        {
            get => fields.UploadQuotation[this];
            set => fields.UploadQuotation[this] = value;
        }

        [DisplayName("Before Tax"), NotNull]
        [DefaultValue(0), Insertable(false), Updatable(false)]
        public Double? SubTotal
        {
            get => fields.SubTotal[this];
            set => fields.SubTotal[this] = value;
        }

        [DisplayName("Discount")]
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

        [DisplayName("GST Tax Amount"), NotNull, DecimalEditor(Decimals = 2, MinValue = 0), DisplayFormat("#,##0.##")]
        [DefaultValue(0), Insertable(false), Updatable(false)]
        public Double? TaxAmount
        {
            get => fields.TaxAmount[this];
            set => fields.TaxAmount[this] = value;
        }

        [DisplayName("SGST")]
        public Double? SGST
        {
            get => fields.SGST[this];
            set => fields.SGST[this] = value;
        }

        [DisplayName("CGST")]
        public Double? CGST
        {
            get => fields.CGST[this];
            set => fields.CGST[this] = value;
        }      

        [DisplayName("IGST")]
        public Double? IGST
        {
            get => fields.IGST[this];
            set => fields.IGST[this] = value;
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
        //[Updatable(false)]
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

        [DisplayName("Is Bill Generated"), NotNull]
        [DefaultValue(0)]
        public bool? IsBillGenerated
        {
            get => fields.IsBillGenerated[this];
            set => fields.IsBillGenerated[this] = value;
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

        #region Vendor Property

        [DisplayName("Vendor Name"), Expression("jVendor.[Name]")]
        [Insertable(false), Updatable(false)]
        public String VendorName
        {
            get => fields.VendorName[this];
            set => fields.VendorName[this] = value;
        }

        [DisplayName("Vendor Street"), Expression("jVendor.[Street]")]
        [Insertable(false), Updatable(false)]
        public String VendorStreet
        {
            get => fields.VendorStreet[this];
            set => fields.VendorStreet[this] = value;
        }

        [DisplayName("Vendor City"), Expression("jVendor.[City]")]
        [Insertable(false), Updatable(false)]
        public String VendorCity
        {
            get => fields.VendorCity[this];
            set => fields.VendorCity[this] = value;
        }

        [DisplayName("Vendor Country"), Expression("jVendor.[CountryId]"), ForeignKey("[dbo].[Country]", "Id"), LeftJoin("jCountry"), TextualField("CountryName")]
        [Insertable(false), Updatable(false)]
        public Int32? VendorCountry
        {
            get => fields.VendorCountry[this];
            set => fields.VendorCountry[this] = value;
        }

        [DisplayName("Vendor Country"), Expression("jCountry.[Name]")]
        [Insertable(false), Updatable(false)]
        public String VendorCountryName
        {
            get => fields.VendorCountryName[this];
            set => fields.VendorCountryName[this] = value;
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

        [DisplayName("Tenant State"), Expression("jTenant.[StateId]")]
        [Insertable(false), Updatable(false)]
        public Int32? TenantState
        {
            get => fields.TenantState[this];
            set => fields.TenantState[this] = value;
        }

        [DisplayName("Vendor Zip Code"), Expression("jVendor.[ZipCode]")]
        [Insertable(false), Updatable(false)]
        public String VendorZipCode
        {
            get => fields.VendorZipCode[this];
            set => fields.VendorZipCode[this] = value;
        }

        [DisplayName("Vendor Phone"), Expression("jVendor.[Phone]")]
        [Insertable(false), Updatable(false)]
        public String VendorPhone
        {
            get => fields.VendorPhone[this];
            set => fields.VendorPhone[this] = value;
        }

        [DisplayName("Vendor Email"), Expression("jVendor.[Email]")]
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

        #endregion

        [DisplayName("Items"), MasterDetailRelation(foreignKey: "PurchaseOrderId"), NotMapped]

        public List<PurchaseOrderDetailRow> ItemList
        {
            get => fields.ItemList[this];
            set => fields.ItemList[this] = value;
        }

        [DisplayName("Bills"), MasterDetailRelation(foreignKey: "PurchaseOrderId"), NotMapped]
        public List<BillRow> BillList
        {
            get => fields.BillList[this];
            set => fields.BillList[this] = value;
        }

        [DisplayName("Procurement Group"), Size(200)]
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

        [DisplayName("Currency"), Size(10), Expression("jTenant.Currency"), Insertable(false), Updatable(false)]
        public String CurrencyName
        {
            get => fields.CurrencyName[this];
            set => fields.CurrencyName[this] = value;
        }

        public Int32Field TenantIdField
        {
            get { return Fields.TenantId; }
        }

        public int Qty { get; internal set; }

        public PurchaseOrderRow()
            : base()
        {
        }

        public PurchaseOrderRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : LoggingRowFields
        {
            public Int32Field Id;
            public StringField Number;
            public Int32Field MaterialRequestId;
            public StringField MaterialRequestNumber;
            public StringField ProcurementGroup;
            public Int32Field VendorId;
            public StringField QuotationReferenceNumber;
            public DateTimeField OrderDate;
            public BooleanField IsPRCreate;
            public StringField Description;

            public StringField DispatchedBy;
            public StringField DispatchedTo;
            public StringField DispatchDetails;
        
            public DoubleField SubTotal;
            public DoubleField Discount;
            public DoubleField BeforeTax;
            public DoubleField TaxAmount;
            public DoubleField SGST;
            public DoubleField CGST;
            public DoubleField IGST;
            
            public Int32Field TDS;
            public Int32Field TCS;
            public Int32Field TaxType;
            public DoubleField TcsTdsTaxAmount;
            public DoubleField Total;
            public DoubleField FinalTotalPostTDS_TCS;
            public DoubleField OtherCharge;
            public StringField VendorName;
            public StringField VendorStreet;
            public StringField VendorCity;
            public Int32Field VendorCountry;
            public StringField VendorCountryName;
            public Int32Field VendorState;
            public StringField VendorStateName;
            public Int32Field TenantState;

            public StringField VendorZipCode;
            public StringField VendorPhone;
            public StringField VendorEmail;
            public StringField VendorGSTNumber;
            public StringField VendorAccountNumber;
            public StringField VendorIFSCCode;

            public StringField UploadQuotation;

            public StringField CurrencyName;
            public Int32Field TenantId;
            public StringField TenantName;

            public RowListField<PurchaseOrderDetailRow> ItemList;
            public RowListField<BillRow> BillList;
            public Int32Field ProjectId;
            public StringField ProjectName;

            public BooleanField IsBillGenerated;

            public BooleanField IsBillCreated;

           
            public EnumField<Status> Status;

        }
    }
}
