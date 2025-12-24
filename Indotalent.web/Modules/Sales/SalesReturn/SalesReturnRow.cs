using Indotalent.Web.Modules.Inventory.Location;
using Indotalent.Web.Modules.Inventory.Warehouse;
using Indotalent.Web.Modules.Projects.Project;
using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using Serenity.Extensions.Entities;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace Indotalent.Sales
{
    [ConnectionKey("Default"), Module("Sales"), TableName("[dbo].[SalesReturn]")]
    [DisplayName("Sales Return"), InstanceName("Sales Return")]
    [LookupScript(LookupType = typeof(MultiTenantRowLookupScript<>))]
    [ReadPermission("Sales:SalesReturn")]
    [ModifyPermission("Sales:SalesReturn")]
    public sealed class SalesReturnRow : LoggingRow<SalesReturnRow.RowFields>, IIdRow, INameRow, IMultiTenantRow
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

        [DisplayName("Return Date"), NotNull,QuickSearch]
        public DateTime? ReturnDate
        {
            get => fields.ReturnDate[this];
            set => fields.ReturnDate[this] = value;
        }

        [DisplayName("Sales Delivery"), NotNull, ForeignKey("[dbo].[SalesDelivery]", "Id"), LeftJoin("jSalesDelivery"), TextualField("SalesDeliveryNumber")]
        [LookupEditor(typeof(SalesDeliveryRow))]
        [Updatable(false)]
        public Int32? SalesDeliveryId
        {
            get => fields.SalesDeliveryId[this];
            set => fields.SalesDeliveryId[this] = value;
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

        [DisplayName("Total Qty Return"), NotNull]
        [DefaultValue(0), Insertable(false), Updatable(false)]
        public Double? TotalQtyReturn
        {
            get => fields.TotalQtyReturn[this];
            set => fields.TotalQtyReturn[this] = value;
        }

        [DisplayName("Sales Delivery"), Expression("jSalesDelivery.[Number]")]
        public String SalesDeliveryNumber
        {
            get => fields.SalesDeliveryNumber[this];
            set => fields.SalesDeliveryNumber[this] = value;
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

        [DisplayName("Items"), MasterDetailRelation(foreignKey: "SalesReturnId"), NotMapped]
        public List<SalesReturnDetailRow> ItemList
        {
            get => fields.ItemList[this];
            set => fields.ItemList[this] = value;
        }

        [DisplayName("Sales Order"), Expression("jSalesDelivery.[SalesOrderId]"), ForeignKey("[dbo].[SalesOrder]", "Id"), LeftJoin("jSalesOrder")]
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

        public SalesReturnRow()
            : base()
        {
        }

        public SalesReturnRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : LoggingRowFields
        {
            public Int32Field Id;
            public StringField Number;
            public StringField Description;
            public StringField SalesGroup;
            public DateTimeField ReturnDate;
            public Int32Field SalesOrderId;
            public Int32Field SalesDeliveryId;
            public Int32Field ProjectId;

            public Int32Field WarehouseId;
            public Int32Field LocationId;
            public DoubleField TotalQtyReturn;
            public StringField SalesDeliveryNumber;
            public StringField ProjectName;

            public StringField WarehouseName;
            public StringField LocationName;
            public RowListField<SalesReturnDetailRow> ItemList;
            public Int32Field CustomerId;
            public Int32Field TenantId;
            public StringField TenantName;
        }
    }
}
