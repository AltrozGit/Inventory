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
    [ConnectionKey("Default"), Module("Purchase"), TableName("[dbo].[PurchaseReceiptDetail]")]
    [DisplayName("Purchase Receipt Detail"), InstanceName("Purchase Receipt Detail")]
    [ReadPermission("Purchase:PurchaseReceiptDetail")]
    [ModifyPermission("Purchase:PurchaseReceiptDetail")]
    [InnerJoin("JPurchaseReceipt", "[dbo].[PurchaseReceipt]", "JPurchaseReceipt.[Id] = [T0].[PurchaseReceiptId]")]
    [InnerJoin("JPurchaseOrder", "[dbo].[PurchaseOrder]", "JPurchaseReceipt.[PurchaseOrderId] = JPurchaseOrder.[Id]")]
    [InnerJoin("jMaterialRequest", "[dbo].[MaterialRequest]", "JPurchaseOrder.[MaterialRequestId] = jMaterialRequest.[Id]")]
    [LeftJoin("jMaterialRequestDetail", "[dbo].[MaterialRequestDetail]",
        "jMaterialRequest.[Id] = jMaterialRequestDetail.[MaterialRequestId] AND jMaterialRequestDetail.[ProductId] = [T0].[ProductId]")]
    [LeftJoin("jPurchaseOrderDetail", "[dbo].[PurchaseOrderDetail]",
        "JPurchaseOrder.[Id] = jPurchaseOrderDetail.[PurchaseOrderId] AND jPurchaseOrderDetail.[ProductId] = [T0].[ProductId]")]
    [LookupScript(LookupType = typeof(MultiTenantRowLookupScript<>))]
    public sealed class PurchaseReceiptDetailRow : Row<PurchaseReceiptDetailRow.RowFields>, IIdRow, IMultiTenantRow
    {
        [DisplayName("Id"), Identity, IdProperty]
        public Int32? Id
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
        }

        [DisplayName("Purchase Receipt"), NotNull, ForeignKey("[dbo].[PurchaseReceipt]", "Id"),TextualField("PurchaseReceiptNumber")]
        public Int32? PurchaseReceiptId
        {
            get => fields.PurchaseReceiptId[this];
            set => fields.PurchaseReceiptId[this] = value;
        }

        [DisplayName("Purchase Receipt Number"), Expression("jPurchaseReceipt.[Number]")]
        public String PurchaseReceiptNumber
        {
            get => fields.PurchaseReceiptNumber[this];
            set => fields.PurchaseReceiptNumber[this] = value;
        }

        [DisplayName("PurchaseOrderId")]
        [DefaultValue(0)]
        public Int32? PurchaseOrderId
        {
            get => fields.PurchaseOrderId[this];
            set => fields.PurchaseOrderId[this] = value;
        }


        [DisplayName("Product"), NotNull, ForeignKey("[dbo].[Product]", "Id"), LeftJoin("jProduct"), TextualField("ProductName")]
        [LookupEditor(typeof(Merchandise.ProductRow))]
        public Int32? ProductId
        {
            get => fields.ProductId[this];
            set => fields.ProductId[this] = value;
        }

        [DisplayName("Product"), Expression("jProduct.[Name]"), MinSelectLevel(SelectLevel.List), NameProperty]
        public String ProductName
        {
            get => fields.ProductName[this];
            set => fields.ProductName[this] = value;
        }
        [DisplayName("Qty Purchased"), Expression("jPurchaseOrderDetail.[Qty]"), Insertable(false), Updatable(false), MinSelectLevel(SelectLevel.List)]

        public Double? Qty
        {
            get => fields.Qty[this];
            set => fields.Qty[this] = value;
        }
        [DisplayName("Qty Requested"), Expression("jMaterialRequestDetail.[QtyRequest]"), MinSelectLevel(SelectLevel.List),
             Insertable(false), Updatable(false)]
        public Double? QtyRequest
        {
            get => fields.QtyRequest[this];
            set => fields.QtyRequest[this] = value;
        }

        [DisplayName("Qty Received"), NotNull]
        [DefaultValue(1)]
        public Double? QtyReceive
        {
            get => fields.QtyReceive[this];
            set => fields.QtyReceive[this] = value;
        }

        [DisplayName("Pending Receivable Qty")]
        [DefaultValue(0)]
        public Decimal? PendingReceivableQty
        {
            get { return Fields.PendingReceivableQty[this]; }
            set { Fields.PendingReceivableQty[this] = value; }
        }

        [DisplayName("Quantity Of PR Created"), NotMapped]
        [DefaultValue(0)]
        public Int32? QuanityofPRCreated
        {
            get => fields.QuanityofPRCreated[this];
            set => fields.QuanityofPRCreated[this] = value;
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


        [DisplayName("Quanity Of Bill Created")]
        [DefaultValue(0)]
        public Int32? QuanityOfBillCreated
        {
            get => fields.QuanityOfBillCreated[this];
            set => fields.QuanityOfBillCreated[this] = value;
        }

        [DisplayName("IsPBillCreate")]
        public Boolean? IsBillCreate
        {
            get => fields.IsBillCreate[this];
            set => fields.IsBillCreate[this] = value;
        }

        [DisplayName("Quanity Of Issue Created")]
        [DefaultValue(0)]
        public Int32? QuanityOfIssueCreated
        {
            get => fields.QuanityOfIssueCreated[this];
            set => fields.QuanityOfIssueCreated[this] = value;
        }

        [DisplayName("IsIssueCreated")]
        public Boolean? IsIssueCreated
        {
            get => fields.IsIssueCreated[this];
            set => fields.IsIssueCreated[this] = value;
        }

        [DisplayName("HSN No/ SAC No"), Size(100)]
        public String InternalCode
        {
            get => fields.InternalCode[this];
            set => fields.InternalCode[this] = value;
        }

        public Int32Field TenantIdField
        {
            get { return Fields.TenantId; }
        }

        public PurchaseReceiptDetailRow()
            : base()
        {
        }

        public PurchaseReceiptDetailRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field Id;
            public Int32Field PurchaseReceiptId;
            public Int32Field ProductId;
            public DoubleField QtyReceive;
            public DecimalField PendingReceivableQty;
            public StringField PurchaseReceiptNumber;
            public StringField ProductName;
            public Int32Field TenantId;
            public StringField TenantName;
            public DoubleField Qty;
            public DoubleField QtyRequest;
            public Int32Field QuanityofPRCreated;
            public Int32Field PurchaseOrderId;

            public Int32Field QuanityOfBillCreated;
            public BooleanField IsBillCreate;

            public Int32Field QuanityOfIssueCreated;
            public BooleanField IsIssueCreated;
            public StringField InternalCode;


        }
    }
}
