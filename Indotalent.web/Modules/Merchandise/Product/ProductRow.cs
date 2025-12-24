using Indotalent.Web.Modules.Merchandise.HSN;
using Indotalent.Web.Modules.Merchandise.Brand;
using Indotalent.Web.Modules.Merchandise.Category;
using Indotalent.Web.Modules.Merchandise.Colour;
using Indotalent.Web.Modules.Merchandise.Flavour;
using Indotalent.Web.Modules.Merchandise.Product;
using Indotalent.Web.Modules.Merchandise.SAC;
using Indotalent.Web.Modules.Merchandise.Size;
using Indotalent.Web.Modules.Merchandise.Uom;
using Indotalent.Web.Modules.Settings.PurchaseTax.LookUp;
using Indotalent.Web.Modules.Settings.SalesTax.LookUp;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using Serenity.Extensions.Entities;
using System;
using System.ComponentModel;

namespace Indotalent.Merchandise
{
    [ConnectionKey("Default"), Module("Merchandise"), TableName("[dbo].[Product]")]
    [DisplayName("Products"), InstanceName("Product")]
    [LookupScript(LookupType = typeof(MultiTenantRowLookupScript<>))]
    [ReadPermission("Merchandise:Product")]
    [ModifyPermission("Merchandise:Product")]
    public sealed class ProductRow : LoggingRow<ProductRow.RowFields>, IIdRow, INameRow, IMultiTenantRow
    {
        [DisplayName("Id"), Identity, IdProperty]
        public Int32? Id
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
        }

        [DisplayName("Name"), Size(200), NotNull, QuickSearch, NameProperty]
        public String Name
        {
            get => fields.Name[this];
            set => fields.Name[this] = value;
        }

        [DisplayName("Description"), Size(1000)]
        public String Description
        {
            get => fields.Description[this];
            set => fields.Description[this] = value;
        }

        [DisplayName("Picture"), Size(200), ImageUploadEditor(FilenameFormat = "Image/Product/~")]
        public String Picture
        {
            get => fields.Picture[this];
            set => fields.Picture[this] = value;
        }


        [DisplayName("HSN No/ SAC No"), Size(100)]
        public String InternalCode
        {
            get => fields.InternalCode[this];
            set => fields.InternalCode[this] = value;
        }

       
        [DisplayName("HSN No"), ForeignKey("[dbo].[HSN]", "Id"), LeftJoin("jHsn"), TextualField("HsnName")]
        [LookupEditor(typeof(HSNRow), InplaceAdd = true, DialogType = "Indotalent.Merchandise.HSNDialog")]
        public Int32? HsnId
        {
            get => fields.HsnId[this];
            set => fields.HsnId[this] = value;
        }



        //[DisplayName("HSN Code"), Expression("jHsn.[HSN Code]"), QuickSearch]

        //public String HsnName
        //{
        //    get => fields.HsnName[this];
        //    set => fields.HsnName[this] = value;
        //}

        [DisplayName("SAC No"), ForeignKey("[dbo].[SAC]", "Id"), LeftJoin("jSac"), TextualField("SacName")]
        [LookupEditor(typeof(SACRow), InplaceAdd = true, DialogType = "Indotalent.Merchandise.SACDialog")]
        public Int32? SacId
        {
            get => fields.SacId[this];
            set => fields.SacId[this] = value;
        }

        // [DisplayName("SAC Code"), Expression("jSac.[SAC Code]"), QuickSearch]
        // public String SacName
        // {
        //    get => fields.SacName[this];
        //    set => fields.SacName[this] = value;
        // }

        [DisplayName("Barcode"), Size(100)]
        public String Barcode
        {
            get => fields.Barcode[this];
            set => fields.Barcode[this] = value;
        }

        [DisplayName("Uom"), NotNull, ForeignKey("[dbo].[Uom]", "Id"), LeftJoin("jUom"), TextualField("UomName"), QuickSearch]
        [LookupEditor(typeof(UomLookup), InplaceAdd = true, DialogType = "Indotalent.Merchandise.UomDialog")]
        public Int32? UomId
        {
            get => fields.UomId[this];
            set => fields.UomId[this] = value;
        }

        [DisplayName("Brand"), ForeignKey("[dbo].[Brand]", "Id"), LeftJoin("jBrand"), TextualField("BrandName"), QuickSearch]
        [LookupEditor(typeof(BrandLookup), InplaceAdd = true, DialogType = "Indotalent.Merchandise.BrandDialog")]
        public Int32? BrandId
        {
            get => fields.BrandId[this];
            set => fields.BrandId[this] = value;
        }

        [DisplayName("Category"), NotNull, ForeignKey("[dbo].[Category]", "Id"), LeftJoin("jCategory"), TextualField("CategoryName"), QuickSearch]
        [LookupEditor(typeof(CategoryLookup), InplaceAdd = true, DialogType = "Indotalent.Merchandise.CategoryDialog")]
        public Int32? CategoryId
        {
            get => fields.CategoryId[this];
            set => fields.CategoryId[this] = value;
        }

        [DisplayName("Size"), ForeignKey("[dbo].[Size]", "Id"), LeftJoin("jSize"), TextualField("SizeName"), QuickSearch]
        [LookupEditor(typeof(SizeLookup), InplaceAdd = true, DialogType = "Indotalent.Merchandise.SizeDialog")]
        public Int32? SizeId
        {
            get => fields.SizeId[this];
            set => fields.SizeId[this] = value;
        }

