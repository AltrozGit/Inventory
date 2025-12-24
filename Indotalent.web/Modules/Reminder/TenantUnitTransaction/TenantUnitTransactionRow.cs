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
    [ConnectionKey("Default"), Module("Reminder"), TableName("[dbo].[TenantUnitTransaction]")]
    [DisplayName("Tenant Unit Transaction"), InstanceName("Tenant Unit Transaction")]
    [ReadPermission("Reminder:TenantUnitTransaction")]
    [ModifyPermission("Reminder:TenantUnitTransaction")]
    [LookupScript]
    [NavigationPermission("ReminderNavigation:TenantUnitTransaction")]

    public sealed class TenantUnitTransactionRow : LoggingRow<TenantUnitTransactionRow.RowFields>, IIdRow, INameRow
    {
        [DisplayName("Id"), Identity, IdProperty]
        public Int32? Id
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
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

    

        [DisplayName("Subscription"), NotNull, ForeignKey("[dbo].[Subscription]", "Id"), LeftJoin("jSubscription")]
        public Int32? SubscriptionId
        {
            get => fields.SubscriptionId[this];
            set => fields.SubscriptionId[this] = value;
        }
     
        [DisplayName("Units"), NotNull]
        public Int32? Units
        {
            get => fields.Units[this];
            set => fields.Units[this] = value;
        }

        [DisplayName("Reference Id")]
        public Int32? ReferenceId
        {
            get => fields.ReferenceId[this];
            set => fields.ReferenceId[this] = value;
        }

        [DisplayName("Remark"), Size(500), QuickSearch, NameProperty]
        public String Remark
        {
            get => fields.Remark[this];
            set => fields.Remark[this] = value;
        }

       

       

       

      
        public TenantUnitTransactionRow()
            : base()
        {
        }

        public TenantUnitTransactionRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : LoggingRowFields
        {
            public Int32Field Id;
            public Int32Field TenantId;
            public Int32Field SubscriptionId;
            public Int32Field Units;
            public Int32Field ReferenceId;
            public StringField Remark;
           
            public StringField TenantName;

         
           
           
          
         
          
        

           
           
        }
    }
}
