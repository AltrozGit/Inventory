using Indotalent.Material;
using Indotalent.Web.Modules.Sales.Invoice;
using Indotalent.Web.Modules.Settings.SalesTax.LookUp;
using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using Serenity.Extensions.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace Indotalent.Sales
{
    [ConnectionKey("Default"), Module("Sales"), TableName("[dbo].[Invoice]")]
    [DisplayName("Invoices"), InstanceName("Invoice")]
    [LookupScript(LookupType = typeof(MultiTenantRowLookupScript<>))]
    [ReadPermission("Sales:Invoice")]
    [ModifyPermission("Sales:Invoice")]
    public sealed class InvoiceRow : LoggingRow<InvoiceRow.RowFields>, IIdRow, INameRow, IMultiTenantRow
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

        [DisplayName("Invoice Date"), NotNull,QuickSearch]
        public DateTime? InvoiceDate
        {
            get => fields.InvoiceDate[this];
            set => fields.InvoiceDate[this] = value;
        }

        [DisplayName("Sales Order"), ForeignKey("[dbo].[SalesOrder]", "Id"), LeftJoin("jSalesOrder"), TextualField("SalesOrderNumber"),ReadOnly(true)]
        [LookupEditor(typeof(SalesOrderRow))]
        [Updatable(false)]
        
        public Int32? SalesOrderId
        {
            get => fields.SalesOrderId[this];
            set => fields.SalesOrderId[this] = value;
        }

        [DisplayName("Sales Order"), Expression("jSalesOrder.[Number]"), MinSelectLevel(SelectLevel.List)]
        [Insertable(false), Updatable(false)]
        public String SalesOrderNumber
        {
            get => fields.SalesOrderNumber[this];
            set => fields.SalesOrderNumber[this] = value;
        }


        [DisplayName("Is  Generated"), NotNull, NotMapped]
        [DefaultValue(0)]
        public bool? IsGenerated
        {
            get => fields.IsGenerated[this];
            set => fields.IsGenerated[this] = value;
        }
        [DisplayName("Dispatch Through"), Size(1000), Expression("jSalesOrder.[DispatchedBy]")]
        public String DispatchedBy
        {
            get => fields.DispatchedBy[this];
            set => fields.DispatchedBy[this] = value;
        }
        [DisplayName("Dispatched To"), Size(1000), Expression("jSalesOrder.[DispatchedTo]")]
        public String DispatchedTo
        {
            get => fields.DispatchedTo[this];
            set => fields.DispatchedTo[this] = value;
        }
        [DisplayName("Place of Supply"), Size(200), Expression("jSalesOrder.[PlaceOfSupply]")]
        public String PlaceOfSupply
        {
            get => fields.PlaceOfSupply[this];
            set => fields.PlaceOfSupply[this] = value;
        }
        [DisplayName("Is Invoice Generated"), NotNull, NotMapped]
        [DefaultValue(0)]
        public bool? IsInvoiceGenerated
        {
            get => fields.IsInvoiceGenerated[this];
            set => fields.IsInvoiceGenerated[this] = value;
        }
        [DisplayName("Is Invoice Payment Generated"), NotNull]
        [DefaultValue(0)]
        public bool? IsInvoicePaymentGenerated
        {
            get => fields.IsInvoicePaymentGenerated[this];
            set => fields.IsInvoicePaymentGenerated[this] = value;
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

        [DisplayName("TDS"), ForeignKey("[dbo].[SalesTax]", "Id"), TextualField("SalesTaxName")]
        [LookupEditor(typeof(SalesTaxTDSLookup), InplaceAdd = true, DialogType = "Indotalent.Settings.SalesTaxDialog")]
        public Int32? TDS
        {
            get => fields.TDS[this];
            set => fields.TDS[this] = value;

        }

        [DisplayName("TCS"), ForeignKey("[dbo].[SalesTax]", "Id"), TextualField("SalesTaxName")]
        [LookupEditor(typeof(SalesTaxTCSLookup), InplaceAdd = true, DialogType = "Indotalent.Settings.SalesTaxDialog")]
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


        [DisplayName("Customer"), Expression("jSalesOrder.[CustomerId]"), ForeignKey("[dbo].[Customer]", "Id"), LeftJoin("jCustomer")]
        public Int32? CustomerId
        {
            get => fields.CustomerId[this];
            set => fields.CustomerId[this] = value;
        }

        [DisplayName("Customer Name"), Expression("jCustomer.[Name]"), MinSelectLevel(SelectLevel.List)]
        [Insertable(false), Updatable(false)]
        public String CustomerName
        {
            get => fields.CustomerName[this];
            set => fields.CustomerName[this] = value;
        }

        [DisplayName("Customer Street"), Expression("jCustomer.[Street]"), MinSelectLevel(SelectLevel.List)]
        [Insertable(false), Updatable(false)]
        public String CustomerStreet
        {
            get => fields.CustomerStreet[this];
            set => fields.CustomerStreet[this] = value;
        }

        [DisplayName("Customer City"), Expression("jCustomer.[City]"), MinSelectLevel(SelectLevel.List)]
        [Insertable(false), Updatable(false)]
        public String CustomerCity
        {
            get => fields.CustomerCity[this];
            set => fields.CustomerCity[this] = value;
        }

        [DisplayName("Customer Country"), Expression("jCustomer.[CountryId]"), ForeignKey("[dbo].[Country]", "Id"), LeftJoin("jCountry"), TextualField("CountryName")]
        [Insertable(false), Updatable(false)]
        public Int32? CustomerCountry
        {
            get => fields.CustomerCountry[this];
            set => fields.CustomerCountry[this] = value;
        }

        [DisplayName("Customer Country"), Expression("jCountry.[Name]")]
        [Insertable(false), Updatable(false)]
        public String CustomerCountryName
        {
            get => fields.CustomerCountryName[this];
            set => fields.CustomerCountryName[this] = value;
        }

        [DisplayName("Customer State"), Expression("jCustomer.[StateId]"), ForeignKey("[dbo].[State]", "Id"), LeftJoin("jState"), TextualField("StateName")]
        [Insertable(false), Updatable(false)]
        public Int32? CustomerState
        {
            get => fields.CustomerState[this];
            set => fields.CustomerState[this] = value;
        }

        [DisplayName("Customer State"), Expression("jState.[Name]")]
        [Insertable(false), Updatable(false)]
        public String CustomerStateName
        {
            get => fields.CustomerStateName[this];
            set => fields.CustomerStateName[this] = value;
        }

        [DisplayName("Customer Zip Code"), Expression("jCustomer.[ZipCode]"), MinSelectLevel(SelectLevel.List)]
        [Insertable(false), Updatable(false)]
        public String CustomerZipCode
        {
            get => fields.CustomerZipCode[this];
            set => fields.CustomerZipCode[this] = value;
        }

        [DisplayName("Customer Phone"), Expression("jCustomer.[Phone]"), MinSelectLevel(SelectLevel.List)]
        [Insertable(false), Updatable(false)]
        public String CustomerPhone
        {
            get => fields.CustomerPhone[this];
            set => fields.CustomerPhone[this] = value;
        }

        [DisplayName("Customer Email"), Expression("jCustomer.[Email]"), MinSelectLevel(SelectLevel.List)]
        [Insertable(false), Updatable(false)]
        public String CustomerEmail
        {
            get => fields.CustomerEmail[this];
            set => fields.CustomerEmail[this] = value;
        }

        [DisplayName("Items"), MasterDetailRelation(foreignKey: "InvoiceId"), MinSelectLevel(SelectLevel.List), NotMapped]
        public List<InvoiceDetailRow> ItemList
        {
            get => fields.ItemList[this];
            set => fields.ItemList[this] = value;
        }

        [DisplayName("Invoice Payments"), MasterDetailRelation(foreignKey: "InvoiceId"), NotMapped]
        public List<InvoicePaymentRow> InvoicePaymentList
        {
            get => fields.InvoicePaymentList[this];
            set => fields.InvoicePaymentList[this] = value;
        }

        [DisplayName("Sales"), Size(200)]
        public String SalesGroup
        {
            get => fields.SalesGroup[this];
            set => fields.SalesGroup[this] = value;
        }

        [DisplayName("CustomerPO Number"),ReadOnly(true)]
        public String CustomerPONumber
        {
            get => fields.CustomerPONumber[this];
            set => fields.CustomerPONumber[this] = value;
        }

        [DisplayName("PONumber Date")]
        public DateTime? PONumberDate
        {
            get => fields.PONumberDate[this];
            set => fields.PONumberDate[this] = value;
        }

        [DisplayName("Pyament Term")]
        public String PyamentTerm
        {
            get => fields.PyamentTerm[this];
            set => fields.PyamentTerm[this] = value;
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

        [DisplayName("Tenant State"), Expression("jTenant.[StateId]")]
        [Insertable(false), Updatable(false)]
        public Int32? TenantState
        {
            get => fields.TenantState[this];
            set => fields.TenantState[this] = value;
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

        public InvoiceRow()
            : base()
        {
        }

        public InvoiceRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : LoggingRowFields
        {
            public Int32Field Id;
            public StringField Number;
            public StringField Description;
            public DateTimeField InvoiceDate;
            public BooleanField IsGenerated;
            public BooleanField IsInvoiceGenerated;
            public Int32Field SalesOrderId;
            public StringField SalesOrderNumber;
            public DoubleField SubTotal;
            public BooleanField IsInvoicePaymentGenerated;
            public DoubleField Discount;
            public DoubleField BeforeTax;
            public DoubleField TaxAmount;
            public DoubleField Total;
            public DoubleField OtherCharge;
            public Int32Field TDS;
            public Int32Field TCS;
            public Int32Field TaxType;
            public DoubleField TcsTdsTaxAmount;
            public DoubleField FinalTotalPostTDS_TCS;

            public StringField DispatchedBy;
            public StringField DispatchedTo;
            public StringField PlaceOfSupply;

            public Int32Field CustomerId;
            public StringField CustomerName;
            public StringField CustomerStreet;
            public StringField CustomerCity;
             public Int32Field CustomerCountry;
            public StringField CustomerCountryName;
            public Int32Field CustomerState;
            public StringField CustomerStateName;
            public StringField CustomerZipCode;
            public StringField CustomerPhone;
            public StringField CustomerEmail;
            public StringField SalesGroup;

            public StringField CurrencyName;

            public StringField CustomerPONumber;
            public DateTimeField PONumberDate;
            public StringField PyamentTerm;

            public Int32Field TenantId;
            public StringField TenantName;
            public Int32Field TenantState;

            public RowListField<InvoiceDetailRow> ItemList;
            public RowListField<InvoicePaymentRow> InvoicePaymentList;

        }
    }
}
