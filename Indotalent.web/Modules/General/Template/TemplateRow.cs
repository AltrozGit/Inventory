using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;
using System.IO;

namespace Indotalent.General
{
    [ConnectionKey("Default"), Module("General"), TableName("[dbo].[Template]")]
    [DisplayName("Template"), InstanceName("Template")]
    [ReadPermission("General:Template")]
    [ModifyPermission("General:Template")]
	[LookupScript(LookupType = typeof(MultiTenantRowLookupScript<>))]
	public sealed class TemplateRow : Row<TemplateRow.RowFields>, IIdRow, INameRow, IMultiTenantRow
	{
        [DisplayName("Id"), Identity, IdProperty]
        public Int32? Id
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
        }

        [DisplayName("Template Name "), Column("TemplateName "), Size(200), NotNull, QuickSearch, NameProperty]
        public String TemplateName
        {
            get => fields.TemplateName[this];
            set => fields.TemplateName[this] = value;
        }

        [DisplayName("Body"), Size(2500), NotNull]
        public String Body
        {
            get => fields.Body[this];
            set => fields.Body[this] = value;
        }

        [DisplayName("Parameter"), Size(250)]
        public String Parameter
        {
            get => fields.Parameter[this];
            set => fields.Parameter[this] = value;
        }

        [DisplayName("Insert Date")]
        public DateTime? InsertDate
        {
            get => fields.InsertDate[this];
            set => fields.InsertDate[this] = value;
        }

        [DisplayName("Insert User Id")]
        public Int32? InsertUserId
        {
            get => fields.InsertUserId[this];
            set => fields.InsertUserId[this] = value;
        }

        [DisplayName("Update Date")]
        public DateTime? UpdateDate
        {
            get => fields.UpdateDate[this];
            set => fields.UpdateDate[this] = value;
        }

        [DisplayName("Update User Id")]
        public Int32? UpdateUserId
        {
            get => fields.UpdateUserId[this];
            set => fields.UpdateUserId[this] = value;
        }

        [DisplayName("Is Active")]
        public Boolean? IsActive
        {
            get => fields.IsActive[this];
            set => fields.IsActive[this] = value;
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

		public TemplateRow()
            : base()
        {
        }

        public TemplateRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field Id;
            public StringField TemplateName;
            public StringField Body;
            public StringField Parameter;
            public DateTimeField InsertDate;
            public Int32Field InsertUserId;
            public DateTimeField UpdateDate;
            public Int32Field UpdateUserId;
            public BooleanField IsActive;
            public Int32Field TenantId;
            public StringField TenantName;
        }
    }
}
