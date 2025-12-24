using Indotalent.Projects;
using Indotalent.Web.Modules.Merchandise.Product;
using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;
using System.IO;
using Indotalent.Merchandise;

namespace Indotalent.Web.Modules.Common.Project_Summary.IssuedStock
{
    [ConnectionKey("Default"), TableName("[dbo].[MaterialIssueDetail]")]
    [DisplayName("Issue Details"), InstanceName("Issue Details")]
    [ReadPermission("*")]
    [ModifyPermission("*")]
    [InnerJoin("jMaterialIssue", "[dbo].[MaterialIssue]", "jMaterialIssue.[Id] = [T0].[MaterialIssueId]")]
    [InnerJoin("jMaterialRequest", "[dbo].[MaterialRequest]", "jMaterialIssue.[MaterialRequestId] = jMaterialRequest.[Id]")]

    [LeftJoin("jMaterialRequestDetail", "[dbo].[MaterialRequestDetail]",
        "jMaterialRequest.[Id] = jMaterialRequestDetail.[MaterialRequestId] AND jMaterialRequestDetail.[ProductId] = [T0].[ProductId]")]
    [LeftJoin("jvwAvailableStock", "[dbo].[vwAvailableStock]", "[T0].[ProductId] = jvwAvailableStock.[ProductId] " +
        "AND jMaterialRequest.[ProjectId] = jvwAvailableStock.[ProjectID] " +
        "AND jMaterialIssue.WarehouseId = jvwAvailableStock.WarehouseId")]
    public sealed class IssueStockRow : Row<IssueStockRow.RowFields>, IIdRow, INameRow
    {

        [DisplayName("Id"), Identity, IdProperty]
        public int? Id
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
        }

        [DisplayName("Issue Id"), NotNull, TextualField("MaterialIssueNumber"), NameProperty]
        public int? MaterialIssueId
        {
            get => fields.MaterialIssueId[this];
            set => fields.MaterialIssueId[this] = value;
        }

        [DisplayName("Issue Number"), Expression("jMaterialIssue.[Number]")]
        public string MaterialIssueNumber
        {
            get => fields.MaterialIssueNumber[this];
            set => fields.MaterialIssueNumber[this] = value;
        }
        [DisplayName("Project"), NotNull, ForeignKey("[dbo].[Project]", "Id"), Expression("jvwAvailableStock.[ProjectId]"), LeftJoin("jProject"), TextualField("ProjectName"), QuickSearch]
        [LookupEditor(typeof(ProjectRow), InplaceAdd = true)]

        public int? ProjectId
        {
            get => fields.ProjectId[this];
            set => fields.ProjectId[this] = value;
        }

        [DisplayName("Project"), Expression("jProject.[Name]"), QuickSearch]
        public string ProjectName
        {
            get => fields.ProjectName[this];
            set => fields.ProjectName[this] = value;
        }
        [DisplayName("Warehouse"), NotNull, ForeignKey("[dbo].[Warehouse]", "Id"), Expression("jvwAvailableStock.[WarehouseId]"), LeftJoin("jWarehouse"), TextualField("WarehouseName"), QuickSearch]
        [LookupEditor(typeof(ProjectRow), InplaceAdd = true)]

        public int? WarehouseId
        {
            get => fields.WarehouseId[this];
            set => fields.WarehouseId[this] = value;
        }

        [DisplayName("Warehouse"), Expression("jWarehouse.[Name]"), QuickSearch]
        public string WarehouseName
        {
            get => fields.WarehouseName[this];
            set => fields.WarehouseName[this] = value;
        }

        [DisplayName("Request Id"), Expression("jMaterialIssue.[MaterialRequestId]"), TextualField("MaterialRequestNumber")]
        public int? MaterialRequestId
        {
            get => fields.MaterialRequestId[this];
            set => fields.MaterialRequestId[this] = value;
        }

        [DisplayName("Request Number"), Expression("jMaterialRequest.[Number]"), MinSelectLevel(SelectLevel.List)]
        [Insertable(false), Updatable(false)]
        public string MaterialRequestNumber
        {
            get => fields.MaterialRequestNumber[this];
            set => fields.MaterialRequestNumber[this] = value;
        }

