using Indotalent.Web.Modules.Merchandise.Product;
using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using Serenity.Extensions.Entities;
using System;
using System.ComponentModel;
using System.IO;

namespace Indotalent.Inventory
{
    [ConnectionKey("Default"), Module("Inventory"), TableName("[dbo].[TransferOrderDetail]")]
    [DisplayName("Transfer Order Details"), InstanceName("Transfer Order Detail")]
    [ReadPermission("Inventory:TransferOrder")]
    [ModifyPermission("Inventory:TransferOrder")]
    [LookupScript(LookupType = typeof(MultiTenantRowLookupScript<>))]
    public sealed class TransferOrderDetailRow : LoggingRow<TransferOrderDetailRow.RowFields>, IIdRow, IMultiTenantRow
    {
        [DisplayName("Id"), Identity, IdProperty]
        public Int32? Id
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
        }

        [DisplayName("Transfer Order"), NotNull, ForeignKey("[dbo].[TransferOrder]", "Id"), LeftJoin("jTransferOrder"), TextualField("TransferOrderNumber")]
        public Int32? TransferOrderId
        {
            get => fields.TransferOrderId[this];
            set => fields.TransferOrderId[this] = value;
        }

        [DisplayName("Product"), NotNull, ForeignKey("[dbo].[Product]", "Id"), LeftJoin("jProduct"), TextualField("ProductName")]
        [LookupEditor(typeof(ProductLookup), InplaceAdd = true, DialogType = "Indotalent.Merchandise.ProductDialog")]
        public Int32? ProductId
        {
            get => fields.ProductId[this];
            set => fields.ProductId[this] = value;
        }

        [DisplayName("Product Name"), Expression("jProduct.[Name]"), MinSelectLevel(SelectLevel.List)]
        public String ProductName
        {
            get => fields.ProductName[this];
            set => fields.ProductName[this] = value;
        }

        [DisplayName("Qty"), NotNull]
        [DefaultValue(0)]
        public Double? Qty
        {
            get => fields.Qty[this];
            set => fields.Qty[this] = value;
        }

        [DisplayName("Transfer Order"), Expression("jTransferOrder.[Number]")]
        public String TransferOrderNumber
        {
            get => fields.TransferOrderNumber[this];
            set => fields.TransferOrderNumber[this] = value;
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

        public Int32Field TenantIdField
        {
            get { return Fields.TenantId; }
        }

        public TransferOrderDetailRow()
            : base()
        {
        }

        public TransferOrderDetailRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : LoggingRowFields
        {
            public Int32Field Id;
            public Int32Field TransferOrderId;
            public Int32Field ProductId;
            public DoubleField Qty;
            public StringField TransferOrderNumber;
            public StringField ProductName;
            public Int32Field TenantId;
            public StringField TenantName;
        }
    }
}
