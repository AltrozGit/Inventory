using Indotalent.Projects;
using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using Serenity.Extensions.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using Indotalent.Web.Modules.Projects.Project;
using Indotalent.Web.Modules.Inventory.Warehouse;
using Indotalent.Web.Modules.Inventory.Location;
namespace Indotalent.Inventory
{
    [ConnectionKey("Default"), Module("Inventory"), TableName("[dbo].[PositiveAdjustment]")]
    [DisplayName("Positive Adjustments"), InstanceName("Positive Adjustment")]
    [ReadPermission("Inventory:PositiveAdjustment")]
    [ModifyPermission("Inventory:PositiveAdjustment")]
    [LookupScript(LookupType = typeof(MultiTenantRowLookupScript<>))]
    public sealed class PositiveAdjustmentRow : LoggingRow<PositiveAdjustmentRow.RowFields>, IIdRow, INameRow, IMultiTenantRow
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

        [DisplayName("Adjustment Date"), NotNull, QuickSearch]
        public DateTime? AdjustmentDate
        {
            get => fields.AdjustmentDate[this];
            set => fields.AdjustmentDate[this] = value;
        }
        [DisplayName("Project"),NotNull, ForeignKey("[dbo].[Project]", "Id"), LeftJoin("jProject"), TextualField("ProjectName"), QuickSearch]
        [LookupEditor(typeof(ProjectLookup), InplaceAdd = true, DialogType = "Indotalent.Projects.ProjectDialog")]
        public Int32? ProjectId
        {
            get => fields.ProjectId[this];
            set => fields.ProjectId[this] = value;
        }
        [DisplayName("Warehouse"), NotNull, ForeignKey("[dbo].[Warehouse]", "Id"), LeftJoin("jWarehouse"), TextualField("WarehouseName"), QuickSearch]
        [LookupEditor(typeof(WarehouseLookup), InplaceAdd = true, DialogType = "Indotalent.Inventory.WarehouseDialog")]
        public Int32? WarehouseId
        {
            get => fields.WarehouseId[this];
            set => fields.WarehouseId[this] = value;
        }

        [DisplayName("Location"), ForeignKey("[dbo].[Location]", "Id"), LeftJoin("jLocation"), TextualField("LocationName"), QuickSearch]
        [LookupEditor(typeof(LocationLookup), InplaceAdd = true, DialogType = "Indotalent.Inventory.LocationDialog")]
        public Int32? LocationId
        {
            get => fields.LocationId[this];
            set => fields.LocationId[this] = value;
        }

        [DisplayName("Total Qty"), NotNull, QuickSearch]
        [DefaultValue(0), Insertable(false), Updatable(false)]
        public Double? TotalQty
        {
            get => fields.TotalQty[this];
            set => fields.TotalQty[this] = value;
        }
        [DisplayName("Project"), Expression("jProject.[Name]"), QuickSearch]
        public String ProjectName
        {
            get => fields.ProjectName[this];
            set => fields.ProjectName[this] = value;
        }
        [DisplayName("Warehouse"), Expression("jWarehouse.[Name]"), QuickSearch]
        public String WarehouseName
        {
            get => fields.WarehouseName[this];
            set => fields.WarehouseName[this] = value;
        }

        [DisplayName("Location"), Expression("jLocation.[Name]"), QuickSearch]
        public String LocationName
        {
            get => fields.LocationName[this];
            set => fields.LocationName[this] = value;
        }

        [DisplayName("Items"), MasterDetailRelation(foreignKey: "PositiveAdjustmentId"), NotMapped]
        public List<PositiveAdjustmentDetailRow> ItemList
        {
            get => fields.ItemList[this];
            set => fields.ItemList[this] = value;
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

        public PositiveAdjustmentRow()
            : base()
        {
        }

        public PositiveAdjustmentRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : LoggingRowFields
        {
            public Int32Field Id;
            public StringField Number;
            public StringField Description;
            public DateTimeField AdjustmentDate;
            public Int32Field ProjectId;

            public Int32Field WarehouseId;
            public Int32Field LocationId;
            public DoubleField TotalQty;
            public StringField ProjectName;

            public StringField WarehouseName;
            public StringField LocationName;
            public RowListField<PositiveAdjustmentDetailRow> ItemList;
            public Int32Field TenantId;
            public StringField TenantName;
        }
    }
}
