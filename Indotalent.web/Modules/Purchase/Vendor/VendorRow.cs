using Indotalent.Settings;
using Indotalent.Web.Modules.Purchase.PaymentTerm;

//using Indotalent.Web.Modules.Purchase.PaymentTerm;
using Indotalent.Web.Modules.Purchase.Vendor;
using Indotalent.Web.Modules.Settings.State;
using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using Serenity.Extensions.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace Indotalent.Purchase
{
    [ConnectionKey("Default"), Module("Purchase"), TableName("[dbo].[Vendor]")]
    [DisplayName("Vendors"), InstanceName("Vendor")]
    [LookupScript(LookupType = typeof(MultiTenantRowLookupScript<>))]
    [ReadPermission("Purchase:Vendor")]
    [ModifyPermission("Purchase:Vendor")]

	public sealed class VendorRow : LoggingRow<VendorRow.RowFields>, IIdRow, INameRow, IMultiTenantRow
    {
        [DisplayName("Id"), Identity, IdProperty]
        public Int32? Id
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
        }

        [DisplayName("Name"), Size(200), NotNull, QuickSearch, NameProperty, DefaultValue("")]
        public String Name
        {
            get => fields.Name[this];
            set => fields.Name[this] = value;
        }

        [DisplayName("Address"), Size(200),NotMapped]
        public String Address
        {
            get => fields.Address[this];
            set => fields.Address[this] = value;
        }

        [DisplayName("Description"), Size(1000), QuickSearch]
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


        [DisplayName("Country"), NotNull,ForeignKey("Country", "Id"), LookupInclude, LeftJoin("jCountry"), TextualField("CountryName"), QuickSearch]
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



        [DisplayName("State"), NotNull,ForeignKey("State", "Id"), LookupInclude, LeftJoin("jState"), TextualField("StateName"), QuickSearch]
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



        [DisplayName("Zip Code"), Size(10)]
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

		[DisplayName("Payment Term"), NotNull, ForeignKey("[dbo].[PaymentTerm]", "Id"), LeftJoin("jPaymentTerm"), TextualField("PaymentTermTermName")]
		[LookupEditor(typeof(PaymentTermLookup), InplaceAdd = true, DialogType = "Indotalent.Purchase.PaymentTermDialog")]
		public Int32? PaymentTermId
		{
			get => fields.PaymentTermId[this];
			set => fields.PaymentTermId[this] = value;
		}
        [DisplayName("Payment Term"), Expression("jPaymentTerm.[TermName]"), QuickSearch]
		[LookupEditor(typeof(PaymentTermLookup), InplaceAdd = true, DialogType = "Indotalent.Purchase.PaymentTermDialog")]
		public String TermName
		{
			get => fields.TermName[this];
			set => fields.TermName[this] = value;
		}
		
		[DisplayName("GST Number"), Size(200)]
        public String GSTNumber
        {
            get => fields.GSTNumber[this];
            set => fields.GSTNumber[this] = value;
        }

        [DisplayName("Bank Name"), Size(200), QuickSearch]
        public String BankName
        {
            get => fields.BankName[this];
            set => fields.BankName[this] = value;
        }
        [DisplayName("Bank Branch"), Size(200)]
        public String BankBranch
        {
            get => fields.BankBranch[this];
            set => fields.BankBranch[this] = value;
        }
        [DisplayName("Account Number"), Size(200)]
        public String AccountNumber
        {
            get => fields.AccountNumber[this];
            set => fields.AccountNumber[this] = value;
        }
        [DisplayName("IFSC Code"), Size(200)]
        public String IFSCCode
        {
            get => fields.IFSCCode[this];
            set => fields.IFSCCode[this] = value;
        }
        [DisplayName("Pan Number"), Size(200), QuickSearch]
        public String PanNumber
        {
            get => fields.PanNumber[this];
            set => fields.PanNumber[this] = value;
        }
        [DisplayName("Contacts"), MasterDetailRelation(foreignKey: "VendorId"), NotMapped]
        public List<VendorContactRow> ContactList
        {
            get => fields.ContactList[this];
            set => fields.ContactList[this] = value;
        }
        [DisplayName("Logo"), Size(200), ImageUploadEditor(FilenameFormat = "Image/Vendor/~")]
        public String Logo
        {
            get => fields.Logo[this];
            set => fields.Logo[this] = value;
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

        public Int32Field TenantIdField
        {
            get { return Fields.TenantId; }
        }

        public VendorRow()
            : base()
        {
        }

        public VendorRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : LoggingRowFields
        {
            public Int32Field Id;
            public StringField Name;
            public StringField Address;
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
			public Int32Field PaymentTermId;
			public StringField TermName;

			public StringField GSTNumber;
            public StringField BankName;
            public StringField BankBranch;
            public StringField AccountNumber;
            public StringField IFSCCode;
            public StringField PanNumber;
            public Int32Field TenantId;
            public StringField TenantName;
            public StringField Logo;
            public RowListField<VendorContactRow> ContactList;
        }
    }
}
