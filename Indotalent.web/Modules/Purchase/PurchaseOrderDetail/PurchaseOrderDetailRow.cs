using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using Serenity.Extensions.Entities;
using System;
using System.ComponentModel;
using System.IO;

namespace Indotalent.Purchase
{
    [ConnectionKey("Default"), Module("PurchaseOrder"), TableName("[dbo].[PurchaseOrderDetail]")]
    [DisplayName("Item Details"), InstanceName("Item Detail")]
    [ReadPermission("Purchase:PurchaseOrder")]
    [ModifyPermission("Purchase:PurchaseOrder")]
    [LookupScript(LookupType = typeof(MultiTenantRowLookupScript<>))]
    [InnerJoin("jPurchaseOrder", "[dbo].[PurchaseOrder]", "jPurchaseOrder.Id = T0.PurchaseOrderId")]
    [LeftJoin("jMaterialRequest", "[dbo].[MaterialRequest]", "jPurchaseOrder.MaterialRequestId = jMaterialRequest.Id")]
    [LeftJoin("jMaterialRequestDetail", "[dbo].[MaterialRequestDetail]", "jMaterialRequest.Id = jMaterialRequestDetail.MaterialRequestId " +
        "AND jMaterialRequestDetail.ProductId = T0.ProductId")]
    [LeftJoin("jvwAvailableStock", "[dbo].[vwAvailableStock]", "[T0].[ProductId] = jvwAvailableStock.[ProductId] " +
        "AND jMaterialRequest.[ProjectId] = jvwAvailableStock.[ProjectID] ")]
    //[LeftJoin("jProduct", "dbo.Product", "T0.ProductId = jProduct.Id")]
    public sealed class PurchaseOrderDetailRow : LoggingRow<PurchaseOrderDetailRow.RowFields>, IIdRow, INameRow, IMultiTenantRow
    {
        [DisplayName("Id"), Identity, IdProperty]
        public Int32? Id
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
        }

        [DisplayName("Purchase Order"), PrimaryKey, Updatable(false), TextualField("PurchaseOrderNumber")]
        public Int32? PurchaseOrderId
        {
            get => fields.PurchaseOrderId[this];
            set => fields.PurchaseOrderId[this] = value;
        }

        [DisplayName("Select"), NotMapped]
        public bool? Select
        {
            get => fields.Select[this];
            set => fields.Select[this] = value;
        }

        [DisplayName("Product"), PrimaryKey, NotNull, ForeignKey("[dbo].[Product]", "Id"), LeftJoin("jProduct"), TextualField("ProductName")]
        [LookupEditor(typeof(Merchandise.ProductRow))]
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

        [DisplayName("Description"), Size(1000), Expression("jProduct.[Description]"), MinSelectLevel(SelectLevel.List)]
        public String Description
        {
            get => fields.Description[this];
            set => fields.Description[this] = value;
        }

		[DisplayName("Purchase Tax"), Expression("jProduct.[PurchaseTaxId]"), ForeignKey("[dbo].[PurchaseTax]", "Id"), LeftJoin("jPurchaseTax"), MinSelectLevel(SelectLevel.List)]

		public Int32? PurchaseTaxId
		{
			get => fields.PurchaseTaxId[this];
			set => fields.PurchaseTaxId[this] = value;
		}
		[DisplayName("GST%"), NotNull, DecimalEditor(Decimals = 2, MinValue = 0), DisplayFormat("#,##0.##"), MinSelectLevel(SelectLevel.List)]
		
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

        [DisplayName("Price"), NotNull, DecimalEditor(Decimals = 2, MinValue = 0), DisplayFormat("#,##0.##"),Updatable(true)]
        [DefaultValue(0)]
        //[ReadOnly(true)]
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

        [DisplayName("Quanity Of PO Created"),NotMapped]
        [DefaultValue(0)]
        public Int32? QuanityofPOCreated
        {
            get => fields.QuanityofPOCreated[this];
            set => fields.QuanityofPOCreated[this] = value;
        }

        [DisplayName("MaterialRequestId")]
        [DefaultValue(0)]
        public Int32? MaterialRequestId
        {
            get => fields.MaterialRequestId[this];
            set => fields.MaterialRequestId[this] = value;
        }

       
        [DisplayName("Is Bill Generated"), NotNull, NotMapped]
        [DefaultValue(0)]
        public bool? IsBillGenerated
        {
            get => fields.IsBillGenerated[this];
            set => fields.IsBillGenerated[this] = value;
        }