        [DisplayName("Qty Requested"), Expression("jMaterialRequestDetail.[QtyRequest]"), MinSelectLevel(SelectLevel.List),
            Insertable(false), Updatable(false), QuickSearch]
        public double? QtyRequest
        {
            get => fields.QtyRequest[this];
            set => fields.QtyRequest[this] = value;
        }

        [DisplayName("Qty Issue"), NotNull, DisplayFormat("#,##0.##"), DecimalEditor(Decimals = 2, MinValue = 0), QuickSearch]
        [DefaultValue(0)]
        public double? QtyIssue
        {
            get => fields.QtyIssue[this];
            set => fields.QtyIssue[this] = value;
        }

        [DisplayName("Product"), NotNull, ForeignKey("[dbo].[Product]", "Id"), LeftJoin("jProduct"), TextualField("ProductName")]
        [LookupEditor(typeof(ProductRow))]
        public int? ProductId
        {
            get => fields.ProductId[this];
            set => fields.ProductId[this] = value;
        }

        [DisplayName("Product"), Expression("jProduct.[Name]"), MinSelectLevel(SelectLevel.List), QuickSearch]
        public string ProductName
        {
            get => fields.ProductName[this];
            set => fields.ProductName[this] = value;
        }
        [DisplayName("Purchase Price"), Expression("jProduct.[PurchasePrice]"), MinSelectLevel(SelectLevel.List)]

        public double? PurchasePrice
        {
            get => fields.PurchasePrice[this];
            set => fields.PurchasePrice[this] = value;
        }
        [DisplayName("Purchase Tax"), Expression("jProduct.[PurchaseTaxId]"), ForeignKey("[dbo].[PurchaseTax]", "Id"), LeftJoin("jPurchaseTax")]

        public int? PurchaseTaxId
        {
            get => fields.PurchaseTaxId[this];
            set => fields.PurchaseTaxId[this] = value;
        }

        [DisplayName("Tax Percentage"), NotNull, Expression("jPurchaseTax.[TaxRatePercentage]")]
        [DefaultValue(0)]
        public double? TaxRatePercentage
        {
            get => fields.TaxRatePercentage[this];
            set => fields.TaxRatePercentage[this] = value;
        }
        [DisplayName("Tenant"), ForeignKey("Tenant", "TenantId"), LeftJoin("jTenant"), TextualField("TenantName")]
        [Insertable(false), Updatable(false)]
        public int? TenantId
        {
            get { return Fields.TenantId[this]; }
            set { Fields.TenantId[this] = value; }
        }

        [DisplayName("Tenant"), Expression("jTenant.TenantName"), MinSelectLevel(SelectLevel.List)]
        public string TenantName
        {
            get { return Fields.TenantName[this]; }
            set { Fields.TenantName[this] = value; }
        }
        public Int32Field TenantIdField
        {
            get { return Fields.TenantId; }
        }

        [DisplayName("Stock"), Expression("jvwAvailableStock.[AvailableStock]"), MinSelectLevel(SelectLevel.List), QuickSearch]
        public double? AvailableStock
        {
            get { return Fields.AvailableStock[this]; }
            set { Fields.AvailableStock[this] = value; }
        }
        public IssueStockRow()
            : base()
        {
        }

        public IssueStockRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field Id;
            public Int32Field MaterialIssueId;
            public Int32Field ProductId;
            public DoubleField QtyIssue;
            public DoubleField QtyRequest;
            public Int32Field TenantId;
            public StringField TenantName;

            public StringField MaterialIssueNumber;
            public Int32Field MaterialRequestId;
            public StringField MaterialRequestNumber;
            public DoubleField PurchasePrice;
            public Int32Field PurchaseTaxId;

            public StringField ProductName;
            public DoubleField AvailableStock;

            public Int32Field ProjectId;
            public StringField ProjectName;
            public Int32Field WarehouseId;
            public StringField WarehouseName;
            public DoubleField TaxRatePercentage;
        }
    }
}
