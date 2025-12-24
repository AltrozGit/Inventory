using Indotalent.Administration.Lookups;
using Indotalent.Inventory;
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
using Indotalent.Purchase;

namespace Indotalent.Material
{
    [ConnectionKey("Default"), Module("Material"), TableName("[dbo].[MaterialIssue]")]
    [DisplayName("Issue"), InstanceName("Issue")]
    [ReadPermission("Material:Issue")]
    [ModifyPermission("Material:Issue")]
    [LookupScript(LookupType = typeof(MultiTenantRowLookupScript<>))]

    public sealed class IssueRow : LoggingRow<IssueRow.RowFields>, IIdRow, INameRow, IMultiTenantRow
    {
        [DisplayName("Id"), Identity, IdProperty]
        public Int32? Id
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
        }
        [DisplayName("Issue No"), Size(200), NotNull, QuickSearch, NameProperty]
      
        [DefaultValue("auto")]
        public String Number
        {
            get => fields.Number[this];
            set => fields.Number[this] = value;
        }
        [DisplayName("Request No"), NotNull, ForeignKey("[dbo].[MaterialRequest]", "Id"), LeftJoin("jMaterialRequest"), TextualField("MaterialRequestNumber"), QuickSearch]
        [LookupEditor(typeof(RequestRow), InplaceAdd = true)]
        [Updatable(false)]
        public Int32? MaterialRequestId
        {
            get => fields.MaterialRequestId[this];
            set => fields.MaterialRequestId[this] = value;
        }

        [DisplayName("Request No"), Expression("jMaterialRequest.[Number]"), MinSelectLevel(SelectLevel.List), QuickSearch]
        [Insertable(false), Updatable(false)]

        public String MaterialRequestNumber
        {
            get => fields.MaterialRequestNumber[this];
            set => fields.MaterialRequestNumber[this] = value;
        }

        [DisplayName("Receipt No"), NotNull, QuickSearch]
        [LookupEditor(typeof(PurchaseReceiptRow), InplaceAdd = true)]
        [Updatable(false)]
        public Int32? PurchaseReceiptId
        {
            get => fields.PurchaseReceiptId[this];
            set => fields.PurchaseReceiptId[this] = value;
        }

        //[DisplayName("Receipt No"), Expression("jPurchaseReceipt.[Number]"), MinSelectLevel(SelectLevel.List), QuickSearch]
        //[Insertable(false), Updatable(false)]

        //public String PurchaseReceiptNumber
        //{
        //    get => fields.PurchaseReceiptNumber[this];
        //    set => fields.PurchaseReceiptNumber[this] = value;
        //}



        [DisplayName("Description"), Size(1000)]
        public String Description
        {
            get => fields.Description[this];
            set => fields.Description[this] = value;
        }

        [DisplayName("Issue Date"), NotNull, QuickSearch]
        public DateTime? IssueDate
        {
            get => fields.IssueDate[this];
            set => fields.IssueDate[this] = value;
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

		[DisplayName("Total Qty Issued"), NotNull, QuickSearch]
        [DefaultValue(0), Insertable(false), Updatable(false)]
        public Double? TotalQtyIssue
        {
            get => fields.TotalQtyIssue[this];
            set => fields.TotalQtyIssue[this] = value;
        }

        [DisplayName("Total")]
        public Double? Total
        {
            get => fields.Total[this];
            set => fields.Total[this] = value;
        }


        [DisplayName("Items"), MasterDetailRelation(foreignKey: "MaterialIssueId"), NotMapped]
        public List<IssueDetailRow> ItemList
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
        public IssueRow()
            : base()
        {
        }

        public IssueRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : LoggingRowFields
        {
            public Int32Field Id;
            public Int32Field MaterialRequestId;
            public StringField MaterialRequestNumber;
            public StringField Number;
            public StringField Description;
            public DateTimeField IssueDate;
            public Int32Field ProjectId;
            public StringField ProjectName;
            public RowListField<IssueDetailRow> ItemList;
            public DoubleField TotalQtyIssue;
            public DoubleField Total;
            public Int32Field TenantId;
            public Int32Field WarehouseId;
			public StringField WarehouseName;
			public StringField TenantName;
            public Int32Field PurchaseReceiptId;
            //public StringField PurchaseReceiptNumber;

        }
    }
}
