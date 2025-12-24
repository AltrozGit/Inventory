using Indotalent.Web.Modules.Reminder.AddBalance;
using Indotalent.WhatsApp;
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
    [ConnectionKey("Default"), Module("Reminder"), TableName("[dbo].[DueDateReminder]")]
    [DisplayName("Due Date Notifications"), InstanceName("Due Date Notifications")]
    [ReadPermission("Reminder:DueDateReminder")]
    [ModifyPermission("Reminder:DueDateReminder")]
    [LookupScript(LookupType = typeof(MultiTenantRowLookupScript<>))]

    public sealed class DueDateReminderRow : LoggingRow<DueDateReminderRow.RowFields>, IIdRow, INameRow,IMultiTenantRow
    {
        [DisplayName("Id"), Identity, IdProperty]
        public Int32? Id
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
        }
        [DisplayName("Customer Name"), PrimaryKey, NotNull, ForeignKey("[dbo].[Customer]", "Id"), LeftJoin("jCustomer"), TextualField("CustomerName")]
        [LookupEditor(typeof(Sales.CustomerRow))]
        public Int32? CustomerId
        {
            get => fields.CustomerId[this];
            set => fields.CustomerId[this] = value;
        }
        [DisplayName("Customer Name"), Size(200), NameProperty]
        public String CustomerName
        {
            get => fields.CustomerName[this];
            set => fields.CustomerName[this] = value;
        }

        [DisplayName("Customer Name"), Expression("jCustomer.[Name]")]
        public String RelatedCustomerName
        {
            get => fields.RelatedCustomerName[this];
            set => fields.RelatedCustomerName[this] = value;
        }

        [DisplayName("Customer Phone")]
        public String CustomerPhone
        {
            get => fields.CustomerPhone[this];
            set => fields.CustomerPhone[this] = value;
        }
        [DisplayName("Template Name "), NotNull, ForeignKey("[dbo].[WhatsAppTemplate]", "Id"), LeftJoin("jWhatsApp"), TextualField("TemplateName"), QuickSearch]
        [LookupEditor(typeof(WhatsAppRow), InplaceAdd = false)]
        public Int32? WhatsAppId
        {
            get => fields.WhatsAppId[this];
            set => fields.WhatsAppId[this] = value;
        }
        [DisplayName("Template Name"), Expression("jWhatsApp.[TemplateName]"), QuickSearch]

        public String TemplateName
        {
            get => fields.TemplateName[this];
            set => fields.TemplateName[this] = value;
        }
        public Int32Field TenantIdField
        {
            get { return Fields.TenantId; }
        }
        [DisplayName("Broadcast Name"), Expression("jWhatsApp.[BroadcastName]"), Size(100), QuickSearch]
        public String BroadcastName
        {
            get => fields.BroadcastName[this];
            set => fields.BroadcastName[this] = value;
        }

        [DisplayName("Url"), Size(100), Expression("jWhatsApp.[Url]"), QuickSearch]
        public String Url
        {
            get => fields.Url[this];
            set => fields.Url[this] = value;
        }
        [DisplayName("ToEmail"), Size(255)]
        public String ToEmail
        {
            get => fields.ToEmail[this];
            set => fields.ToEmail[this] = value;
        }
        [DisplayName("Tenant Email")]
        public String TenantEmail
        {
            get => fields.TenantEmail[this];
            set => fields.TenantEmail[this] = value;
        }
        [DisplayName("Tenant Phone")]
        public String TenantPhone
        {
            get => fields.TenantPhone[this];
            set => fields.TenantPhone[this] = value;
        }
        [DisplayName("CC"), Size(255)]
        public String ReminderInCC
        {
            get => fields.ReminderInCC[this];
            set => fields.ReminderInCC[this] = value;
        }
        [DisplayName("Message Body"), Size(1000)]
        public String MessageBody
        {
            get => fields.MessageBody[this];
            set => fields.MessageBody[this] = value;
        }
        [DisplayName("Subject"), Size(1000)]
        public String Subject
        {
            get => fields.Subject[this];
            set => fields.Subject[this] = value;
        }
        [DisplayName("Reminder 1"), QuickSearch]
        public DateTime? Remainder1
        {
            get => fields.Remainder1[this];
            set => fields.Remainder1[this] = value;
        }
        [DisplayName("Reminder 2"), QuickSearch]
        public DateTime? Remainder2
        {
            get => fields.Remainder2[this];
            set => fields.Remainder2[this] = value;
        }
        [DisplayName("Attachment"), FileUploadEditor(FilenameFormat = "Emails/Inventory/DueDateReminder/Attachments/{4}_{0}")]
        public String Attachment
        {
            get => fields.Attachment[this];
            set => fields.Attachment[this] = value;
        }
       

        [DisplayName("Due Date"), QuickSearch]
        public DateTime? ConsentDueDate
        {
            get => fields.ConsentDueDate[this];
            set => fields.ConsentDueDate[this] = value;
        }
        [DisplayName("Send Reminder On Email"), Size(1000)]
        [BooleanEditor, DefaultValue(false)]
        public Boolean? SendRemainderOnEmail
        {
            get => fields.SendRemainderOnEmail[this];
            set => fields.SendRemainderOnEmail[this] = value;
        }
        [DisplayName("Send Reminder On Whatsapp"), Size(1000)]
        [BooleanEditor, DefaultValue(false)]
        public Boolean? SendRemainderOnWhatsapp
        {
            get => fields.SendRemainderOnWhatsapp[this];
            set => fields.SendRemainderOnWhatsapp[this] = value;
        }
        [DisplayName("IsActionComplete"), Size(1000)]
        [BooleanEditor,DefaultValue(false)]
        public Boolean? IsActionComplete
        {
            get => fields.IsActionComplete[this];
            set => fields.IsActionComplete[this] = value;
        }
        [DisplayName("IsEnable"), Size(1000)]
       
        [BooleanEditor,DefaultValue(true)]
        public Boolean? IsEnable
        {
            get => fields.IsEnable[this];
            set => fields.IsEnable[this] = value;
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
        [DisplayName("Plan"), NotNull, ForeignKey("[dbo].[PlanSetting]", "Id"), LeftJoin("jPlanSetting")]
  
        public Int32? PlanId
        {
            get => fields.PlanId[this];
            set => fields.PlanId[this] = value;
        }
        [DisplayName("Plan Name"), Expression("jPlanSetting.[PlanName]"), Size(200)]
        [Updatable(false), Insertable(false)]
        public String PlanName
        {
            get => fields.PlanName[this];
            set => fields.PlanName[this] = value;
        }
      


        public DueDateReminderRow()
            : base()
        {
        }

        public DueDateReminderRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : LoggingRowFields
        {
            public Int32Field Id;
            public Int32Field CustomerId;
            public StringField CustomerName;
            public StringField RelatedCustomerName;

            public StringField CustomerPhone;
            public StringField MessageBody;
            public StringField Subject;
            public Int32Field PlanId;
            public StringField PlanName;
            public BooleanField SendRemainderOnEmail;
            public BooleanField SendRemainderOnWhatsapp;
            public BooleanField IsActionComplete;
            public BooleanField IsEnable;
            public DateTimeField ConsentDueDate;
            public DateTimeField Remainder1;
            public DateTimeField Remainder2;
            public StringField ReminderInCC;
            public StringField ToEmail;
            public StringField TenantEmail;
            public StringField Attachment;

            public Int32Field TenantId;
            public StringField TenantName;
            public StringField TenantPhone;
            public Int32Field WhatsAppId;
            public StringField TemplateName;
            public StringField BroadcastName;
            public StringField Url;
        }
    }
}
