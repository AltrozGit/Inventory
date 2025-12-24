using Indotalent.Purchase;
using Indotalent.Sales;
using Indotalent.Web.Modules.Sales.Customer;
using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using Serenity.Extensions.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;


namespace Indotalent.Projects
{
    [ConnectionKey("Default"), Module("Projects"), TableName("[dbo].[Quotation]")]
    [DisplayName("Quotation"), InstanceName("Quotation")]
    [ReadPermission("Projects:Quotation")]
    [ModifyPermission("Projects:Quotation")]
    [LookupScript(LookupType = typeof(MultiTenantRowLookupScript<>))]
    public sealed class QuotationRow : LoggingRow<QuotationRow.RowFields>, IIdRow, INameRow, IMultiTenantRow
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

        [DisplayName("Quotation Date"), NotNull]
        public DateTime? QuotationDate
        {
            get => fields.QuotationDate[this];
            set => fields.QuotationDate[this] = value;
        }

        [DisplayName("Customer"), NotNull, ForeignKey("[dbo].[Customer]", "Id"), LeftJoin("jCustomer"), TextualField("CustomerName")]
        //[LookupEditor(typeof(CustomerRow), InplaceAdd = true)]
        [LookupEditor(typeof(CustomerLookup), InplaceAdd = true, DialogType = "Indotalent.Sales.CustomerDialog")]
        public Int32? CustomerId
        {
            get => fields.CustomerId[this];
            set => fields.CustomerId[this] = value;
        }


        [DisplayName("Project"), NotNull, ForeignKey("[dbo].[Project]", "Id"), LeftJoin("jProject"), TextualField("ProjectName")]
        [LookupEditor(typeof(ProjectRow))]
        [Updatable(false)]
        public Int32? ProjectId
        {
            get => fields.ProjectId[this];
            set => fields.ProjectId[this] = value;
        }

        [DisplayName("Sub Total"), NotNull]
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

        [DisplayName("Before Tax"), NotNull]
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

        [DisplayName("Total"), NotNull, DecimalEditor(Decimals = 2, MinValue = 0), DisplayFormat("#,##0.##")]
        [DefaultValue(0), Insertable(false), Updatable(false)]
        public Double? Total
        {
            get => fields.Total[this];
            set => fields.Total[this] = value;
        }

        [DisplayName("Other Charge"), NotNull]
        [DefaultValue(0)]
        public Double? OtherCharge
        {
            get => fields.OtherCharge[this];
            set => fields.OtherCharge[this] = value;
        }
        [DisplayName("Project Name"), Expression("jProject.[Name]")]
        public String ProjectName
        {
            get => fields.ProjectName[this];
            set => fields.ProjectName[this] = value;
        }
        [DisplayName("Street"), Size(200), Expression("jProject.[Street]")]
        public String Street
        {
            get => fields.Street[this];
            set => fields.Street[this] = value;
        }

        [DisplayName("City"), Size(200), Expression("jProject.[City]")]
        public String City
        {
            get => fields.City[this];
            set => fields.City[this] = value;
        }

        [DisplayName("State"), Size(200), Expression("jProject.[State]")]
        public String State
        {
            get => fields.State[this];
            set => fields.State[this] = value;
        }

        [DisplayName("Zip Code"), Size(10), Expression("jProject.[ZipCode]")]
        public String ZipCode
        {
            get => fields.ZipCode[this];
            set => fields.ZipCode[this] = value;
        }

        [DisplayName("Phone"), Size(50), Expression("jProject.[Phone]")]
        public String Phone
        {
            get => fields.Phone[this];
            set => fields.Phone[this] = value;
        }

        [DisplayName("Email"), Size(200), Expression("jProject.[Email]")]
        public String Email
        {
            get => fields.Email[this];
            set => fields.Email[this] = value;
        }
        [DisplayName("Items"), MasterDetailRelation(foreignKey: "QuotationId"), /*MinSelectLevel(SelectLevel.List),*/ NotMapped]
        public List<QuotationDetailRow> ItemList
        {
            get => fields.ItemList[this];
            set => fields.ItemList[this] = value;
        }






        [DisplayName("Tenant"), ForeignKey("Tenant", "TenantId"), LeftJoin("jTenant")]
        [Insertable(false), Updatable(false)]
        public Int32? TenantId
        {
            get => fields.TenantId[this];
            set => fields.TenantId[this] = value;
        }

        [DisplayName("Tenant"), Expression("jTenant.TenantName"), MinSelectLevel(SelectLevel.List)]
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
        [DisplayName("Customer Shipping Address"), Expression("jCustomer.[ShippingAddress]")]
        [Insertable(false), Updatable(false)]
        public String ShippingAddress
        {
            get => fields.ShippingAddress[this];
            set => fields.ShippingAddress[this] = value;
        }

        public QuotationRow()
            : base()
        {
        }

        public QuotationRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : LoggingRowFields
        {
            public Int32Field Id;
            public StringField Number;
            public StringField Description;
            public StringField ExternalReferenceNumber;
            public Int32Field CustomerId;

            public DateTimeField QuotationDate;
            public Int32Field ProjectId;
            public DoubleField SubTotal;
            public DoubleField Discount;
            public DoubleField BeforeTax;
            public DoubleField TaxAmount;
            public DoubleField Total;
            public DoubleField OtherCharge;
            public StringField CurrencyName;


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
            public StringField BillingAddress;
            public StringField ShippingAddress;

            public Int32Field TenantId;

            public StringField ProjectName;
           
            public RowListField<QuotationDetailRow> ItemList;
            public StringField TenantName;
            public StringField Street;
            public StringField City;
            public StringField State;
            public StringField ZipCode;
            public StringField Phone;
            public StringField Email;

            
        }
    }
}
