using Indotalent.Merchandise;
using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;
using System.IO;

namespace Indotalent.Reminder
{
    [ConnectionKey("Default"), Module("Reminder"), TableName("[dbo].[PlanSetting]")]
    [DisplayName("Plans"), InstanceName("Plans")]
    [ReadPermission("*")]
    [InsertPermission(Administration.PermissionKeys.PlanSetting)]
    [UpdatePermission(Administration.PermissionKeys.PlanSetting)]
    [DeletePermission(Administration.PermissionKeys.PlanSetting)]
    [NavigationPermission("ReminderNavigation:PlanSetting")]
    [LookupScript]
    public sealed class PlanSettingRow : Row<PlanSettingRow.RowFields>, IIdRow, INameRow
    {
        [DisplayName("Id"), Identity, IdProperty]
        public Int32? Id
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
        }
        
        [DisplayName("Plan Name"), Size(200), NotNull, QuickSearch, NameProperty]
        public String PlanName
        {
            get => fields.PlanName[this];
            set => fields.PlanName[this] = value;
        }

        [DisplayName("Product"),ForeignKey("[dbo].[Product]", "Id"), LeftJoin("jProduct"),NotNull]
        [LookupEditor(typeof(ProductRow))]

        public Int32? ProductId
        {
            get => fields.ProductId[this];
            set => fields.ProductId[this] = value;
        }

        [DisplayName("Product Name"), Expression("jProduct.[Name]"),NotNull]
        [Updatable(false), Insertable(false)]
        public String ProductName
        {
            get => fields.ProductName[this];
            set => fields.ProductName[this] = value;
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

        [DisplayName("Is Active"), NotNull]
        public Boolean? IsActive
        {
            get => fields.IsActive[this];
            set => fields.IsActive[this] = value;
        }

        [DisplayName("Type"), Size(50), NotNull]
        public String Type
        {
            get => fields.Type[this];
            set => fields.Type[this] = value;
        }



        public PlanSettingRow()
            : base()
        {
        }

        public PlanSettingRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field Id;
            public StringField PlanName;
            public Int32Field ProductId;

            public StringField ProductName;
            public DecimalField Cost;
            public Int32Field Units;
            public StringField Frequency;
            public BooleanField IsActive;
            public StringField Type;
        }
    }

}