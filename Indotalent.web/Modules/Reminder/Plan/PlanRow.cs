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
    [ConnectionKey("Default"), Module("Reminder"), TableName("[dbo].[Plan]")]
    [DisplayName("Plan"), InstanceName("Plan")]
    [ReadPermission("Reminder:Plan")]
    [ModifyPermission("Reminder:Plan")]
    [LookupScript(LookupType = typeof(MultiTenantRowLookupScript<>))]

    public sealed class PlanRow : LoggingRow<PlanRow.RowFields>, IIdRow, INameRow, IMultiTenantRow
    {
        [DisplayName("Id"), Identity, IdProperty]
        public Int32? Id
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
        }

       

        [DisplayName("Plan Name"), Size(200), NotNull, QuickSearch]
        public String PlanName
        {
            get => fields.PlanName[this];
            set => fields.PlanName[this] = value;
        }

        [DisplayName("Product"), Size(100), NotNull, LookupEditor("Product.SAASProductLookup"),NameProperty]
        public String Product
        {
            get => fields.Product[this];
            set => fields.Product[this] = value;
        }

        [DisplayName("Cost"), Size(19), Scale(2), NotNull]
        public Decimal? Cost
        {
            get => fields.Cost[this];
            set => fields.Cost[this] = value;
        }

        [DisplayName("Units"), NotNull]
        public Int32? Units
        {
            get => fields.Units[this];
            set => fields.Units[this] = value;
        }

        [DisplayName("Frequency"), Size(50), NotNull]
        public String Frequency
        {
            get => fields.Frequency[this];
            set => fields.Frequency[this] = value;
        }
        [DisplayName("Type"), Size(50), NotNull]
        public String Type
        {
            get => fields.Type[this];
            set => fields.Type[this] = value;
        }
        [DisplayName("Is Active"), NotNull]
        public Boolean? IsActive
        {
            get => fields.IsActive[this];
            set => fields.IsActive[this] = value;
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


        public PlanRow()
            : base()
        {
        }

        public PlanRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : LoggingRowFields
        {
            public Int32Field Id;
            public StringField PlanName;

            public StringField Product;
            public DecimalField Cost;
            public Int32Field Units;
            public StringField Frequency;
            public BooleanField IsActive;
            public StringField Type;
            public Int32Field TenantId;
            public StringField TenantName;
        }
    }
}
