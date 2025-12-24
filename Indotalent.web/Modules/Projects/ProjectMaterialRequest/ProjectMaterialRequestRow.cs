using Amazon.CloudWatchLogs;
using Indotalent.Administration.Lookups;
using Indotalent.Projects;
using Indotalent.Web.Modules.Projects.Project;
using Indotalent.Web.Modules.Projects.ProjectMaterialRequest;
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

namespace Indotalent.Projects
{
    [ConnectionKey("Default"), Module("Projects"), TableName("[dbo].[ProjectMaterialRequest]")]
    [DisplayName("Project Material Request"), InstanceName("Project Material Request")]
    [ReadPermission("Projects:ProjectMaterialRequest")]
    [ModifyPermission("Projects:ProjectMaterialRequest")]
    public sealed class ProjectMaterialRequestRow : LoggingRow<ProjectMaterialRequestRow.RowFields>, IIdRow, INameRow, IMultiTenantRow
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

        [DisplayName("Items"), MasterDetailRelation(foreignKey: "ProjectMaterialRequestId"), NotMapped]
        public List<ProjectMaterialRequestDetailRow> ItemList
        {
            get => fields.ItemList[this];
            set => fields.ItemList[this] = value;
        }

        [DisplayName("Item Id"), NotMapped]
        public Int32? ItemId
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
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
        public ProjectMaterialRequestRow()
            : base()
        {
        }

        public ProjectMaterialRequestRow(RowFields fields)
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
            public RowListField<ProjectMaterialRequestDetailRow> ItemList;
            public DoubleField TotalQtyRequest;
            public DoubleField Total;
            public Int32Field ItemId;
          
            public Int32Field TenantId;
            public StringField TenantName;
			public Int32Field RequestStatus;

		}
    }
}
