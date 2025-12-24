using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;
using System.IO;
using Serenity.Extensions.Entities;

namespace Indotalent.Projects
{
    [ConnectionKey("Default"), Module("Projects"), TableName("[dbo].[ProjectFund]")]
    [DisplayName("Project Fund"), InstanceName("Project Fund")]
    [ReadPermission("Projects:ProjectFund")]
    [ModifyPermission("Projects:ProjectFund")]
    [LookupScript(LookupType = typeof(MultiTenantRowLookupScript<>))]
    public sealed class ProjectFundRow : LoggingRow<ProjectFundRow.RowFields>, IIdRow, IMultiTenantRow
    {
        [DisplayName("Id"), Identity, IdProperty]
        public Int32? Id
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
        }

        [DisplayName("Project"), NotNull, ForeignKey("[dbo].[Project]", "Id"), LeftJoin("jProject"), TextualField("ProjectName")]
        public Int32? ProjectId
        {
            get => fields.ProjectId[this];
            set => fields.ProjectId[this] = value;
        }

        [DisplayName("Add Fund"), NotNull]
        public Double? AddedFund
        {
            get => fields.AddedFund[this];
            set => fields.AddedFund[this] = value;
        }

        [DisplayName("Funding Date"), NotNull]
        public DateTime? FundingDate
        {
            get => fields.FundingDate[this];
            set => fields.FundingDate[this] = value;
        }

        [DisplayName("Description"), Size(1000)]
        public String Description
        {
            get => fields.Description[this];
            set => fields.Description[this] = value;
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

        public ProjectFundRow()
            : base()
        {
        }

        public ProjectFundRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : LoggingRowFields
        {
            public Int32Field Id;
            public Int32Field ProjectId;
            public DoubleField AddedFund;
            public DateTimeField FundingDate;
            public StringField Description;
            public Int32Field TenantId;           
            public StringField TenantName;
        }
    }
}
