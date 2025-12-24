using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using Serenity.Extensions.Entities;
using System;
using System.ComponentModel;
using System.IO;
using Indotalent.Web.Modules.Merchandise.Product;

namespace Indotalent.Purchase
{
    [ConnectionKey("Default"), Module("Purchase"), TableName("[dbo].[PurchaseReturnDetail]")]
    [DisplayName("Item Return Detail"), InstanceName("Item Return Detail")]
    [ReadPermission("Purchase:PurchaseReturnDetail")]
    [ModifyPermission("Purchase:PurchaseReturnDetail")]
    [LookupScript(LookupType = typeof(MultiTenantRowLookupScript<>))]
    public sealed class PurchaseReturnDetailRow : Row<PurchaseReturnDetailRow.RowFields>, IIdRow, IMultiTenantRow
    {
        [DisplayName("Id"), Identity, IdProperty]
        public Int32? Id
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
        }

        [DisplayName("Purchase Return"), NotNull, ForeignKey("[dbo].[PurchaseReturn]", "Id"), LeftJoin("jPurchaseReturn"), TextualField("PurchaseReturnNumber")]
        public Int32? PurchaseReturnId
        {
            get => fields.PurchaseReturnId[this];
            set => fields.PurchaseReturnId[this] = value;
        }

        [DisplayName("Product"), NotNull, ForeignKey("[dbo].[Product]", "Id"), LeftJoin("jProduct"), TextualField("ProductName")]
        [LookupEditor(typeof(ProductLookup), InplaceAdd = true, DialogType = "Indotalent.Merchandise.ProductDialog")]
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

        [DisplayName("Qty Return"), NotNull]
        [DefaultValue(1)]
        public Double? QtyReturn
        {
            get => fields.QtyReturn[this];
            set => fields.QtyReturn[this] = value;
        }

        [DisplayName("Purchase Return Number"), Expression("jPurchaseReturn.[Number]")]
        public String PurchaseReturnNumber
        {
            get => fields.PurchaseReturnNumber[this];
            set => fields.PurchaseReturnNumber[this] = value;
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

        public PurchaseReturnDetailRow()
            : base()
        {
        }

        public PurchaseReturnDetailRow(RowFields fields)
            : base(fields)
        {
        }


        public class RowFields : RowFieldsBase
        {
            public Int32Field Id;
            public Int32Field PurchaseReturnId;
            public Int32Field ProductId;
            public DoubleField QtyReturn;
            public StringField PurchaseReturnNumber;
            public StringField ProductName;
            public Int32Field TenantId;
            public StringField TenantName;
        }
    }
}

