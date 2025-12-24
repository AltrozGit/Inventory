using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using Serenity.Extensions.Entities;
using System;
using System.ComponentModel;
using System.IO;
using Indotalent.Web.Modules.Merchandise.Product;

namespace Indotalent.Sales
{
    [ConnectionKey("Default"), Module("Sales"), TableName("[dbo].[SalesOrderDetail]")]
    [DisplayName("Item Details"), InstanceName("Item Detail")]
    [ReadPermission("Sales:SalesOrder")]
    [ModifyPermission("Sales:SalesOrder")]
    [LookupScript(LookupType = typeof(MultiTenantRowLookupScript<>))]
    public sealed class SalesOrderDetailRow : LoggingRow<SalesOrderDetailRow.RowFields>, IIdRow, INameRow, IMultiTenantRow
    {
        [DisplayName("Id"), Identity, IdProperty]
        public Int32? Id
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
        }

        [DisplayName("Sales Order"), PrimaryKey, Updatable(false), ForeignKey("[dbo].[SalesOrder]", "Id"), LeftJoin("jSalesOrder"), TextualField("SalesOrderNumber")]
        public Int32? SalesOrderId
        {
            get => fields.SalesOrderId[this];
            set => fields.SalesOrderId[this] = value;
        }

          [DisplayName("Product"), PrimaryKey, NotNull, ForeignKey("[dbo].[Product]", "Id"), LeftJoin("jProduct"), TextualField("ProductName")]
             //[LookupEditor(typeof(Merchandise.ProductRow))]
           [LookupEditor(typeof(ProductLookup), InplaceAdd = true, DialogType = "Indotalent.Merchandise.ProductDialog")]
    public Int32? ProductId
        {
            get => fields.ProductId[this];
            set => fields.ProductId[this] = value;
        }

        [DisplayName("HSN No/ SAC No"), Size(100), Expression("jProduct.[InternalCode]"), MinSelectLevel(SelectLevel.List)]
        public String InternalCode
        {
            get => fields.InternalCode[this];
            set => fields.InternalCode[this] = value;
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

        [DisplayName("Is Invoice Generated"), NotNull,NotMapped]
        [DefaultValue(0)]
        public bool? IsInvoiceGenerated
        {
            get => fields.IsInvoiceGenerated[this];
            set => fields.IsInvoiceGenerated[this] = value;
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

        [DisplayName("Tenant State"), Expression("jTenant.[StateId]")]
        [Insertable(false), Updatable(false)]
        public Int32? TenantState
        {
            get => fields.TenantState[this];
            set => fields.TenantState[this] = value;
        }

        public Int32Field TenantIdField
        {
            get { return Fields.TenantId; }
        }


        public SalesOrderDetailRow()
            : base()
        {
        }

        public SalesOrderDetailRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : LoggingRowFields
        {
            public Int32Field Id;
            public Int32Field SalesOrderId;
            public Int32Field ProductId;
            public DoubleField Price;
            public DoubleField Qty;
            public BooleanField IsInvoiceGenerated;
            public StringField InternalCode;
            public DoubleField SubTotal;
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
            public Int32Field TenantState;
        }
    }
}
