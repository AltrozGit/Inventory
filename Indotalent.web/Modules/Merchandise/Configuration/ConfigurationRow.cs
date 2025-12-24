using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;
using System.IO;

namespace Indotalent.Merchandise
{
    [ConnectionKey("Default"), Module("Merchandise"), TableName("[dbo].[Configuration]")]
    [DisplayName("Configuration"), InstanceName("Configuration")]
    [ReadPermission("Merchandise:Configuration")]
    [ModifyPermission("Merchandise:Configuration")]
    public sealed class ConfigurationRow : Row<ConfigurationRow.RowFields>, IIdRow, INameRow
    {
        [DisplayName("Id"), Identity, IdProperty]
        public Int32? Id
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
        }

        [DisplayName("Description"), Size(1000), QuickSearch, NameProperty]
        public String Description
        {
            get => fields.Description[this];
            set => fields.Description[this] = value;
        }

        [DisplayName("Key"), Size(200), NotNull]
        public String Key
        {
            get => fields.Key[this];
            set => fields.Key[this] = value;
        }

        [DisplayName("Value"), Size(200), NotNull]
        public String Value
        {
            get => fields.Value[this];
            set => fields.Value[this] = value;
        }

        [DisplayName("Insert Date")]
        public DateTime? InsertDate
        {
            get => fields.InsertDate[this];
            set => fields.InsertDate[this] = value;
        }

        [DisplayName("Insert User Id")]
        public Int32? InsertUserId
        {
            get => fields.InsertUserId[this];
            set => fields.InsertUserId[this] = value;
        }

        [DisplayName("Update Date")]
        public DateTime? UpdateDate
        {
            get => fields.UpdateDate[this];
            set => fields.UpdateDate[this] = value;
        }

        [DisplayName("Update User Id")]
        public Int32? UpdateUserId
        {
            get => fields.UpdateUserId[this];
            set => fields.UpdateUserId[this] = value;
        }

        [DisplayName("Tenant Id"), NotNull]
        public Int32? TenantId
        {
            get => fields.TenantId[this];
            set => fields.TenantId[this] = value;
        }

        public ConfigurationRow()
            : base()
        {
        }

        public ConfigurationRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field Id;
            public StringField Description;
            public StringField Key;
            public StringField Value;
            public DateTimeField InsertDate;
            public Int32Field InsertUserId;
            public DateTimeField UpdateDate;
            public Int32Field UpdateUserId;
            public Int32Field TenantId;
        }
    }
}
