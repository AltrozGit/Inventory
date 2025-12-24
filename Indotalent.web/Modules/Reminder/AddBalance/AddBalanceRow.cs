using Indotalent.Administration;
using Indotalent.Material;
using Indotalent.Merchandise;
using Indotalent.Web.Modules.Reminder.AddBalance;
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
    [ConnectionKey("Default"), Module("Reminder"), TableName("[dbo].[AddBalance]")]
    [DisplayName("Plan Purchase"), InstanceName("Plan Purchase")]
    [ReadPermission("Reminder:AddBalance")]
    [ModifyPermission("Reminder:AddBalance")]
    [LookupScript]
    [NavigationPermission("ReminderNavigation:AddBalance")]
    public sealed class AddBalanceRow : LoggingRow<AddBalanceRow.RowFields>, IIdRow,INameRow
    {
        [DisplayName("Id"), Identity, IdProperty]
        public Int32? Id
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
        }
        [DisplayName("Tenant"), ForeignKey("Tenant", "TenantId"), LeftJoin("jTenant")]
        [Updatable(false),Insertable(true)]
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
    
        [DisplayName("Application Tenant ID"),NotNull]
       
        public Int32? ApplicationTenantId
        {
            get { return Fields.ApplicationTenantId[this]; }
            set { Fields.ApplicationTenantId[this] = value; }
        }
        [DisplayName("Customer Name"), PrimaryKey, NotNull, ForeignKey("[dbo].[Customer]", "Id"), LeftJoin("jCustomer"), TextualField("CustomerName")]
        [LookupEditor(typeof(Sales.CustomerRow))]
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

       


        [DisplayName("Recharge Date"), NotNull]
        public DateTime? RechargeDate
        {
            get => fields.RechargeDate[this];
            set => fields.RechargeDate[this] = value;
        }

        [DisplayName("Plan"), NotNull, ForeignKey("[dbo].[PlanSetting]", "Id"), LeftJoin("jPlanSetting"), LookupInclude]
      //  [LookupEditor(typeof(PlanSettingLookup), InplaceAdd = true)]
        public Int32? PlanId
        {
            get => fields.PlanId[this];
            set => fields.PlanId[this] = value;
        }
        [DisplayName("Plan Name"), Expression("jPlanSetting.[PlanName]"), Size(200), NotNull, QuickSearch, NameProperty, MinSelectLevel(SelectLevel.List)]
      [Updatable(false), Insertable(false)]
        public String PlanName
        {
            get => fields.PlanName[this];
            set => fields.PlanName[this] = value;
        }
       
       

        [DisplayName("Cost"), Size(19), Expression("jPlanSetting.[Cost]"), Scale(2), NotNull]
        public Decimal? Cost
        {
            get => fields.Cost[this];
            set => fields.Cost[this] = value;
        }

        [DisplayName("Units"), Expression("jPlanSetting.[Units]"), NotNull]
        public Int32? Units
        {
            get => fields.Units[this];
            set => fields.Units[this] = value;
        }

        [DisplayName("Frequency"), Size(50), Expression("jPlanSetting.[Frequency]"), NotNull]
        public String Frequency
        {
            get => fields.Frequency[this];
            set => fields.Frequency[this] = value;
        }
        [DisplayName("Type"), Size(50), Expression("jPlanSetting.[Type]"), NotNull]
        public String Type
        {
            get => fields.Type[this];
            set => fields.Type[this] = value;
        }
        [DisplayName("Valid Through"),NotNull]
        public DateTime? ValidThrough
        {
            get => fields.ValidThrough[this];
            set => fields.ValidThrough[this] = value;
        }

        [DisplayName("Product"),NotNull, ForeignKey("[dbo].[Product]", "Id"), LeftJoin("jProduct")]
        [LookupEditor(typeof(ProductRow))]
        public Int32? ProductId
        {
            get => fields.ProductId[this];
            set => fields.ProductId[this] = value;
        }

        [DisplayName("Product Name"), Expression("jProduct.[Name]")]
      
        public String ProductName
        {
            get => fields.ProductName[this];
            set => fields.ProductName[this] = value;
        }


        public AddBalanceRow()
            : base()
        {
        }

        public AddBalanceRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : LoggingRowFields
        {
            public Int32Field Id;
            public Int32Field TenantId;
            public DateTimeField RechargeDate;
            public Int32Field PlanId;
            public StringField PlanName;
          
            public DateTimeField ValidThrough;
            public Int32Field ApplicationTenantId;

         
            public DecimalField Cost;
            public Int32Field Units;
            public StringField Frequency;
            public Int32Field ProductId;

            public StringField ProductName;
            public StringField Type;
            public StringField TenantName;

            public Int32Field CustomerId;
            public StringField CustomerName;
        }
    }
}