        [DisplayName("Sub Total"), NotNull, DecimalEditor(Decimals = 2, MinValue = 0), DisplayFormat("#,##0.##")]
        [DefaultValue(0)]
        public Double? SubTotal
        {
            get => fields.SubTotal[this];
            set => fields.SubTotal[this] = value;
        }

        [DisplayName("Discount"), DecimalEditor(Decimals = 2, MinValue = 0), DisplayFormat("#,##0.##")]
        //[DefaultValue(0)]
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

        [DisplayName("Tax Amount"), DecimalEditor(Decimals = 2, MinValue = 0), DisplayFormat("#,##0.##")]
       
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

        //[DisplayName("Request Id"), Expression("jMaterialIssue.[MaterialRequestId]"), TextualField("MaterialRequestNumber")]
        //public Int32? MaterialRequestId
        //{
        //	get => fields.MaterialRequestId[this];
        //	set => fields.MaterialRequestId[this] = value;
        //}

        //[DisplayName("Request Number"), Expression("jMaterialRequest.[Number]"), MinSelectLevel(SelectLevel.List)]
        //[Insertable(false), Updatable(false)]
        //public String MaterialRequestNumber
        //{
        //	get => fields.MaterialRequestNumber[this];
        //	set => fields.MaterialRequestNumber[this] = value;
        //}


        [DisplayName("Quanity Of PR Created")]
        [DefaultValue(0)]
        public Int32? QuanityOfPRCreated
        {
            get => fields.QuanityOfPRCreated[this];
            set => fields.QuanityOfPRCreated[this] = value;
        }

        [DisplayName("IsPRCreated")]
        public Boolean? IsPRCreate
        {
            get => fields.IsPRCreate[this];
            set => fields.IsPRCreate[this] = value;
        }


        [DisplayName("QuanityOfBillCreated")]
        [DefaultValue(0)]
        public Int32? QuanityOfBillCreated
        {
            get => fields.QuanityOfBillCreated[this];
            set => fields.QuanityOfBillCreated[this] = value;
        }

        [DisplayName("IsBillCreated")]
        public Boolean? IsBillCreated
        {
            get => fields.IsBillCreated[this];
            set => fields.IsBillCreated[this] = value;
        }



        [DisplayName("Qty Requested"), Expression("jMaterialRequestDetail.[QtyRequest]"), MinSelectLevel(SelectLevel.List),
			Insertable(false), Updatable(false)]
		public Double? QtyRequest
		{
			get => fields.QtyRequest[this];
			set => fields.QtyRequest[this] = value;
		}
        [DisplayName("Stock"), Expression("jvwAvailableStock.[AvailableStock]"), MinSelectLevel(SelectLevel.List),Updatable(false)]
        public Double? AvailableStock
        {
            get { return Fields.AvailableStock[this]; }
            set { Fields.AvailableStock[this] = value; }
        }

        [DisplayName("IsSelected"), NotMapped]
        public Boolean? IsSelected
        {
            get => fields.IsSelected[this];
            set => fields.IsSelected[this] = value;
        }
        public Int32Field TenantIdField
        {
            get { return Fields.TenantId; }
        }

        public int TotalPurchaseQtyRequest { get; internal set; }
        public bool IsPRGenerated { get; internal set; }

        public PurchaseOrderDetailRow()
            : base()
        {
        }

        public PurchaseOrderDetailRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : LoggingRowFields
        {
            public Int32Field Id;
            public Int32Field PurchaseOrderId;
            public Int32Field ProductId;
            public DoubleField Price;
            public DoubleField Qty;
            public Int32Field QuanityofPOCreated;
            public BooleanField IsBillGenerated;
            public DoubleField SubTotal;
            public BooleanField Select;

            public StringField InternalCode;
            public Int32Field MaterialRequestId;
         

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
            public StringField Description;
			//public Int32Field MaterialRequestId;
			//public StringField MaterialRequestNumber;
			public DoubleField QtyRequest;
            public DoubleField AvailableStock;

            public Int32Field PurchaseTaxId;
            public Int32Field QuanityOfPRCreated;
            public BooleanField IsPRCreate;

            public Int32Field QuanityOfBillCreated;
            public BooleanField IsBillCreated;
            public BooleanField IsSelected;


        }
    }
}
