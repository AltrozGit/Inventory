using Indotalent.Web.Modules.Merchandise.Product;
using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using Serenity.Extensions.Entities;
using System;
using System.ComponentModel;
using System.IO;

namespace Indotalent.Sales
{
    [ConnectionKey("Default"), Module("Sales"), TableName("[dbo].[SalesDeliveryDetail]")]
    [DisplayName("Sales Delivery Detail"), InstanceName("Item Delivery Detail")]
    [ReadPermission("Sales:SalesDeliveryDetail")]
    [ModifyPermission("Sales:SalesDeliveryDetail")]
    [LookupScript(LookupType = typeof(MultiTenantRowLookupScript<>))]
    public sealed class SalesDeliveryDetailRow : LoggingRow<SalesDeliveryDetailRow.RowFields>, IIdRow, IMultiTenantRow
    {
        [DisplayName("Id"), Identity, IdProperty]
        public Int32? Id
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
        }

        [DisplayName("Sales Delivery"), NotNull, ForeignKey("[dbo].[SalesDelivery]", "Id"), LeftJoin("jSalesDelivery"), TextualField("SalesDeliveryNumber")]
        public Int32? SalesDeliveryId
        {
            get => fields.SalesDeliveryId[this];
            set => fields.SalesDeliveryId[this] = value;
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

        [DisplayName("Qty Delivered"), NotNull]
        [DefaultValue(1)]
        public Double? QtyDelivered
        {
            get => fields.QtyDelivered[this];
            set => fields.QtyDelivered[this] = value;
        }

        [DisplayName("Sales Delivery Number"), Expression("jSalesDelivery.[Number]")]
        public String SalesDeliveryNumber
        {
            get => fields.SalesDeliveryNumber[this];
            set => fields.SalesDeliveryNumber[this] = value;
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

        public SalesDeliveryDetailRow()
            : base()
        {
        }

        public SalesDeliveryDetailRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : LoggingRowFields
        {
            public Int32Field Id;
            public Int32Field SalesDeliveryId;
            public Int32Field ProductId;
            public DoubleField QtyDelivered;
            public StringField SalesDeliveryNumber;
            public StringField ProductName;
            public Int32Field TenantId;
            public StringField TenantName;
        }
    }
}
