using Amazon.CloudWatchLogs;
using Indotalent.Administration.Lookups;
using Indotalent.Projects;
using Indotalent.Web.Modules.Material.Request;
using Indotalent.Web.Modules.Projects.Project;
using MailKit.Search;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Logical;
using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using Serenity.Extensions.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;


namespace Indotalent.Material
{
    [ConnectionKey("Default"), Module("Material"), TableName("[dbo].[MaterialRequest]")]
    [DisplayName("Request"), InstanceName("Request")]
    [ReadPermission("Material:Request")]
    [ModifyPermission("Material:Request")]
    [LookupScript(LookupType = typeof(MultiTenantRowLookupScript<>))]
    public sealed class RequestRow : LoggingRow<RequestRow.RowFields>, IIdRow, INameRow, IMultiTenantRow
    {
        [DisplayName("Id"), Identity, IdProperty]
        public Int32? Id
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
        }
        [DisplayName("Number"), Size(200), NotNull, QuickSearch, NameProperty, DefaultValue("auto")]
       
       
        public String Number
        {
            get => fields.Number[this];
            set => fields.Number[this] = value;
        }

        [DisplayName("Description"), Size(1000), Updatable(false)]
        public String Description
        {
            get => fields.Description[this];
            set => fields.Description[this] = value;
        }

        [DisplayName("Request Date"), NotNull, Updatable(false), QuickSearch]
        public DateTime? RequestDate
        {
            get => fields.RequestDate[this];
            set => fields.RequestDate[this] = value;
        }


        [DisplayName("Project"), NotNull, ForeignKey("[dbo].[Project]", "Id"), LeftJoin("jProject"), TextualField("ProjectName"), Updatable(false), QuickSearch]
        [LookupEditor(typeof(ProjectLookup), InplaceAdd = true, DialogType = "Indotalent.Projects.ProjectDialog")]
        public Int32? ProjectId
        {
            get => fields.ProjectId[this];
            set => fields.ProjectId[this] = value;
        }

		[DisplayName("Delivery Date"), NotNull, Updatable(false), QuickSearch]
        public DateTime? DeliveryDate
        {
            get => fields.DeliveryDate[this];
            set => fields.DeliveryDate[this] = value;
        }

       
        [DisplayName("Total Qty Request"), NotNull, QuickSearch]
        [DefaultValue(0), Insertable(false), Updatable(false)]
        public Double? TotalQtyRequest
        {
            get => fields.TotalQtyRequest[this];
            set => fields.TotalQtyRequest[this] = value;
        }

        [DisplayName("Total")]
        public Double? Total
        {
            get => fields.Total[this];
            set => fields.Total[this] = value;
        }

		[DisplayName("Status"), NotNull]
		[DefaultValue(1)]
		public RequestStatus? RequestStatus
		{
			get => (RequestStatus?)fields.RequestStatus[this];
			set => fields.RequestStatus[this] = (Int32?)value;
		}


		[DisplayName("Project"), Expression("jProject.[Name]"), Updatable(false)]
        public String ProjectName
        {
            get => fields.ProjectName[this];
            set => fields.ProjectName[this] = value;
        }

        [DisplayName("Items"), MasterDetailRelation(foreignKey: "MaterialRequestId"), NotMapped]
        public List<RequestDetailRow> ItemList
        {
            get => fields.ItemList[this];
            set => fields.ItemList[this] = value;
        }

        [DisplayName("IsPOCreated")]
        public Boolean? IsPOComplete
        {
            get => fields.IsPOComplete[this];
            set => fields.IsPOComplete[this] = value;
        }

        //for Issue
        [DisplayName("IsIssueCreated")]
        public Boolean? IsIssueCreated
        {
            get => fields.IsIssueCreated[this];
            set => fields.IsIssueCreated[this] = value;
        }
        

        [DisplayName("ProjectMaterial Request No")]
        [DefaultValue(0)]
        public Int32? ProjectMaterialRequestId
        {
            get => fields.ProjectMaterialRequestId[this];
            set => fields.ProjectMaterialRequestId[this] = value;
        }

        //[DisplayName("ProjectMaterial Request No"), Expression("jProjectMaterialRequest.[Number]"), MinSelectLevel(SelectLevel.List), QuickSearch]
        //[Insertable(false), Updatable(false)]

        //public String ProjectMaterialRequestNumber
        //{
        //    get => fields.ProjectMaterialRequestNumber[this];
        //    set => fields.ProjectMaterialRequestNumber[this] = value;
        //}

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

        [DisplayName("Comments"), MasterDetailRelation(foreignKey: "MaterialRequestId"), NotMapped]

        public List<MaterialRequestTrackingRow> CommentList
        {
            get => fields.CommentList[this];
            set => fields.CommentList[this] = value;
        }
        [DisplayName("Status"), MasterDetailRelation(foreignKey: "MaterialRequestId"), NotMapped]
        public List<MaterialRequestStatusRow> StatusList
        {
            get => fields.StatusList[this];
            set => fields.StatusList[this] = value;
        }

        public Int32Field TenantIdField
        {
            get { return Fields.TenantId; }
        }
        public RequestRow()
            : base()
        {
        }

        public RequestRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : LoggingRowFields
        {
            public Int32Field Id;
            public StringField Number;
            public StringField Description;
            public DateTimeField RequestDate;
            public Int32Field ProjectId;
            public StringField ProjectName;
            public DateTimeField DeliveryDate;
            public BooleanField IsPOComplete;
            public BooleanField IsIssueCreated;

            public RowListField<RequestDetailRow> ItemList;
            public DoubleField TotalQtyRequest;
            public DoubleField Total;
            public RowListField<MaterialRequestTrackingRow> CommentList;
            public RowListField<MaterialRequestStatusRow> StatusList;
            public Int32Field TenantId;      
            public StringField TenantName;
			public Int32Field RequestStatus;
            public Int32Field ProjectMaterialRequestId;
           // public StringField ProjectMaterialRequestNumber;



        }
    }
}
