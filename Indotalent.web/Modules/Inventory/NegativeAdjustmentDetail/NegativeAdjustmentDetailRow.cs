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
    [ConnectionKey("Default"), Module("Inventory"), TableName("[dbo].[NegativeAdjustmentDetail]")]
    [DisplayName("Negative Adjustment Detail"), InstanceName("Negative Adjustment Detail")]
    [ReadPermission("Inventory:NegativeAdjustment")]
    [ModifyPermission("Inventory:NegativeAdjustment")]
    [LookupScript(LookupType = typeof(MultiTenantRowLookupScript<>))]
    public sealed class NegativeAdjustmentDetailRow : LoggingRow<NegativeAdjustmentDetailRow.RowFields>, IIdRow, IMultiTenantRow
    {
        [DisplayName("Id"), Identity, IdProperty]
        public Int32? Id
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
        }

        [DisplayName("Negative Adjustment"), NotNull, ForeignKey("[dbo].[NegativeAdjustment]", "Id"), LeftJoin("jNegativeAdjustment"), TextualField("NegativeAdjustmentNumber")]
        public Int32? NegativeAdjustmentId
        {
            get => fields.NegativeAdjustmentId[this];
            set => fields.NegativeAdjustmentId[this] = value;
        }

        [DisplayName("Product"), NotNull, ForeignKey("[dbo].[Product]", "Id"), LeftJoin("jProduct"), TextualField("ProductName")]
        [LookupEditor(typeof(ProductLookup), InplaceAdd = true, DialogType = "Indotalent.Merchandise.ProductDialog")]
        public Int32? ProductId
        {
            get => fields.ProductId[this];
            set => fields.ProductId[this] = value;
        }

        [DisplayName("Product"), Expression("jProduct.[Name]"), MinSelectLevel(SelectLevel.List)]
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

        [DisplayName("Negative Adjustment"), Expression("jNegativeAdjustment.[Number]")]
        public String NegativeAdjustmentNumber
        {
            get => fields.NegativeAdjustmentNumber[this];
            set => fields.NegativeAdjustmentNumber[this] = value;
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

        public NegativeAdjustmentDetailRow()
            : base()
        {
        }

        public NegativeAdjustmentDetailRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : LoggingRowFields
        {
            public Int32Field Id;
            public Int32Field NegativeAdjustmentId;
            public Int32Field ProductId;
            public DoubleField Qty;
            public StringField NegativeAdjustmentNumber;
            public StringField ProductName;
            public Int32Field TenantId;
            public StringField TenantName;
        }
    }
}
