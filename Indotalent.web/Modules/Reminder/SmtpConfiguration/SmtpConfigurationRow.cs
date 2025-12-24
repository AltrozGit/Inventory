using Indotalent.Web.Common;
using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using Serenity.Extensions.Entities;
using System;
using System.ComponentModel;
using System.IO;

namespace Indotalent.Reminder
{
    [ConnectionKey("Default"), Module("Reminder"), TableName("[dbo].[SmtpConfiguration]")]
    [DisplayName("Smtp Configuration"), InstanceName("Smtp Configuration")]
    [ReadPermission("Reminder:SmtpConfiguration")]
    [ModifyPermission("Reminder:SmtpConfiguration")]
    [LookupScript(LookupType = typeof(MultiTenantRowLookupScript<>))]

    public sealed class SmtpConfigurationRow : LoggingRow<SmtpConfigurationRow.RowFields>, IIdRow, INameRow, IMultiTenantRow
    {
        [DisplayName("Id"), Identity, IdProperty]
        public Int32? Id
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
        }

        [DisplayName("Host"), Size(255), NotNull, QuickSearch]
        public String Host
        {
            get => fields.Host[this];
            set => fields.Host[this] = value;
        }
        
       


        [DisplayName("Port"), NotNull]
        public Int32? Port
        {
            get => fields.Port[this];
            set => fields.Port[this] = value;
        }

        [DisplayName("From Address"), Size(255), NotNull, NameProperty]
        public String FromAddress
        {
            get => fields.FromAddress[this];
            set => fields.FromAddress[this] = value;
        }

        [DisplayName("User Name"), Size(255), NotNull]
        public String UserName
        {
            get => fields.UserName[this];
            set => fields.UserName[this] = value;
        }

        [DisplayName("Password"), Size(255), NotNull]
        public String Password
        {
            get => fields.Password[this];
            set => fields.Password[this] = value;
        }

        [DisplayName("Enable Ssl"), NotNull]
        public Boolean? EnableSsl
        {
            get => fields.EnableSsl[this];
            set => fields.EnableSsl[this] = value;
        }
        [DisplayName("Is Smtp Acive"), NotNull]
        public Boolean? IsSmtpActive
        {
            get => fields.IsSmtpActive[this];
            set => fields.IsSmtpActive[this] = value;
        }
        [DisplayName("Is Default")]
        public Boolean? IsDefault
        {
            get => fields.IsDefault[this];
            set => fields.IsDefault[this] = value;
        }
        [DisplayName("Description"), Size(1000)]
        public String Description
        {
            get => fields.Description[this];
            set => fields.Description[this] = value;
        }

        [DisplayName("Address"), Size(255)]
        public String Address
        {
            get => fields.Address[this];
            set => fields.Address[this] = value;
        }

        [DisplayName("Phone"), Size(50)]
        public String Phone
        {
            get => fields.Phone[this];
            set => fields.Phone[this] = value;
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

     
        [DisplayName("Source System"), Size(50), NotNull]
        public String SourceSystem
        {
            get => fields.SourceSystem[this];
            set => fields.SourceSystem[this] = value;
        }
      
        public SmtpConfigurationRow()
            : base()
        {
        }

        public SmtpConfigurationRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : LoggingRowFields
        {
            public Int32Field Id;
            public StringField Host;
            public Int32Field Port;
            public StringField FromAddress;
            public StringField UserName;
            public StringField Password;
            public BooleanField EnableSsl;
            public StringField Description;
            public StringField Address;
            public StringField Phone;
            public Int32Field TenantId;
            public BooleanField IsSmtpActive;
            public BooleanField IsDefault;

            public StringField SourceSystem;
            public StringField TenantName;

        }
    }
}
