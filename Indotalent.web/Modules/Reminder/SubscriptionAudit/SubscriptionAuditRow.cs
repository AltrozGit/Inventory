using Indotalent.Web.Modules.Reminder.AddBalance;
using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;
using System.IO;

namespace Indotalent.Reminder
{
    [ConnectionKey("Default"), Module("Reminder"), TableName("[dbo].[SubscriptionAudit]")]
    [DisplayName("Subscription Audit"), InstanceName("Subscription Audit")]
    [ReadPermission("Reminder:SubscriptionAudit")]
    [ModifyPermission("Reminder:SubscriptionAudit")]
    [NavigationPermission("ReminderNavigation:SubscriptionAudit")]

    public sealed class SubscriptionAuditRow : Row<SubscriptionAuditRow.RowFields>, IIdRow, INameRow
    {
        [DisplayName("Audit Id"), Identity, IdProperty]
        public Int32? AuditId
        {
            get => fields.AuditId[this];
            set => fields.AuditId[this] = value;
        }

        [DisplayName("Subscription"), NotNull, ForeignKey("[dbo].[Subscription]", "Id"), LeftJoin("jSubscription")]
        public Int32? SubscriptionId
        {
            get => fields.SubscriptionId[this];
            set => fields.SubscriptionId[this] = value;
        }

        [DisplayName("Tenant Id"), NotNull]
        public Int32? TenantId
        {
            get => fields.TenantId[this];
            set => fields.TenantId[this] = value;
        }

        [DisplayName("Plan"), NotNull, ForeignKey("[dbo].[PlanSetting]", "Id"), LeftJoin("jPlanSetting"), TextualField("PlanName")]
       // [LookupEditor(typeof(PlanSettingLookup), InplaceAdd = true)]
        public Int32? PlanId
        {
            get => fields.PlanId[this];
            set => fields.PlanId[this] = value;
        }
        [DisplayName("Plan Name"), Expression("jPlanSetting.PlanName"), Size(200), NotNull, QuickSearch, NameProperty]
        [Updatable(false), Insertable(false)]
        public String PlanName
        {
            get => fields.PlanName[this];
            set => fields.PlanName[this] = value;
        }
        [DisplayName("Start Date"), NotNull]
        public DateTime? StartDate
        {
            get => fields.StartDate[this];
            set => fields.StartDate[this] = value;
        }

        [DisplayName("End Date"), NotNull]
        public DateTime? EndDate
        {
            get => fields.EndDate[this];
            set => fields.EndDate[this] = value;
        }

        [DisplayName("Active End Date")]
        public DateTime? ActiveEndDate
        {
            get => fields.ActiveEndDate[this];
            set => fields.ActiveEndDate[this] = value;
        }

        [DisplayName("Total Units"), NotNull]
        public Int32? TotalUnits
        {
            get => fields.TotalUnits[this];
            set => fields.TotalUnits[this] = value;
        }

        [DisplayName("Current Balance Units"), NotNull]
        public Int32? CurrentBalanceUnits
        {
            get => fields.CurrentBalanceUnits[this];
            set => fields.CurrentBalanceUnits[this] = value;
        }

        [DisplayName("Is Active"), NotNull]
        public Boolean? IsActive
        {
            get => fields.IsActive[this];
            set => fields.IsActive[this] = value;
        }

        [DisplayName("Is Archive"), NotNull]
        public Boolean? IsArchive
        {
            get => fields.IsArchive[this];
            set => fields.IsArchive[this] = value;
        }

        [DisplayName("Operation Type"), Size(50), NotNull, QuickSearch]
        public String OperationType
        {
            get => fields.OperationType[this];
            set => fields.OperationType[this] = value;
        }

        [DisplayName("Audit Timestamp"), NotNull]
        public DateTime? AuditTimestamp
        {
            get => fields.AuditTimestamp[this];
            set => fields.AuditTimestamp[this] = value;
        }

     

        public SubscriptionAuditRow()
            : base()
        {
        }

        public SubscriptionAuditRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field AuditId;
            public Int32Field SubscriptionId;
            public Int32Field TenantId;
            public Int32Field PlanId;
            public StringField PlanName;

            public DateTimeField StartDate;
            public DateTimeField EndDate;
            public DateTimeField ActiveEndDate;
            public Int32Field TotalUnits;
            public Int32Field CurrentBalanceUnits;
            public BooleanField IsActive;
            public BooleanField IsArchive;
            public StringField OperationType;
            public DateTimeField AuditTimestamp;
         
        }
    }
}
