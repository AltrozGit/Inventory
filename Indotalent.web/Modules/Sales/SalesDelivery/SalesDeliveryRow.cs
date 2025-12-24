using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using Serenity.Extensions.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using Indotalent.Web.Modules.Inventory.Shipper;
using Indotalent.Web.Modules.Merchandise.Product;
using Indotalent.Web.Modules.Projects.Project;
using Indotalent.Web.Modules.Inventory.Warehouse;
using Indotalent.Web.Modules.Inventory.Location;

namespace Indotalent.Sales
{
    [ConnectionKey("Default"), Module("Sales"), TableName("[dbo].[SalesDelivery]")]
    [DisplayName("Sales Delivery"), InstanceName("Sales Delivery")]
    [LookupScript(LookupType = typeof(MultiTenantRowLookupScript<>))]
    [ReadPermission("Sales:SalesDelivery")]
    [ModifyPermission("Sales:SalesDelivery")]
    public sealed class SalesDeliveryRow : Row<SalesDeliveryRow.RowFields>, IIdRow, INameRow, IMultiTenantRow
    {
        [DisplayName("Id"), Identity, IdProperty]
        public Int32? Id
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
        }

        [DisplayName("Number"), Size(200), NotNull, QuickSearch, NameProperty]

        [DefaultValue("auto")]
        public String Number
        {
            get => fields.Number[this];
            set => fields.Number[this] = value;
        }

        [DisplayName("Description"), Size(1000)]
        public String Description
        {
            get => fields.Description[this];
            set => fields.Description[this] = value;
        }

        [DisplayName("Delivery Date"), NotNull,QuickSearch]
        public DateTime? DeliveryDate
        {
            get => fields.DeliveryDate[this];
            set => fields.DeliveryDate[this] = value;
        }

        [DisplayName("Quotation"), NotNull, ForeignKey("[dbo].[SalesOrder]", "Id"), LeftJoin("jSalesOrder"), TextualField("SalesOrderNumber")]
        [LookupEditor(typeof(SalesOrderRow))]
        [Updatable(false)]
        public Int32? SalesOrderId
        {
            get => fields.SalesOrderId[this];
            set => fields.SalesOrderId[this] = value;
        }

        [DisplayName("Sales"), Size(200)]
        public String SalesGroup
        {
            get => fields.SalesGroup[this];
            set => fields.SalesGroup[this] = value;
        }

        [DisplayName("Shipper"), NotNull, ForeignKey("[dbo].[Shipper]", "Id"), LeftJoin("jShipper"), TextualField("ShipperName")]
        [LookupEditor(typeof(ShipperLookup), InplaceAdd = true, DialogType = "Indotalent.Inventory.ShipperDialog")]
        public Int32? ShipperId
        {
            get => fields.ShipperId[this];
            set => fields.ShipperId[this] = value;
        }

        [DisplayName("Shipper"), Expression("jShipper.[Name]")]
        public String ShipperName
        {
            get => fields.ShipperName[this];
            set => fields.ShipperName[this] = value;
        }
        [DisplayName("Project"), NotNull, ForeignKey("[dbo].[Project]", "Id"), LeftJoin("jProject"), TextualField("ProjectName")]
        [LookupEditor(typeof(ProjectLookup), InplaceAdd = true, DialogType = "Indotalent.Projects.ProjectDialog")]
        public Int32? ProjectId
        {
            get => fields.ProjectId[this];
            set => fields.ProjectId[this] = value;
        }
        [DisplayName("Warehouse"), NotNull, ForeignKey("[dbo].[Warehouse]", "Id"), LeftJoin("jWarehouse"), TextualField("WarehouseName")]
        [LookupEditor(typeof(WarehouseLookup), InplaceAdd = true, DialogType = "Indotalent.Inventory.WarehouseDialog")]
        public Int32? WarehouseId
        {
            get => fields.WarehouseId[this];
            set => fields.WarehouseId[this] = value;
        }

        [DisplayName("Location"), ForeignKey("[dbo].[Location]", "Id"), LeftJoin("jLocation"), TextualField("LocationName")]
        [LookupEditor(typeof(LocationLookup), InplaceAdd = true, DialogType = "Indotalent.Inventory.LocationDialog")]
        public Int32? LocationId
        {
            get => fields.LocationId[this];
            set => fields.LocationId[this] = value;
        }

        [DisplayName("Total Qty Delivered"), NotNull]
        [DefaultValue(0), Insertable(false), Updatable(false)]
        public Double? TotalQtyDelivered
        {
            get => fields.TotalQtyDelivered[this];
            set => fields.TotalQtyDelivered[this] = value;
        }

        [DisplayName("Sales Order"), Expression("jSalesOrder.[Number]")]
        public String SalesOrderNumber
        {
            get => fields.SalesOrderNumber[this];
            set => fields.SalesOrderNumber[this] = value;
        }
        [DisplayName("Project"), Expression("jProject.[Name]")]
        public String ProjectName
        {
            get => fields.ProjectName[this];
            set => fields.ProjectName[this] = value;
        }
        [DisplayName("Warehouse"), Expression("jWarehouse.[Name]")]
        public String WarehouseName
        {
            get => fields.WarehouseName[this];
            set => fields.WarehouseName[this] = value;
        }

        [DisplayName("Location"), Expression("jLocation.[Name]")]
        public String LocationName
        {
            get => fields.LocationName[this];
            set => fields.LocationName[this] = value;
        }

        [DisplayName("Items"), MasterDetailRelation(foreignKey: "SalesDeliveryId"), NotMapped]
        public List<SalesDeliveryDetailRow> ItemList
        {
            get => fields.ItemList[this];
            set => fields.ItemList[this] = value;
        }

        [DisplayName("Customer"), Expression("jSalesOrder.[CustomerId]"), ForeignKey("[dbo].[Customer]", "Id"), LeftJoin("jCustomer")]
        public Int32? CustomerId
        {
            get => fields.CustomerId[this];
            set => fields.CustomerId[this] = value;
        }

        [DisplayName("Tenant"), ForeignKey("Tenant", "TenantId"), LeftJoin("jTenant")]
        [Insertable(false), Updatable(false)]
        public Int32? TenantId
        {
            get { return Fields.TenantId[this]; }
            set { Fields.TenantId[this] = value; }
        }

        [DisplayName("Tenant"), Expression("jTenant.TenantName")]
        public String TenantName
        {
            get { return Fields.TenantName[this]; }
            set { Fields.TenantName[this] = value; }
        }

        public Int32Field TenantIdField
        {
            get { return Fields.TenantId; }
        }
        public SalesDeliveryRow()
            : base()
        {
        }

        public SalesDeliveryRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field Id;
            public StringField Number;
            public StringField Description;
            public StringField SalesGroup;
            public DateTimeField DeliveryDate;
            public Int32Field SalesOrderId;
            public Int32Field ProjectId;

            public Int32Field WarehouseId;
            public Int32Field LocationId;
            public DoubleField TotalQtyDelivered;
            public StringField SalesOrderNumber;
            public StringField ProjectName;

            public StringField WarehouseName;
            public StringField LocationName;
            public RowListField<SalesDeliveryDetailRow> ItemList;
            public Int32Field CustomerId;
            public Int32Field ShipperId;
            public StringField ShipperName;
            public Int32Field TenantId;
            public StringField TenantName;
        }
    }
}

