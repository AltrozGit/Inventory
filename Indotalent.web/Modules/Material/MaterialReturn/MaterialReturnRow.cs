using Indotalent.Web.Modules.Inventory.Location;
using Indotalent.Web.Modules.Inventory.Warehouse;
using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace Indotalent.Material
{
    [ConnectionKey("Default"), Module("Material"), TableName("[dbo].[MaterialReturn]")]
    [DisplayName("Material Return"), InstanceName("Material Return")]
    [LookupScript(LookupType = typeof(MultiTenantRowLookupScript<>))]
    [ReadPermission("Material:MaterialReturn")]
    [ModifyPermission("Material:MaterialReturn")]
    public sealed class MaterialReturnRow : Row<MaterialReturnRow.RowFields>, IIdRow, INameRow, IMultiTenantRow
    {
        [DisplayName("Id"), Identity, IdProperty]
        public Int32? Id
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
        }

        [DisplayName("Number"), Size(200), NotNull, QuickSearch, NameProperty]
        [DefaultValue("auto")]
        [Insertable(false), Updatable(false)]
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


        [DisplayName("Return Date"), NotNull]
        [DefaultValue("now")]
        public DateTime? ReturnDate
        {
            get => fields.ReturnDate[this];
            set => fields.ReturnDate[this] = value;
        }

        [DisplayName("Material Issue"), NotNull, ForeignKey("[dbo].[MaterialIssue]", "Id"), LeftJoin("jMaterialIssue"), TextualField("MaterialIssueNumber")]
        [LookupEditor(typeof(IssueRow))]
        public Int32? MaterialIssueId
        {
            get => fields.MaterialIssueId[this];
            set => fields.MaterialIssueId[this] = value;
        }

        [DisplayName("Project"), NotNull, ForeignKey("[dbo].[Project]", "Id"), LeftJoin("jProject"), TextualField("ProjectName")]
        [LookupEditor(typeof(Projects.ProjectRow), InplaceAdd = true)]
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


        [DisplayName("Material Issue Number"), Expression("jMaterialIssue.[Number]")]
        public String MaterialIssueNumber
        {
            get => fields.MaterialIssueNumber[this];
            set => fields.MaterialIssueNumber[this] = value;
        }


        [DisplayName("Project Name"), Expression("jProject.[Name]")]
        public String ProjectName
        {
            get => fields.ProjectName[this];
            set => fields.ProjectName[this] = value;
        }



        [DisplayName("Warehouse Name"), Expression("jWarehouse.[Name]")]
        public String WarehouseName
        {
            get => fields.WarehouseName[this];
            set => fields.WarehouseName[this] = value;
        }


        [DisplayName("Location Name"), Expression("jLocation.[Name]")]
        public String LocationName
        {
            get => fields.LocationName[this];
            set => fields.LocationName[this] = value;
        }

        [DisplayName("Items"), MasterDetailRelation(foreignKey: "MaterialReturnId"), NotMapped]
        public List<MaterialReturnDetailRow> ItemList
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

        
        public MaterialReturnRow()
            : base()
        {
        }

        public MaterialReturnRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field Id;
            public StringField Number;
            public StringField Description;

            public DateTimeField ReturnDate;
            public Int32Field MaterialIssueId;
            public Int32Field ProjectId;
            public Int32Field WarehouseId;
            public Int32Field LocationId;
            public RowListField<MaterialReturnDetailRow> ItemList;
            public DoubleField TotalQtyReturn;

            public StringField MaterialIssueNumber;

            public StringField ProjectName;

            public StringField WarehouseName;
            public Int32Field TenantId;
            public StringField TenantName;

            public StringField LocationName;
        }
    }
}
