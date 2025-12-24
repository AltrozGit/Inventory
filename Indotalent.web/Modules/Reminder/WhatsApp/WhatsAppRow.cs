using DocumentFormat.OpenXml.Wordprocessing;
using Indotalent.Settings;

using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using Serenity.Extensions.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Indotalent.Reminder
{
    [ConnectionKey("Default"), Module("Reminder"), TableName("[dbo].[WhatsApp]")]
    [DisplayName("Whats App"), InstanceName("Whats App")]
    [ReadPermission("Reminder:WhatsApp")]
    [ModifyPermission("Reminder:WhatsApp")]
    [LookupScript(LookupType = typeof(MultiTenantRowLookupScript<>))]
    public sealed class WhatsAppRow : LoggingRow<WhatsAppRow.RowFields>, IIdRow, INameRow, IMultiTenantRow
    {
        [DisplayName("Id"), Identity, IdProperty, QuickSearch]
        public Int32? Id
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
        }

        [DisplayName("Template Name"), Size(100), NotNull, QuickSearch, NameProperty]
        public String TemplateName
        {
            get => fields.TemplateName[this];
            set => fields.TemplateName[this] = value;
        }

        [DisplayName("Broadcast Name"), Size(100), NotNull, QuickSearch]
        public String BroadcastName
        {
            get => fields.BroadcastName[this];
            set => fields.BroadcastName[this] = value;
        }

        [DisplayName("Url"), Size(100), QuickSearch]
        public String Url
        {
            get => fields.Url[this];
            set => fields.Url[this] = value;
        }

        [DisplayName("Is Active"), NotNull, QuickSearch]
        public Boolean? IsActive
        {
            get => fields.IsActive[this];
            set => fields.IsActive[this] = value;
        }

        [DisplayName("Tenant"), ForeignKey("Tenant", "TenantId"), LeftJoin("jTenant"), QuickSearch]
        [Insertable(false), Updatable(false)]
        public Int32? TenantId
        {
            get { return Fields.TenantId[this]; }
            set { Fields.TenantId[this] = value; }
        }

        [DisplayName("Tenant"), Expression("jTenant.TenantName"), QuickSearch]
        public String TenantName
        {
            get { return Fields.TenantName[this]; }
            set { Fields.TenantName[this] = value; }
        }

        public Int32Field TenantIdField
        {
            get { return Fields.TenantId; }
        }
        public WhatsAppRow()
            : base()
        {
        }

        public WhatsAppRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : LoggingRowFields
        {
            public Int32Field Id;
            public StringField TemplateName;
            public StringField BroadcastName;
            public StringField Url;
            public BooleanField IsActive;
            public Int32Field TenantId;
            public StringField TenantName;
        }
    }
}
