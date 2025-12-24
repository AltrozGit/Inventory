using Indotalent.Web.Modules.Projects.Project;
using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using Serenity.Extensions.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using Indotalent.Web.Modules.Sales.Customer;
using Indotalent.Web.Modules.Sales.SalesChannel;
using Indotalent.Web.Modules.Settings.SalesTax.LookUp;
using Indotalent.Web.Modules.Sales.SalesOrder;

namespace Indotalent.Sales
{
    [ConnectionKey("Default"), Module("Sales"), TableName("[dbo].[SalesOrder]")]
    [DisplayName("Customer Order"), InstanceName("Customer Order")]
    [LookupScript(LookupType = typeof(MultiTenantRowLookupScript<>))]
    [ReadPermission("Sales:SalesOrder")]
    [ModifyPermission("Sales:SalesOrder")]
    public sealed class SalesOrderRow : LoggingRow<SalesOrderRow.RowFields>, IIdRow, INameRow, IMultiTenantRow
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

        [DisplayName("Order Date"), NotNull,QuickSearch]
        public DateTime? OrderDate
        {
            get => fields.OrderDate[this];
            set => fields.OrderDate[this] = value;
        }
        [DisplayName("Dispatch Through"), Size(1000)]
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
        [DisplayName("Place of Supply"), Size(200)]
        public String PlaceOfSupply
        {
            get => fields.PlaceOfSupply[this];
            set => fields.PlaceOfSupply[this] = value;
        }
        [DisplayName("Sales Channel"), NotNull, ForeignKey("[dbo].[SalesChannel]", "Id"), LeftJoin("jSalesChannel"), TextualField("SalesChannelName")]
        //[LookupEditor(typeof(SalesChannelRow), InplaceAdd = true)]
        [LookupEditor(typeof(SalesChannelLookup), InplaceAdd = true, DialogType = "Indotalent.Sales.SalesChannelDialog")]
        public Int32? SalesChannelId
        {
            get => fields.SalesChannelId[this];
            set => fields.SalesChannelId[this] = value;
        }

        [DisplayName("Sales Channel"), Expression("jSalesChannel.[Name]")]
        [Insertable(false), Updatable(false)]
        public String SalesChannelName
        {
            get => fields.SalesChannelName[this];
            set => fields.SalesChannelName[this] = value;
        }

        [DisplayName("Customer"), NotNull, ForeignKey("[dbo].[Customer]", "Id"), LeftJoin("jCustomer"), TextualField("CustomerName")]
        //[LookupEditor(typeof(CustomerRow), InplaceAdd = true)]
        [LookupEditor(typeof(CustomerLookup), InplaceAdd = true, DialogType = "Indotalent.Sales.CustomerDialog")]
        public Int32? CustomerId
        {
            get => fields.CustomerId[this];
            set => fields.CustomerId[this] = value;
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

        [DisplayName("Customer Name"), Expression("jCustomer.[Name]")]
        [Insertable(false), Updatable(false)]
        public String CustomerName
        {
            get => fields.CustomerName[this];
            set => fields.CustomerName[this] = value;
        }

        [DisplayName("Customer Street"), Expression("jCustomer.[Street]")]
        [Insertable(false), Updatable(false)]
        public String CustomerStreet
        {
            get => fields.CustomerStreet[this];
            set => fields.CustomerStreet[this] = value;
        }

        [DisplayName("Customer City"), Expression("jCustomer.[City]")]
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

        [DisplayName("Tenant State"), Expression("jTenant.[StateId]")]
        [Insertable(false), Updatable(false)]
        public Int32? TenantState
        {
            get => fields.TenantState[this];
            set => fields.TenantState[this] = value;
        }


        [DisplayName("Customer Zip Code"), Expression("jCustomer.[ZipCode]")]
        [Insertable(false), Updatable(false)]
        public String CustomerZipCode
        {
            get => fields.CustomerZipCode[this];
            set => fields.CustomerZipCode[this] = value;
        }

        [DisplayName("Customer Phone"), Expression("jCustomer.[Phone]")]
        [Insertable(false), Updatable(false)]
        public String CustomerPhone
        {
            get => fields.CustomerPhone[this];
            set => fields.CustomerPhone[this] = value;
        }

        [DisplayName("Customer Email"), Expression("jCustomer.[Email]")]
        [Insertable(false), Updatable(false)]
        public String CustomerEmail
        {
            get => fields.CustomerEmail[this];
            set => fields.CustomerEmail[this] = value;
        }

        [DisplayName("Customer Billing Address"), Expression("jCustomer.[BillingAddress]")]
        [Insertable(false), Updatable(false)]
        public String BillingAddress
        {
            get => fields.BillingAddress[this];
            set => fields.BillingAddress[this] = value;
        }
        [DisplayName("Customer Shipping Address"),  Expression("jCustomer.[ShippingAddress]")]
        [Insertable(false), Updatable(false)]
        public String ShippingAddress
        {
            get => fields.ShippingAddress[this];
            set => fields.ShippingAddress[this] = value;
        }

        [DisplayName("Items"), MasterDetailRelation(foreignKey: "SalesOrderId"), NotMapped]
        public List<SalesOrderDetailRow> ItemList
        {
            get => fields.ItemList[this];
            set => fields.ItemList[this] = value;
        }

        [DisplayName("Invoices"), MasterDetailRelation(foreignKey: "SalesOrderId"), NotMapped]
        public List<InvoiceRow> InvoiceList
        {
            get => fields.InvoiceList[this];
            set => fields.InvoiceList[this] = value;
        }

        [DisplayName("Sales Group"), Size(200)]
        public String SalesGroup
        {
            get => fields.SalesGroup[this];
            set => fields.SalesGroup[this] = value;
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

        [DisplayName("Is Invoice Generated"), NotNull]
        [DefaultValue(0)]
        public bool? IsInvoiceGenerated
        {
            get => fields.IsInvoiceGenerated[this];
            set => fields.IsInvoiceGenerated[this] = value;
        }
        public Int32Field TenantIdField
        {
            get { return Fields.TenantId; }
        }

        public SalesOrderRow()
            : base()
        {
        }

        public SalesOrderRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : LoggingRowFields
        {
            public Int32Field Id;
            public StringField Number;
            public StringField SalesGroup;
            public StringField Description;
            public DateTimeField OrderDate;
            public Int32Field CustomerId;
            public DoubleField SubTotal;
            public DoubleField Discount;
            public DoubleField BeforeTax;
            public DoubleField TaxAmount;
            public BooleanField IsInvoiceGenerated;
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
           

            public StringField CustomerName;
            public StringField CustomerStreet;
            public StringField CustomerCity;
            public Int32Field CustomerCountry;
            public StringField CustomerCountryName;
            public Int32Field CustomerState;
            public StringField CustomerStateName;
            public Int32Field TenantState;
            public StringField CustomerZipCode;
            public StringField CustomerPhone;
            public StringField CustomerEmail;
            public Int32Field SalesChannelId;
            public StringField SalesChannelName;

            public StringField CurrencyName;
            public Int32Field TenantId;
            public StringField TenantName;

            public RowListField<SalesOrderDetailRow> ItemList;
            public RowListField<InvoiceRow> InvoiceList;
            public StringField BillingAddress;
            public StringField ShippingAddress;
        }
    }
}
