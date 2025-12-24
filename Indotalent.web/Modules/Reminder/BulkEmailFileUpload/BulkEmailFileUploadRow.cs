using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;
using System.IO;
using static MVC.Views.Reminder;

using Serenity.Extensions.Entities;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;

namespace Indotalent.Reminder
{
    [ConnectionKey("Default"), Module("Reminder"), TableName("[dbo].[BulkEmailSender]")]
    [DisplayName("Email Broadcast"), InstanceName("Email Broadcast")]
    [ReadPermission("Reminder:BulkEmailFileUpload")]
    [ModifyPermission("Reminder:BulkEmailFileUpload")]
    [LookupScript(LookupType = typeof(MultiTenantRowLookupScript<>))]

    public sealed class BulkEmailFileUploadRow : LoggingRow<BulkEmailFileUploadRow.RowFields>, IIdRow, INameRow,IMultiTenantRow
    {
      

        [DisplayName("Id"), Identity, IdProperty]
        public Int32? Id
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
        }

        [DisplayName("File Name"), Size(255), NotNull, QuickSearch]
       
       
        public String Title
        {
            get => fields.Title[this];
            set => fields.Title[this] = value;
        }

        [DisplayName("File Name"), NotMapped]
        public String FileTitle
        {
            get { return Title; } // Duplicate the value of Title
        }
       
        [DisplayName("Upload Email File"), FileUploadEditor(FilenameFormat = "Emails/Inventory/BulkEmails/EmailFile/{4}_{0}",
                  DisplayFileName = true
                 ), NotNull]
      
        public String FilePath
        {
            get => fields.FilePath[this];
            set => fields.FilePath[this] = value;
        }


        [DisplayName("Description"), Size(1000)]
        public String Description
        {
            get => fields.Description[this];
            set => fields.Description[this] = value;
        }
        [DisplayName("Is Active"), NotNull, DefaultValue(true)]
        public Boolean? IsActive
        {
            get => fields.IsActive[this];
            set => fields.IsActive[this] = value;
        }
        [DisplayName("Action"), NotNull, DefaultValue(false)]
        public Boolean? IsStopped
        {
            get => fields.IsStopped[this];
            set => fields.IsStopped[this] = value;
        }
        //[DisplayName("Date")]
        //public DateTime? InsertDate
        //{
        //    get => fields.InsertDate[this];
        //    set => fields.InsertDate[this] = value;
        //}

        [DisplayName("Upload Attachments"), MultipleFileUploadEditor(FilenameFormat = "Emails/Inventory/BulkEmails/Attachments/{4}_{0}")]
        public String UploadAttachments
        {
            get => fields.UploadAttachments[this];
            set => fields.UploadAttachments[this] = value;
        }
        [DisplayName("Schedule On"), NotNull, DateTimeFormatter(DisplayFormat = "MM/dd/yyyy hh:mm tt")]
        public DateTime? ScheduledDate
        {
            get => fields.ScheduledDate[this];
            set => fields.ScheduledDate[this] = value;
        }
        
        [DisplayName("From Address"), LookupEditor("Reminder.SmtpConfigurationLookup"),NotNull,NameProperty]
        public String FromAddress
        {
            get => fields.FromAddress[this];
            set => fields.FromAddress[this] = value;
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



        public string ToEmail { get; internal set; }
        public string Subject { get; internal set; }
        public string Body { get; internal set; }
       public string Attachment { get; set; }
       public Date SentOn { get; set;   }
        public bool?  IsSent { get; set; }
    

        //public int InsertUserId { get;  set; }
        public string CC { get; internal set; }
      //  public string Attachment { get; internal set; }
        public string RecipientName { get;  set; }
        public string CompanyName { get;  set; }
        public string Placeholder { get;  set; }
        public string Placeholder1 { get;  set; }

        public BulkEmailFileUploadRow()
            : base()
        {
        }

        public BulkEmailFileUploadRow(RowFields fields)
            : base(fields)
        {
        }
        

        public class RowFields : LoggingRowFields
        {
            public Int32Field Id;
           

            public StringField Title;
           
            public StringField FilePath;
            public StringField Description;

            public Int32Field TenantId;
            public StringField TenantName;
            public DateTimeField ScheduledDate;
            public StringField UploadAttachments;
            public BooleanField IsActive;
            public BooleanField IsStopped;

            public StringField FromAddress;
        
        }
    }
}
