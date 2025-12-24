using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;
using System.IO;
using Indotalent.Web.Modules.Merchandise.Product;
using Indotalent.Web.Modules.Projects.Project;
using static MVC.Views.Purchase;

namespace Indotalent.Bills
{
    [ConnectionKey("Default"), Module("Bills"), TableName("[dbo].[BillDetail]")]
    [DisplayName("Item Detail"), InstanceName("Item Detail")]
    [ReadPermission("Bills:BillDetail")]
    [ModifyPermission("Bills:BillDetail")]
    [LookupScript(LookupType = typeof(MultiTenantRowLookupScript<>))]
    public sealed class BillDetailRow : Row<BillDetailRow.RowFields>, IIdRow, INameRow, IMultiTenantRow
    {
        [DisplayName("Id"), Identity, IdProperty]
        public Int32? Id
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
        }

        [DisplayName("Bill"), PrimaryKey, Updatable(false), NotNull, ForeignKey("[dbo].[Bill]", "Id"), LeftJoin("jBill"), TextualField("BillNumber")]
        public Int32? BillId
        {
            get => fields.BillId[this];
            set => fields.BillId[this] = value;
        }

        [DisplayName("Product"), PrimaryKey, NotNull, ForeignKey("[dbo].[Product]", "Id"), LeftJoin("jProduct"), TextualField("ProductName")]
        [LookupEditor(typeof(ProductLookup), InplaceAdd = true, DialogType = "Indotalent.Merchandise.ProductDialog")]
        public Int32? ProductId
        {
            get => fields.ProductId[this];
            set => fields.ProductId[this] = value;
        }

        [DisplayName("HSN No/ SAC No"), Size(100)]
        public String InternalCode
        {
            get => fields.InternalCode[this];
            set => fields.InternalCode[this] = value;
        }

        [DisplayName("Is Bill Payment Generated"), NotNull, NotMapped]
        [DefaultValue(0)]
        public bool? IsBillPaymentGenerated
        {
            get => fields.IsBillPaymentGenerated[this];
            set => fields.IsBillPaymentGenerated[this] = value;
        }


        [DisplayName("Product"), Expression("jProduct.[Name]"), MinSelectLevel(SelectLevel.List), NameProperty]
        public String ProductName
        {
            get => fields.ProductName[this];
            set => fields.ProductName[this] = value;
        }

        [DisplayName("Price"), NotNull, DecimalEditor(Decimals = 2, MinValue = 0), DisplayFormat("#,##0.##")]
        [DefaultValue(0)]
        public Double? Price
        {
            get => fields.Price[this];
            set => fields.Price[this] = value;
        }

        [DisplayName("Qty"), NotNull]
        [DefaultValue(1)]
        public Double? Qty
        {
            get => fields.Qty[this];
            set => fields.Qty[this] = value;
        }

        [DisplayName("Sub Total"), NotNull, DecimalEditor(Decimals = 2, MinValue = 0), DisplayFormat("#,##0.##")]
        [DefaultValue(0)]
        public Double? SubTotal
        {
            get => fields.SubTotal[this];
            set => fields.SubTotal[this] = value;
        }

        [DisplayName("Discount"), NotNull, DecimalEditor(Decimals = 2, MinValue = 0), DisplayFormat("#,##0.##")]
        [DefaultValue(0)]
        public Double? Discount
        {
            get => fields.Discount[this];
            set => fields.Discount[this] = value;
        }

        [DisplayName("Before Tax"), NotNull, DecimalEditor(Decimals = 2, MinValue = 0), DisplayFormat("#,##0.##")]
        [DefaultValue(0)]
        public Double? BeforeTax
        {
            get => fields.BeforeTax[this];
            set => fields.BeforeTax[this] = value;
        }

        [DisplayName("GST%"), NotNull]
        [DefaultValue(0)]
        public Double? TaxPercentage
        {
            get => fields.TaxPercentage[this];
            set => fields.TaxPercentage[this] = value;
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

        [DisplayName("SGSTAmount")]
        public Double? SGSTAmount
        {
            get => fields.SGSTAmount[this];
            set => fields.SGSTAmount[this] = value;

        }


        [DisplayName("CGSTAmount")]
        public Double? CGSTAmount
        {
            get => fields.CGSTAmount[this];
            set => fields.CGSTAmount[this] = value;

        }

        [DisplayName("IGSTAmount")]
        public Double? IGSTAmount
        {
            get => fields.IGSTAmount[this];
            set => fields.IGSTAmount[this] = value;

        }

        [DisplayName("Tax Amount"), NotNull, DecimalEditor(Decimals = 2, MinValue = 0), DisplayFormat("#,##0.##")]
        [DefaultValue(0)]
        public Double? TaxAmount
        {
            get => fields.TaxAmount[this];
            set => fields.TaxAmount[this] = value;
        }

        [DisplayName("Total"), NotNull, DecimalEditor(Decimals = 2, MinValue = 0), DisplayFormat("#,##0.##")]
        [DefaultValue(0)]
        public Double? Total
        {
            get => fields.Total[this];
            set => fields.Total[this] = value;
        }

        [DisplayName("Tenant"), ForeignKey("Tenant", "TenantId"), LeftJoin("jTenant")]
        [Insertable(false), Updatable(false)]
        public Int32? TenantId
        {
            get { return Fields.TenantId[this]; }
            set { Fields.TenantId[this] = value; }
        }

        [DisplayName("Tenant"), Expression("jTenant.TenantName"), MinSelectLevel(SelectLevel.List)]
        public String TenantName
        {
            get { return Fields.TenantName[this]; }
            set { Fields.TenantName[this] = value; }
        }

        [DisplayName("Quantity Of Bill Created"), NotMapped]
        [DefaultValue(0)]
        public Int32? QuanityofBillCreated
        {
            get => fields.QuanityofBillCreated[this];
            set => fields.QuanityofBillCreated[this] = value;
        }

        [DisplayName("PurchaseReceiptId")]
       
        public Int32? PurchaseReceiptId
        {
            get => fields.PurchaseReceiptId[this];
            set => fields.PurchaseReceiptId[this] = value;
        }

        [DisplayName("PurchaseOrderId")]

        public Int32? PurchaseOrderId
        {
            get => fields.PurchaseOrderId[this];
            set => fields.PurchaseOrderId[this] = value;
        }

        public Int32Field TenantIdField
        {
            get { return Fields.TenantId; }
        }

        public BillDetailRow()
            : base()
        {
        }

        public BillDetailRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field Id;
            public Int32Field BillId;
            public Int32Field ProductId;
            public DoubleField Price;
            public DoubleField Qty;
            public DoubleField SubTotal;
            public StringField InternalCode;
            public BooleanField IsBillPaymentGenerated;
            public DoubleField Discount;
            public DoubleField BeforeTax;
            public DoubleField TaxPercentage;
            public DoubleField SGST;
            public DoubleField CGST;
            public DoubleField IGST;
            public DoubleField SGSTAmount;
            public DoubleField CGSTAmount;
            public DoubleField IGSTAmount;
            public DoubleField TaxAmount;
            public DoubleField Total;
            public StringField ProductName;
            public Int32Field TenantId;
            public StringField TenantName;
            public Int32Field QuanityofBillCreated;

            public Int32Field PurchaseReceiptId;

            public Int32Field PurchaseOrderId;
        }
    }
}

