using Indotalent.Merchandise;
using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using Serenity.Extensions.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace Indotalent.Material
{
    [ConnectionKey("Default"), Module("Material"), TableName("[dbo].[MaterialIssueDetail]")]
    [DisplayName("Issue Detail"), InstanceName("Issue Detail")]
    [ReadPermission("Material:IssueDetail")]
    [ModifyPermission("Material:IssueDetail")]
    [LookupScript(LookupType = typeof(MultiTenantRowLookupScript<>))]
    [InnerJoin("jMaterialIssue", "[dbo].[MaterialIssue]", "jMaterialIssue.[Id] = [T0].[MaterialIssueId]")]
    //[InnerJoin("JPurchaseOrder", "[dbo].[PurchaseOrder]", "JPurchaseReceipt.[PurchaseOrderId] = JPurchaseOrder.[Id]")]
    [InnerJoin("jMaterialRequest", "[dbo].[MaterialRequest]", "jMaterialIssue.[MaterialRequestId] = jMaterialRequest.[Id]")]
	[LeftJoin("jMaterialRequestDetail", "[dbo].[MaterialRequestDetail]",
        "jMaterialRequest.[Id] = jMaterialRequestDetail.[MaterialRequestId] AND jMaterialRequestDetail.[ProductId] = [T0].[ProductId]")]
    [LeftJoin("jvwAvailableStock", "[dbo].[vwAvailableStock]", "[T0].[ProductId] = jvwAvailableStock.[ProductId] " +
        "AND jMaterialRequest.[ProjectId] = jvwAvailableStock.[ProjectID] " +
        "AND jMaterialIssue.WarehouseId = jvwAvailableStock.WarehouseId")]
[LeftJoin("jPurchaseOrderDetail", "[dbo].[PurchaseOrderDetail]",
    "[T0].[ProductId] = jPurchaseOrderDetail.[ProductId]")]
[LeftJoin("jPurchaseOrder", "[dbo].[PurchaseOrder]", 
    "jPurchaseOrder.[Id] = jPurchaseOrderDetail.[PurchaseOrderId]")] 
    public sealed class IssueDetailRow : LoggingRow<IssueDetailRow.RowFields>, IIdRow, IMultiTenantRow
    {
        [DisplayName("Id"), Identity, IdProperty]
        public Int32? Id
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
        }

        [DisplayName("Issue Id"), NotNull, TextualField("MaterialIssueNumber")]
        public Int32? MaterialIssueId
        {
            get => fields.MaterialIssueId[this];
            set => fields.MaterialIssueId[this] = value;
        }

        [DisplayName("Issue Number"), Expression("jMaterialIssue.[Number]")]
        public String MaterialIssueNumber
        {
            get => fields.MaterialIssueNumber[this];
            set => fields.MaterialIssueNumber[this] = value;
        }

        [DisplayName("Request Id"), Expression("jMaterialIssue.[MaterialRequestId]"), TextualField("MaterialRequestNumber") ]
        public Int32? MaterialRequestId
        {
            get => fields.MaterialRequestId[this];
            set => fields.MaterialRequestId[this] = value;
        }

        [DisplayName("Request Number"), Expression("jMaterialRequest.[Number]"), MinSelectLevel(SelectLevel.List)]
        [Insertable(false), Updatable(false)]
        public String MaterialRequestNumber
        {
            get => fields.MaterialRequestNumber[this];
            set => fields.MaterialRequestNumber[this] = value;
        }
        [DisplayName("PurchaseReceiptId")]
        [DefaultValue(0)]
        
        public Int32? PurchaseReceiptId
        {
            get => fields.PurchaseReceiptId[this];
            set => fields.PurchaseReceiptId[this] = value;
        }

        [DisplayName("QtyOfIssueCreated"), NotMapped, ReadOnly(true)]
        [DefaultValue(0)]
        public Int32? QuanityOfIssueCreated
        {
            get => fields.QuanityOfIssueCreated[this];
            set => fields.QuanityOfIssueCreated[this] = value;
        }


        [DisplayName("Qty Requested"), Expression("jMaterialRequestDetail.[QtyRequest]"), MinSelectLevel(SelectLevel.List),
            Insertable(false), Updatable(false)]
        public Double? QtyRequest
        {
            get => fields.QtyRequest[this];
            set => fields.QtyRequest[this] = value;
        }

        [DisplayName("Qty Issue"), NotNull, DisplayFormat("#,##0.##"), DecimalEditor(Decimals = 2, MinValue = 0)]
        [DefaultValue(0)]
        public Double? QtyIssue
        {
            get => fields.QtyIssue[this];
            set => fields.QtyIssue[this] = value;
        }
        [DisplayName("Purchased Qty"), Expression("jPurchaseReceiptDetail.[QtyReceive]"),NotMapped]
        public Double? PurchasedQty
        {
            get { return Fields.PurchasedQty[this]; }
            set { Fields.PurchasedQty[this] = value; }
        }
        //[DisplayName("Qty Purchased"), Expression("jPurchaseOrderDetail.[Qty]"), Insertable(true), Updatable(true), MinSelectLevel(SelectLevel.List)]
        //public Double? Qty
        //{
        //    get => fields.Qty[this];
        //    set => fields.Qty[this] = value;
        //}
        [Expression("jPurchaseOrderDetail.[Qty]"), Insertable(false), Updatable(false)]
        [Hidden]
        public Double? Qty
        {
            get => fields.Qty[this];
            set => fields.Qty[this] = value;
        }
        [DisplayName("Product"), NotNull, ForeignKey("[dbo].[Product]", "Id"), LeftJoin("jProduct"), TextualField("ProductName")]
        [LookupEditor(typeof(Merchandise.ProductRow))]
        public Int32? ProductId
        {
            get => fields.ProductId[this];
            set => fields.ProductId[this] = value;
        }
        [DisplayName("Sub Total")]
        [DefaultValue(0)]
        public Double? SubTotal
        {
            get => fields.SubTotal[this];
            set => fields.SubTotal[this] = value;
        }

        [DisplayName("SAC"), NotNull, ForeignKey("[dbo].[SAC]", "Id"), Expression("jProduct.[SacId]"), LeftJoin("jSAC"), TextualField("SacName"), MinSelectLevel(SelectLevel.List), QuickSearch, Updatable(false), Insertable(false)]
        [LookupEditor(typeof(SACRow), InplaceAdd = true)]
        public Int32? SacId
        {
            get => fields.SacId[this];
            set => fields.SacId[this] = value;
        }
        [DisplayName("SAC"), Expression("jSAC.[SacName]"), QuickSearch, MinSelectLevel(SelectLevel.List)]
        public String SacName1
        {
            get => fields.SacName1[this];
            set => fields.SacName1[this] = value;
        }

        [DisplayName("HSN"), NotNull, ForeignKey("[dbo].[HSN]", "Id"), Expression("jProduct.[HsnId]"), LeftJoin("jHSN"), TextualField("HsnName"), MinSelectLevel(SelectLevel.List), QuickSearch, Updatable(false), Insertable(false)]
        [LookupEditor(typeof(HSNRow), InplaceAdd = true)]
        public Int32? HsnId
        {
            get => fields.HsnId[this];
            set => fields.HsnId[this] = value;
        }
        [DisplayName("HSN"), Expression("jHSN.[HsnName]"), QuickSearch, MinSelectLevel(SelectLevel.List)]
        public String HsnName1
        {
            get => fields.HsnName1[this];
            set => fields.HsnName1[this] = value;
        }

        [DisplayName("HSN No/ SAC No"), Size(100)]
        public String InternalCode
        {
            get => fields.InternalCode[this];
            set => fields.InternalCode[this] = value;
        }

        [DisplayName("Product"), Expression("jProduct.[Name]"), MinSelectLevel(SelectLevel.List)]
        public String ProductName
        {
            get => fields.ProductName[this];
            set => fields.ProductName[this] = value;
        }
		[DisplayName("Purchase Price"), Expression("jProduct.[PurchasePrice]"), MinSelectLevel(SelectLevel.List)]

		public Double? PurchasePrice
		{
			get => fields.PurchasePrice[this];
			set => fields.PurchasePrice[this] = value;
		}


        [DisplayName("Uom"), NotNull, ForeignKey("[dbo].[Uom]", "Id"), Expression("jProduct.[UomId]"), LeftJoin("jUom"), TextualField("UomName"), MinSelectLevel(SelectLevel.List), QuickSearch, Updatable(false), Insertable(false)]
        [LookupEditor(typeof(UomRow), InplaceAdd = true)]
        public Int32? UomId
        {
            get => fields.UomId[this];
            set => fields.UomId[this] = value;
        }
        [DisplayName("Uom"), Expression("jUom.[Name]"), QuickSearch, MinSelectLevel(SelectLevel.List)]
        public String UomName
        {
            get => fields.UomName[this];
            set => fields.UomName[this] = value;
        }

        [DisplayName("Purchase Tax"), Expression("jProduct.[PurchaseTaxId]"), ForeignKey("[dbo].[PurchaseTax]", "Id"), LeftJoin("jPurchaseTax")]
    
        public Int32? PurchaseTaxId
        {
            get => fields.PurchaseTaxId[this];
            set => fields.PurchaseTaxId[this] = value;
        }
    
        [DisplayName("Tax Percentage"), NotNull,Expression("jPurchaseTax.[TaxRatePercentage]")]
		[DefaultValue(0)]
		public Double? TaxRatePercentage
		{
			get => fields.TaxRatePercentage[this];
			set => fields.TaxRatePercentage[this] = value;
		}
		[DisplayName("Tenant"), ForeignKey("Tenant", "TenantId"), LeftJoin("jTenant"), TextualField("TenantName")]
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
        public Int32Field TenantIdField
        {
            get { return Fields.TenantId; }
        }
    
        [DisplayName("Stock"), Expression("jvwAvailableStock.[AvailableStock]"), MinSelectLevel(SelectLevel.List),Updatable(false)]
        public Double? AvailableStock
        {
            get { return Fields.AvailableStock[this]; }
            set { Fields.AvailableStock[this] = value; }
        }

        public IssueDetailRow()
            : base()
        {
        }

        public IssueDetailRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : LoggingRowFields
        {
            public Int32Field Id;
            public Int32Field MaterialIssueId;
            public Int32Field ProductId;
           public DoubleField PurchasedQty;
             public DoubleField Qty; //Qty purchase
            public DoubleField QtyIssue;
            public DoubleField QtyRequest;
            public DoubleField SubTotal;
            public Int32Field TenantId;
            public StringField TenantName;
            public StringField MaterialIssueNumber;
            public Int32Field MaterialRequestId;
            public StringField MaterialRequestNumber;
            public DoubleField PurchasePrice;
			public Int32Field PurchaseTaxId;
			public StringField ProductName;
            public DoubleField AvailableStock;			
			public DoubleField TaxRatePercentage;
            public Int32Field UomId;
            public StringField UomName;

            public Int32Field SacId;
            public StringField SacName1;
            public Int32Field HsnId;
            public StringField HsnName1;
            public StringField InternalCode;
            public Int32Field PurchaseReceiptId;
            // public StringField PurchaseReceiptNumber;
            public Int32Field QuanityOfIssueCreated;

        }
    }
}
