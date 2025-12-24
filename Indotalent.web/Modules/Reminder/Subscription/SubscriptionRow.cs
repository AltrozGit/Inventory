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
    [ConnectionKey("Default"), Module("Reminder"), TableName("[dbo].[Subscription]")]
    [DisplayName("Subscription"), InstanceName("Subscription")]
    [ReadPermission("Reminder:Subscription")]
    [ModifyPermission("Reminder:Subscription")]
    [LookupScript]
    [NavigationPermission("ReminderNavigation:Subscription")]

    public sealed class SubscriptionRow : LoggingRow<SubscriptionRow.RowFields>, IIdRow,INameRow
    {
        [DisplayName("Id"), Identity, IdProperty]
        public Int32? Id
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
        }

        [DisplayName("Plan"), NotNull, ForeignKey("[dbo].[PlanSetting]", "Id"), LeftJoin("jPlanSetting")]
        public Int32? PlanId
        {
            get => fields.PlanId[this];
            set => fields.PlanId[this] = value;
        }
        [DisplayName("Plan Name"), Expression("jPlanSetting.[PlanName]"), Size(200), NotNull, QuickSearch,NameProperty]
        public String PlanName
        {
            get => fields.PlanName[this];
            set => fields.PlanName[this] = value;
        }
       
        [DisplayName("Apllication Tenant Id"),NotNull]
        public Int32? ApplicationTenantId
        {
            get { return Fields.ApplicationTenantId[this]; }
            set { Fields.ApplicationTenantId[this] = value; }
        }

        //[DisplayName("Tenant"), ForeignKey("Tenant", "TenantId"), LeftJoin("jTenant")]
        // public Int32? TenantId
        //{
        //    get { return Fields.TenantId[this]; }
        //    set { Fields.TenantId[this] = value; }
        //}

        //[DisplayName("Tenant"), Expression("jTenant.TenantName")]
        //public String TenantName
        //{
        //    get { return Fields.TenantName[this]; }
        //    set { Fields.TenantName[this] = value; }
        //}

     


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

        [DisplayName("Customer Name"), PrimaryKey, NotNull, ForeignKey("[dbo].[Customer]", "Id"), LeftJoin("jCustomer"), TextualField("CustomerName")]
       
        public Int32? CustomerId
        {
            get => fields.CustomerId[this];
            set => fields.CustomerId[this] = value;
        }
        [DisplayName("Customer Name"), Size(200), Expression("jCustomer.[Name]")]
        public String CustomerName
        {
            get => fields.CustomerName[this];
            set => fields.CustomerName[this] = value;
        }

        [DisplayName("Product"), Size(200), NotNull]
        public String ProductName
        {
            get => fields.ProductName[this];
            set => fields.ProductName[this] = value;
        }
        public SubscriptionRow()
            : base()
        {
        }

        public SubscriptionRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : LoggingRowFields
        {
            public Int32Field Id;
            public Int32Field PlanId;
            public Int32Field CustomerId;

           // public Int32Field TenantId;
            public DateTimeField StartDate;
            public DateTimeField EndDate;
            public BooleanField IsActive;
            public BooleanField IsArchive;
            public DateTimeField ActiveEndDate;
            public Int32Field TotalUnits;
            public Int32Field CurrentBalanceUnits;

            public StringField CustomerName;

            public StringField PlanName;
            public StringField ProductName;

            public Int32Field ApplicationTenantId;



        }
    }
}