        [DisplayName("Colour"), ForeignKey("[dbo].[Colour]", "Id"), LeftJoin("jColour"), TextualField("ColourName"), QuickSearch]
        [LookupEditor(typeof(ColourLookup), InplaceAdd = true, DialogType = "Indotalent.Merchandise.ColourDialog")]
        public Int32? ColourId
        {
            get => fields.ColourId[this];
            set => fields.ColourId[this] = value;
        }

        [DisplayName("Flavour"), ForeignKey("[dbo].[Flavour]", "Id"), LeftJoin("jFlavour"), TextualField("FlavourName"), QuickSearch]
        [LookupEditor(typeof(FlavourLookup), InplaceAdd = true, DialogType = "Indotalent.Merchandise.FlavourDialog")]
        public Int32? FlavourId
        {
            get => fields.FlavourId[this];
            set => fields.FlavourId[this] = value;
        }

        [DisplayName("Purchase Price"), NotNull,AlignRight]
        [DefaultValue(0)]
        public Double? PurchasePrice
        {
            get => fields.PurchasePrice[this];
            set => fields.PurchasePrice[this] = value;
        }
        [DisplayName("Product Type"), NotNull]
        [DefaultValue(1)]
        public ProductType? ProductType
        {
            get => (ProductType?)fields.ProductType[this];
            set => fields.ProductType[this] = (Int32?)value;
        }

        [DisplayName("Sales Price"), NotNull]
        [DefaultValue(0)]
        public Double? SalesPrice
        {
            get => fields.SalesPrice[this];
            set => fields.SalesPrice[this] = value;
        }

        [DisplayName("Purchase Tax"), NotNull, ForeignKey("[dbo].[PurchaseTax]", "Id"), LeftJoin("jPurchaseTax"), TextualField("PurchaseTaxName")]
        [LookupEditor(typeof(PurchaseTaxGstLookup), InplaceAdd = true, DialogType = "Indotalent.Settings.PurchaseTaxDialog")]
        public Int32? PurchaseTaxId
        {
            get => fields.PurchaseTaxId[this];
            set => fields.PurchaseTaxId[this] = value;
        }

        [DisplayName("Sales Tax"), NotNull, ForeignKey("[dbo].[SalesTax]", "Id"), LeftJoin("jSalesTax"), TextualField("SalesTaxName")]
        [LookupEditor(typeof(SalesTaxGSTLookup), InplaceAdd = true, DialogType = "Indotalent.Settings.SalesTaxDialog")]
        public Int32? SalesTaxId
        {
            get => fields.SalesTaxId[this];
            set => fields.SalesTaxId[this] = value;
        }

        [DisplayName("Uom"), Expression("jUom.[Name]"), QuickSearch]
        public String UomName
        {
            get => fields.UomName[this];
            set => fields.UomName[this] = value;
        }

        [DisplayName("Brand"), Expression("jBrand.[Name]"), QuickSearch]
        public String BrandName
        {
            get => fields.BrandName[this];
            set => fields.BrandName[this] = value;
        }

        [DisplayName("Category"), Expression("jCategory.[Name]"), QuickSearch]
        public String CategoryName
        {
            get => fields.CategoryName[this];
            set => fields.CategoryName[this] = value;
        }

        [DisplayName("Size"), Expression("jSize.[Name]"), QuickSearch]
        public String SizeName
        {
            get => fields.SizeName[this];
            set => fields.SizeName[this] = value;
        }

        [DisplayName("Colour"), Expression("jColour.[Name]"), QuickSearch]
        public String ColourName
        {
            get => fields.ColourName[this];
            set => fields.ColourName[this] = value;
        }

        [DisplayName("Flavour"), Expression("jFlavour.[Name]"), QuickSearch]
        public String FlavourName
        {
            get => fields.FlavourName[this];
            set => fields.FlavourName[this] = value;
        }

        [DisplayName("Purchase Tax"), Expression("jPurchaseTax.[Name]")]
        public String PurchaseTaxName
        {
            get => fields.PurchaseTaxName[this];
            set => fields.PurchaseTaxName[this] = value;
        }

        [DisplayName("Sales Tax"), Expression("jSalesTax.[Name]")]
        public String SalesTaxName
        {
            get => fields.SalesTaxName[this];
            set => fields.SalesTaxName[this] = value;
        }

        [DisplayName("Minimum Qty"), NotNull, DecimalEditor(MinValue = 0)]
        [DefaultValue(0)]
        public Double? MinimumQty
        {
            get => fields.MinimumQty[this];
            set => fields.MinimumQty[this] = value;
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

        public ProductRow()
            : base()
        {
        }

        public ProductRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : LoggingRowFields
        {
            public Int32Field Id;
            public StringField Name;
            public StringField Description;
            public StringField Picture;
            public StringField InternalCode;
            public Int32Field HsnId;
            //public StringField HsnName;
            public Int32Field SacId;
            //public StringField SacName;
            public StringField Barcode;
            public Int32Field UomId;
            public Int32Field BrandId;
            public Int32Field CategoryId;
            public Int32Field SizeId;
            public Int32Field ColourId;
            public Int32Field FlavourId;
            public DoubleField PurchasePrice;
            public Int32Field ProductType;
            public DoubleField SalesPrice;
            public Int32Field PurchaseTaxId;
            public Int32Field SalesTaxId;
            public StringField UomName;
            public StringField BrandName;
            public StringField CategoryName;
            public StringField SizeName;
            public StringField ColourName;
            public StringField FlavourName;
            public StringField PurchaseTaxName;
            public StringField SalesTaxName;
            public StringField CurrencyName;
            public DoubleField MinimumQty;
            public Int32Field TenantId;
            public StringField TenantName;
        }
    }
}
