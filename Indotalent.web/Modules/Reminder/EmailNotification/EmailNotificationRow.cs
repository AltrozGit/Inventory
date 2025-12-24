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
    [ConnectionKey("Default"), Module("Reminder"), TableName("[dbo].[EmailNotification]")]
    [DisplayName("Email Notification"), InstanceName("Email Notification")]
    [ReadPermission("Reminder:EmailNotification")]
    [ModifyPermission("Reminder:EmailNotification")]
   

    public sealed class EmailNotificationRow : LoggingRow<EmailNotificationRow.RowFields>, IIdRow, INameRow
    {
        [DisplayName("Id"), Identity, IdProperty]
        public Int32? Id
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
        }
        [DisplayName("Bulk Email Sender"), ForeignKey("[dbo].[BulkEmailSender]", "Id"), LeftJoin("jBulkEmailSeder"),Updatable(false), QuickSearch]


        public Int32? BulkEmailSenderId
        {
            get => fields.BulkEmailSenderId[this];
            set => fields.BulkEmailSenderId[this] = value;
        }

       

        [DisplayName("To Email"), Size(255), NotNull,NameProperty]
        public String ToEmail
        {
            get => fields.ToEmail[this];
            set => fields.ToEmail[this] = value;
        }
        [DisplayName("CC"), Size(255) ]
        public String CC
        {
            get => fields.CC[this];
            set => fields.CC[this] = value;
        }
        [DisplayName("Subject"), Size(255), NotNull]
        public String Subject
        {
            get => fields.Subject[this];
            set => fields.Subject[this] = value;
        }
        [DisplayName("Recipient Name"), Size(255), NotNull]
        public String RecipientName
        {
            get => fields.RecipientName[this];
            set => fields.RecipientName[this] = value;
        }
        [DisplayName("Company Name"), Size(255), NotNull]
        public String CompanyName
        {
            get => fields.CompanyName[this];
            set => fields.CompanyName[this] = value;
        }
        [DisplayName("Body"), NotNull]
        public String Body
        {
            get => fields.Body[this];
            set => fields.Body[this] = value;
        }

        [DisplayName("Attachment"), Size(1000)]
        public String Attachment
        {
            get => fields.Attachment[this];
            set => fields.Attachment[this] = value;
        }

        [DisplayName("Is Sent"), NotNull]
        public Boolean? IsSent
        {
            get => fields.IsSent[this];
            set => fields.IsSent[this] = value;
        }
        [DisplayName("Is Active"), NotNull]
        public Boolean? IsActive
        {
            get => fields.IsActive[this];
            set => fields.IsActive[this] = value;
        }
        [DisplayName("Sent On")]
        public DateTime? SentOn
        {
            get => fields.SentOn[this];
            set => fields.SentOn[this] = value;
        }
        [DisplayName("Scheduled Date")]
        public DateTime? ScheduledDate
        {
            get => fields.ScheduledDate[this];
            set => fields.ScheduledDate[this] = value;
        }
        
        [DisplayName("From Address")]
        public String FromAddress
        {
            get => fields.FromAddress[this];
            set => fields.FromAddress[this] = value;
        }
        [DisplayName("Placeholder")]
        public String Placeholder
        {
            get => fields.Placeholder[this];
            set => fields.Placeholder[this] = value;
        }
        [DisplayName("Placeholder1")]
        public String Placeholder1
        {
            get => fields.Placeholder1[this];
            set => fields.Placeholder1[this] = value;
        }
        [DisplayName("Retry Count")]
        public Int32? RetryCount
        {
            get => fields.RetryCount[this];
            set => fields.RetryCount[this] = value;
        }
     

        [DisplayName("Tenant"), ForeignKey("Tenant", "TenantId"), LeftJoin("jTenant")]
    
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

        public EmailNotificationRow()
            : base()
        {
        }

        public EmailNotificationRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : LoggingRowFields
        {
            public Int32Field Id;
            
            public StringField ToEmail;
            public StringField CC;
            public StringField RecipientName;
            public StringField CompanyName;
            public StringField FromAddress;
            public StringField Subject;
            public StringField Body;
            public StringField Attachment;
            public BooleanField IsSent;
            public BooleanField IsActive;

            public DateTimeField SentOn;
            public StringField Placeholder;
            public StringField Placeholder1;

            public Int32Field RetryCount;
           
            public Int32Field BulkEmailSenderId;

             public DateTimeField ScheduledDate;
            public Int32Field TenantId;
            public StringField TenantName;
            //public Int32Field InsertUserId;
           
        }


    }
}
