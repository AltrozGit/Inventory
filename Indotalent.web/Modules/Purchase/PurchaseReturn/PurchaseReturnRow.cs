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

namespace Indotalent.Purchase
{
    [ConnectionKey("Default"), Module("Purchase"), TableName("[dbo].[PurchaseReturn]")]
    [DisplayName("Purchase Return"), InstanceName("Purchase Return")]
    [LookupScript(LookupType = typeof(MultiTenantRowLookupScript<>))]
    [ReadPermission("Purchase:PurchaseReturn")]
    [ModifyPermission("Purchase:PurchaseReturn")]
    public sealed class PurchaseReturnRow : Row<PurchaseReturnRow.RowFields>, IIdRow, INameRow, IMultiTenantRow
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

        [DisplayName("Return Date"), NotNull, QuickSearch]
        public DateTime? ReturnDate
        {
            get => fields.ReturnDate[this];
            set => fields.ReturnDate[this] = value;
        }

        [DisplayName("Purchase Receipt"), NotNull, ForeignKey("[dbo].[PurchaseReceipt]", "Id"), QuickSearch, LeftJoin("jPurchaseReceipt"), TextualField("PurchaseReceiptNumber")]
        [LookupEditor(typeof(PurchaseReceiptRow))]
        [Updatable(false)]
        public Int32? PurchaseReceiptId
        {
            get => fields.PurchaseReceiptId[this];
            set => fields.PurchaseReceiptId[this] = value;
        }

        [DisplayName("Project"),NotNull, ForeignKey("[dbo].[Project]", "Id"), LeftJoin("jProject"), TextualField("ProjectName")]
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

        [DisplayName("Total Qty Return"), NotNull, QuickSearch]
        [DefaultValue(0), Insertable(false), Updatable(false)]
        public Double? TotalQtyReturn
        {
            get => fields.TotalQtyReturn[this];
            set => fields.TotalQtyReturn[this] = value;
        }

        [DisplayName("Purchase Receipt"), Expression("jPurchaseReceipt.[Number]"), QuickSearch]
        public String PurchaseReceiptNumber
        {
            get => fields.PurchaseReceiptNumber[this];
            set => fields.PurchaseReceiptNumber[this] = value;
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

        [DisplayName("Items"), MasterDetailRelation(foreignKey: "PurchaseReturnId"), NotMapped]
        public List<PurchaseReturnDetailRow> ItemList
        {
            get => fields.ItemList[this];
            set => fields.ItemList[this] = value;
        }

        [DisplayName("Purchase Order"), Expression("jPurchaseReceipt.[PurchaseOrderId]"), ForeignKey("[dbo].[PurchaseOrder]", "Id"), LeftJoin("jPurchaseOrder")]
        public Int32? PurchaseOrderId
        {
            get => fields.PurchaseOrderId[this];
            set => fields.PurchaseOrderId[this] = value;
        }

        [DisplayName("Procurement"), Size(200)]
        public String ProcurementGroup
        {
            get => fields.ProcurementGroup[this];
            set => fields.ProcurementGroup[this] = value;
        }

        [DisplayName("Vendor"), Expression("jPurchaseOrder.[VendorId]"), ForeignKey("[dbo].[Vendor]", "Id"), LeftJoin("jVendor")]
        public Int32? VendorId
        {
            get => fields.VendorId[this];
            set => fields.VendorId[this] = value;
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

        public PurchaseReturnRow()
            : base()
        {
        }

        public PurchaseReturnRow(RowFields fields)
            : base(fields)
        {
        }


        public class RowFields : RowFieldsBase
        {
            public Int32Field Id;
            public StringField Number;
            public StringField Description;
            public StringField ProcurementGroup;
            public DateTimeField ReturnDate;
            public Int32Field PurchaseOrderId;
            public Int32Field PurchaseReceiptId;
            public Int32Field ProjectId;
            public Int32Field WarehouseId;
            public Int32Field LocationId;
            public DoubleField TotalQtyReturn;
            public StringField PurchaseReceiptNumber;
            public StringField ProjectName;

            public StringField WarehouseName;
            public StringField LocationName;
            public RowListField<PurchaseReturnDetailRow> ItemList;
            public Int32Field VendorId;
            public Int32Field TenantId;
            public StringField TenantName;
        }
    }
}
