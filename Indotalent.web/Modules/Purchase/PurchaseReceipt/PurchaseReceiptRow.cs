using Indotalent.Purchase;
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
using Indotalent.Inventory;
using Indotalent.Web.Modules.Purchase.PurchaseReceipt;

namespace Indotalent.Purchase
{
    [ConnectionKey("Default"), Module("Purchase"), TableName("[dbo].[PurchaseReceipt]")]
    [DisplayName("Purchase Receipt"), InstanceName("Purchase Receipt")]
    [LookupScript(LookupType = typeof(MultiTenantRowLookupScript<>))]
    [ReadPermission("Purchase:PurchaseReceipt")]
    [ModifyPermission("Purchase:PurchaseReceipt")]
    public sealed class PurchaseReceiptRow : Row<PurchaseReceiptRow.RowFields>, IIdRow, INameRow, IMultiTenantRow
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

        [DisplayName("External Reference Number"), Size(200)]
        public String ExternalReferenceNumber
        {
            get => fields.ExternalReferenceNumber[this];
            set => fields.ExternalReferenceNumber[this] = value;
        }

        [DisplayName("Receipt Date"), NotNull, QuickSearch]
        public DateTime? ReceiptDate
        {
            get => fields.ReceiptDate[this];
            set => fields.ReceiptDate[this] = value;
        }

        [DisplayName("Purchase Order"), NotNull, ForeignKey("[dbo].[PurchaseOrder]", "Id"), QuickSearch, LeftJoin("jPurchaseOrder"), TextualField("PurchaseOrderNumber")]
        [LookupEditor(typeof(PurchaseOrderRow))]
        [Updatable(false)]
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

        [DisplayName("Project"),NotNull,ForeignKey("[dbo].[Project]", "Id"), LeftJoin("jProject"), TextualField("ProjectName"), QuickSearch]
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

        [DisplayName("Total Qty Receive"), NotNull, QuickSearch]
        [DefaultValue(0), Insertable(false), Updatable(false)]
        public Double? TotalQtyReceive
        {
            get => fields.TotalQtyReceive[this];
            set => fields.TotalQtyReceive[this] = value;
        }


        [DisplayName("Purchase Order"), Expression("jPurchaseOrder.[Number]"), QuickSearch]
        public String PurchaseOrderNumber
        {
            get => fields.PurchaseOrderNumber[this];
            set => fields.PurchaseOrderNumber[this] = value;
        }
        [DisplayName("Project"), Expression("jProject.[Name]"), QuickSearch]
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

        [DisplayName("Items"), MasterDetailRelation(foreignKey: "PurchaseReceiptId"), NotMapped]
        public List<PurchaseReceiptDetailRow> ItemList
        {
            get => fields.ItemList[this];
            set => fields.ItemList[this] = value;
        }

        [DisplayName("Vendor"), Expression("jPurchaseOrder.[VendorId]"), ForeignKey("[dbo].[Vendor]", "Id"), LeftJoin("jVendor")]
        public Int32? VendorId
        {
            get => fields.VendorId[this];
            set => fields.VendorId[this] = value;
        }

        [DisplayName("Vendor Name"), Expression("jVendor.[Name]")]
        [Updatable(false)]
        public String VendorName
        {
            get => fields.VendorName[this];
            set => fields.VendorName[this] = value;
        }

        [DisplayName("Invoice Number")]
        public String InvoiceNumber
        {
            get => fields.InvoiceNumber[this];
            set => fields.InvoiceNumber[this] = value;
        }

        [DisplayName("Invoice Date")]
        public DateTime? InvoiceDate
        {
            get => fields.InvoiceDate[this];
            set => fields.InvoiceDate[this] = value;
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
        [DisplayName("IsBillCreated")]
        public Boolean? IsBillCreate
        {
            get => fields.IsBillCreate[this];
            set => fields.IsBillCreate[this] = value;
        }

        [DisplayName("IsPReturnCreated")]
        public Boolean? IsPReturnCreated
        {
            get => fields.IsPReturnCreated[this];
            set => fields.IsPReturnCreated[this] = value;
        }


        [DisplayName("Status"), QuickSearch]
        [DefaultValue(1)]
        public Status? Status
        {
            get => fields.Status[this];
            set => Fields.Status[this] = value;
        }

        [DisplayName("IsIssueCreated")]
        public Boolean? IsIssueCreated
        {
            get => fields.IsIssueCreated[this];
            set => fields.IsIssueCreated[this] = value;
        }

        public Int32Field TenantIdField
        {
            get { return Fields.TenantId; }
        }

        public PurchaseReceiptRow()
            : base()
        {
        }

        public PurchaseReceiptRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field Id;
            public StringField Number;
            public StringField Description;
            public StringField ExternalReferenceNumber;
            public StringField ProcurementGroup;
            public DateTimeField ReceiptDate;
            public Int32Field PurchaseOrderId;
            public Int32Field ProjectId;
            public Int32Field WarehouseId;
            public Int32Field LocationId;
            public DoubleField TotalQtyReceive;
            public StringField PurchaseOrderNumber;
            public StringField ProjectName;
            public StringField WarehouseName;
            public StringField LocationName;
            public RowListField<PurchaseReceiptDetailRow> ItemList;
            public Int32Field VendorId;
            public StringField VendorName;
            public StringField InvoiceNumber;
            public DateTimeField InvoiceDate;
            public Int32Field TenantId;
            public StringField TenantName;
            public BooleanField IsBillCreate;
            public BooleanField IsIssueCreated;

            public EnumField<Status> Status;
            public BooleanField IsPReturnCreated;
            
        }
    }
}
