using Indotalent.Web.Modules.Projects.Project;
using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;
using System.IO;
using Indotalent.Web.Modules.General.Template;
using Indotalent.Web.Modules.General.Action;


namespace Indotalent.General
{
    [ConnectionKey("Default"), Module("General"), TableName("[dbo].[ActionNotification]")]
    [DisplayName("Action Notification"), InstanceName("Action Notification")]
    [ReadPermission("General:ActionNotification")]
    [ModifyPermission("General:ActionNotification")]
    [LookupScript(LookupType = typeof(MultiTenantRowLookupScript<>))]
    public sealed class ActionNotificationRow : Row<ActionNotificationRow.RowFields>, IIdRow, INameRow, IMultiTenantRow
    {
        [DisplayName("Id"), Identity, IdProperty]
        public Int32? Id
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
        }


        [DisplayName("Action Id"), ForeignKey("Action", "Id"), LeftJoin("jAction")]
        
		//[DisplayName("Action Id "), Column("ActionId "), NotNull, ForeignKey("[dbo].[Action]", "Id"), LeftJoin("jAction"), TextualField("ActionActionName")]
		[LookupEditor(typeof(ActionLookup), InplaceAdd = false)]
		public Int32? ActionId
        {
            get => fields.ActionId[this];
            set => fields.ActionId[this] = value;
        }

        [DisplayName("Template Id "), Column("TemplateId "), NotNull, ForeignKey("[dbo].[Template]", "Id"), LeftJoin("jTemplate"), TextualField("TemplateTemplateName")]
        [LookupEditor(typeof(TemplateLookup), InplaceAdd = false)]

		public Int32? TemplateId
        {
            get => fields.TemplateId[this];
            set => fields.TemplateId[this] = value;
        }

        [DisplayName("Email Recipient"), Size(2500), NotNull, QuickSearch, NameProperty]
        public String EmailRecipient
        {
            get => fields.EmailRecipient[this];
            set => fields.EmailRecipient[this] = value;
        }

        [DisplayName("Whatsapp Recipient"), Column("whatsappRecipient"), Size(250)]
        public String WhatsappRecipient
        {
            get => fields.WhatsappRecipient[this];
            set => fields.WhatsappRecipient[this] = value;
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
		[DisplayName("Action Action Name "), Expression("jAction.[ActionName ]")]
        public String ActionActionName
        {
            get => fields.ActionActionName[this];
            set => fields.ActionActionName[this] = value;
        }

        [DisplayName("Action Description"), Expression("jAction.[Description]")]
        public String ActionDescription
        {
            get => fields.ActionDescription[this];
            set => fields.ActionDescription[this] = value;
        }

        [DisplayName("Action Insert Date"), Expression("jAction.[InsertDate]")]
        public DateTime? ActionInsertDate
        {
            get => fields.ActionInsertDate[this];
            set => fields.ActionInsertDate[this] = value;
        }

        [DisplayName("Action Insert User Id"), Expression("jAction.[InsertUserId]")]
        public Int32? ActionInsertUserId
        {
            get => fields.ActionInsertUserId[this];
            set => fields.ActionInsertUserId[this] = value;
        }

        [DisplayName("Action Update Date"), Expression("jAction.[UpdateDate]")]
        public DateTime? ActionUpdateDate
        {
            get => fields.ActionUpdateDate[this];
            set => fields.ActionUpdateDate[this] = value;
        }

        [DisplayName("Action Update User Id"), Expression("jAction.[UpdateUserId]")]
        public Int32? ActionUpdateUserId
        {
            get => fields.ActionUpdateUserId[this];
            set => fields.ActionUpdateUserId[this] = value;
        }

        [DisplayName("Action Is Active"), Expression("jAction.[IsActive]")]
        public Boolean? ActionIsActive
        {
            get => fields.ActionIsActive[this];
            set => fields.ActionIsActive[this] = value;
        }

        [DisplayName("Action Tenant Id"), Expression("jAction.[TenantId]")]
        public Int32? ActionTenantId
        {
            get => fields.ActionTenantId[this];
            set => fields.ActionTenantId[this] = value;
        }

        [DisplayName("Template Template Name "), Expression("jTemplate.[TemplateName ]")]
        public String TemplateTemplateName
        {
            get => fields.TemplateTemplateName[this];
            set => fields.TemplateTemplateName[this] = value;
        }

        [DisplayName("Template Body"), Expression("jTemplate.[Body]")]
        public String TemplateBody
        {
            get => fields.TemplateBody[this];
            set => fields.TemplateBody[this] = value;
        }

        [DisplayName("Template Parameter"), Expression("jTemplate.[Parameter]")]
        public String TemplateParameter
        {
            get => fields.TemplateParameter[this];
            set => fields.TemplateParameter[this] = value;
        }

        [DisplayName("Template Insert Date"), Expression("jTemplate.[InsertDate]")]
        public DateTime? TemplateInsertDate
        {
            get => fields.TemplateInsertDate[this];
            set => fields.TemplateInsertDate[this] = value;
        }

        [DisplayName("Template Insert User Id"), Expression("jTemplate.[InsertUserId]")]
        public Int32? TemplateInsertUserId
        {
            get => fields.TemplateInsertUserId[this];
            set => fields.TemplateInsertUserId[this] = value;
        }

        [DisplayName("Template Update Date"), Expression("jTemplate.[UpdateDate]")]
        public DateTime? TemplateUpdateDate
        {
            get => fields.TemplateUpdateDate[this];
            set => fields.TemplateUpdateDate[this] = value;
        }

        [DisplayName("Template Update User Id"), Expression("jTemplate.[UpdateUserId]")]
        public Int32? TemplateUpdateUserId
        {
            get => fields.TemplateUpdateUserId[this];
            set => fields.TemplateUpdateUserId[this] = value;
        }

        [DisplayName("Template Is Active"), Expression("jTemplate.[IsActive]")]
        public Boolean? TemplateIsActive
        {
            get => fields.TemplateIsActive[this];
            set => fields.TemplateIsActive[this] = value;
        }

        [DisplayName("Template Tenant Id"), Expression("jTemplate.[TenantId]")]
        public Int32? TemplateTenantId
        {
            get => fields.TemplateTenantId[this];
            set => fields.TemplateTenantId[this] = value;
        }

        public ActionNotificationRow()
            : base()
        {
        }

        public ActionNotificationRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field Id;
            public Int32Field ActionId;
            public Int32Field TemplateId;
            public StringField EmailRecipient;
            public StringField WhatsappRecipient;
            public DateTimeField InsertDate;
            public Int32Field InsertUserId;
            public DateTimeField UpdateDate;
            public Int32Field UpdateUserId;
            public BooleanField IsActive;
            public Int32Field TenantId;

            public StringField ActionActionName;
            public StringField ActionDescription;
            public DateTimeField ActionInsertDate;
            public Int32Field ActionInsertUserId;
            public DateTimeField ActionUpdateDate;
            public Int32Field ActionUpdateUserId;
            public BooleanField ActionIsActive;
            public Int32Field ActionTenantId;

            public StringField TemplateTemplateName;
            public StringField TemplateBody;
            public StringField TemplateParameter;
            public DateTimeField TemplateInsertDate;
            public Int32Field TemplateInsertUserId;
            public DateTimeField TemplateUpdateDate;
            public Int32Field TemplateUpdateUserId;
            public BooleanField TemplateIsActive;
            public Int32Field TemplateTenantId;
            public StringField TenantName;
        }
    }
}
