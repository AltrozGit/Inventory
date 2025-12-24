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
    [ConnectionKey("Default"), Module("Inventory"), TableName("[dbo].[PositiveAdjustmentDetail]")]
    [DisplayName("Positive Adjustment Detail"), InstanceName("Positive Adjustment Detail")]
    [ReadPermission("Inventory:PositiveAdjustment")]
    [ModifyPermission("Inventory:PositiveAdjustment")]
    [LookupScript(LookupType = typeof(MultiTenantRowLookupScript<>))]
    public sealed class PositiveAdjustmentDetailRow : LoggingRow<PositiveAdjustmentDetailRow.RowFields>, IIdRow, IMultiTenantRow
    {
        [DisplayName("Id"), Identity, IdProperty]
        public Int32? Id
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
        }

        [DisplayName("Positive Adjustment"), NotNull, ForeignKey("[dbo].[PositiveAdjustment]", "Id"), LeftJoin("jPositiveAdjustment"), TextualField("PositiveAdjustmentNumber")]
        public Int32? PositiveAdjustmentId
        {
            get => fields.PositiveAdjustmentId[this];
            set => fields.PositiveAdjustmentId[this] = value;
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

        [DisplayName("Positive Adjustment"), Expression("jPositiveAdjustment.[Number]")]
        public String PositiveAdjustmentNumber
        {
            get => fields.PositiveAdjustmentNumber[this];
            set => fields.PositiveAdjustmentNumber[this] = value;
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

        public PositiveAdjustmentDetailRow()
            : base()
        {
        }

        public PositiveAdjustmentDetailRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : LoggingRowFields
        {
            public Int32Field Id;
            public Int32Field PositiveAdjustmentId;
            public Int32Field ProductId;
            public DoubleField Qty;
            public StringField PositiveAdjustmentNumber;
            public StringField ProductName;
            public Int32Field TenantId;
            public StringField TenantName;
        }
    }
}
