using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;
using System.IO;

namespace Indotalent.Settings
{
    [ConnectionKey("Default"), Module("Settings"), TableName("[dbo].[Country]")]
    [DisplayName("Country"), InstanceName("Country")]
    [ReadPermission("Settings:Country")]
    [ModifyPermission("Settings:Country")]
    [LookupScript("Settings.Country")]
    public sealed class CountryRow : Row<CountryRow.RowFields>, IIdRow, INameRow
    {
        [DisplayName("Country Id"), Identity, IdProperty]
        public Int32? Id
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
        }

        [DisplayName("Country Name"), Column("Name"), Size(255), QuickSearch, NameProperty]
        public String Name
        {
            get => fields.Name[this];
            set => fields.Name[this] = value;
        }
        [DisplayName("Country Code"),  QuickSearch]
        public String CountryCode
        {
            get => fields.CountryCode[this];
            set => fields.CountryCode[this] = value;
        }
        public CountryRow()
            : base()
        {
        }

        public CountryRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field Id;
            public StringField Name;
            public StringField CountryCode;
        }
    }
}
