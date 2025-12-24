using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;
using System.IO;

namespace Indotalent.WhatsApp
{
    [ConnectionKey("Default"), Module("WhatsApp"), TableName("[dbo].[WhatsAppTemplate]")]
    [DisplayName("Whats App Template"), InstanceName("Whats App Template")]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    public sealed class WhatsAppTemplateRow : Row<WhatsAppTemplateRow.RowFields>, IIdRow, INameRow
    {
        [DisplayName("Id"), Identity, IdProperty]
        public Int32? Id
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
        }

        [DisplayName("Name"), Size(100), NotNull, QuickSearch, NameProperty]
        public String Name
        {
            get => fields.Name[this];
            set => fields.Name[this] = value;
        }

        [DisplayName("Phone Number"), Size(100), NotNull]
        public String PhoneNumber
        {
            get => fields.PhoneNumber[this];
            set => fields.PhoneNumber[this] = value;
        }

        [DisplayName("Template Name"), Size(100), NotNull]
        public String TemplateName
        {
            get => fields.TemplateName[this];
            set => fields.TemplateName[this] = value;
        }

        [DisplayName("Broadcast Name"), Size(100), NotNull]
        public String BroadcastName
        {
            get => fields.BroadcastName[this];
            set => fields.BroadcastName[this] = value;
        }

        [DisplayName("Url"), Size(100)]
        public String Url
        {
            get => fields.Url[this];
            set => fields.Url[this] = value;
        }

        [DisplayName("Is Attachment Req"), NotNull]
        public Boolean? IsAttachmentReq
        {
            get => fields.IsAttachmentReq[this];
            set => fields.IsAttachmentReq[this] = value;
        }

		[DisplayName("Is Sent"), NotNull]
		public Boolean? IsSent
		{
			get => fields.IsSent[this];
			set => fields.IsSent[this] = value;
		}

		/*[DisplayName("Is Active"), NotNull]
        public Boolean? IsActive
        {
            get => fields.IsActive[this];
            set => fields.IsActive[this] = value;
        }*/

        [DisplayName("Tenant"), ForeignKey("[dbo].[Tenant]", "TenantId"), LeftJoin("jTenant"), TextualField("TenantTenantName")]
        public Int32? TenantId
        {
            get => fields.TenantId[this];
            set => fields.TenantId[this] = value;
        }

        [DisplayName("Tenant Name"), Expression("jTenant.[TenantName]")]
        public String TenantName
        {
            get => fields.TenantName[this];
            set => fields.TenantName[this] = value;
        }

        public WhatsAppTemplateRow()
            : base()
        {
        }

        public WhatsAppTemplateRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field Id;
            public StringField Name;
            public StringField PhoneNumber;
            public StringField TemplateName;
            public StringField BroadcastName;
            public StringField Url;
            public BooleanField IsAttachmentReq;
			public BooleanField IsSent;
			//public BooleanField IsActive;
            public Int32Field TenantId;
            public StringField TenantName;
        }
    }
}
