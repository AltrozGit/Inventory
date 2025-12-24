using Indotalent.Web.Common;
using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;
using System.IO;

namespace Indotalent.Reminder
{
    [ConnectionKey("Default"), Module("Reminder"), TableName("[dbo].[EmailNotification]")]
    [DisplayName("Bulk Email Sender Status"), InstanceName("Bulk Email Sender Status")]
    [ReadPermission("Reminder:BulkEmailSenderStatus")]
    [ModifyPermission("Reminder:BulkEmailSenderStatus")]
    [LookupScript(LookupType = typeof(MultiTenantRowLookupScript<>))]

    public sealed class BulkEmailSenderStatusRow : Row<BulkEmailSenderStatusRow.RowFields>, IIdRow, INameRow,IMultiTenantRow
    {
        [DisplayName("Id"), Identity, IdProperty]
        public Int32? Id
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
        }

        [DisplayName("To Email"), Size(255), NotNull, NameProperty]
        public String ToEmail
        {
            get => fields.ToEmail[this];
            set => fields.ToEmail[this] = value;
        }
        [DisplayName("CC"), Size(255), NotNull]
        public String CC
        {
            get => fields.CC[this];
            set => fields.CC[this] = value;
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

    [DisplayName("Subject"), Size(255), NotNull]
        public String Subject
        {
            get => fields.Subject[this];
            set => fields.Subject[this] = value;
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

        [DisplayName("Sent Status"), NotNull, QuickSearch]
        public Enums.EmailSentStatus? IsSent
        {
            get => fields.IsSent[this];
            set => fields.IsSent[this] = value;
        }
        [DisplayName("Sent Status"), Expression("(CASE WHEN IsSent = 0 THEN 'Pending' WHEN IsSent = 1 THEN 'Successful' WHEN IsSent = 2 THEN 'Cancelled' ELSE 'Unknown' END)"), QuickSearch]
        public String IsSentDisplay
        {
            get => fields.IsSentDisplay[this];
            set => fields.IsSentDisplay[this] = value;
        }
        [DisplayName("Sent On")]
        public DateTime? SentOn
        {
            get => fields.SentOn[this];
            set => fields.SentOn[this] = value;
        }

        [DisplayName("Retry Count")]
        public Int32? RetryCount
        {
            get => fields.RetryCount[this];
            set => fields.RetryCount[this] = value;
        }


     

        [DisplayName("Bulk Email Sender"), ForeignKey("[dbo].[BulkEmailSender]", "Id"), LeftJoin("jBulkEmailSender"), TextualField("BulkEmailSenderTitle")]
        public Int32? BulkEmailSenderId
        {
            get => fields.BulkEmailSenderId[this];
            set => fields.BulkEmailSenderId[this] = value;
        }

        [DisplayName("File Title"), Expression("jBulkEmailSender.[Title]"), QuickSearch]
        public String BulkEmailSenderTitle
        {
            get => fields.BulkEmailSenderTitle[this];
            set => fields.BulkEmailSenderTitle[this] = value;
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


        public BulkEmailSenderStatusRow()
            : base()
        {
        }

        public BulkEmailSenderStatusRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field Id;
            public StringField ToEmail;
            public StringField Subject;
            public StringField Body;
            public StringField Attachment;
            public EnumField<Enums.EmailSentStatus> IsSent;
            public DateTimeField SentOn;
            public Int32Field RetryCount;
         
            public Int32Field TenantId;
            public Int32Field BulkEmailSenderId;
            public StringField CC;
            public StringField RecipientName;
            public StringField CompanyName;
            public StringField BulkEmailSenderTitle;
            public StringField TenantName;
            public StringField IsSentDisplay;

        }
    }
}
