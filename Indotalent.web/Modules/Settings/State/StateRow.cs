using Indotalent.Material;
using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;
using System.IO;
using static MVC.Views.Settings;

namespace Indotalent.Settings
{
    [ConnectionKey("Default"), Module("Settings"), TableName("[dbo].[State]")]
    [DisplayName("State"), InstanceName("State")]
    [ReadPermission("Settings:State")]
    [ModifyPermission("Settings:State")]
    [LookupScript("Settings.State")]
    public sealed class StateRow : Row<StateRow.RowFields>, IIdRow, INameRow
    {
        [DisplayName("State Id"), Identity, IdProperty]
        public Int32? Id
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
        }
        [DisplayName("State Code"), QuickSearch]
        public String StateCode
        {
            get => fields.StateCode[this];
            set => fields.StateCode[this] = value;
        }

        [DisplayName("State Name"), Size(255), QuickSearch, NameProperty]
        public String Name
        {
            get => fields.Name[this];
            set => fields.Name[this] = value;
        }

        [DisplayName("Country"), ForeignKey("Country", "Id"),  LookupInclude, LeftJoin("jCountry"), TextualField("CountryName"), QuickSearch]
        public Int32? CountryId
        {
            get { return Fields.CountryId[this]; }
            set { Fields.CountryId[this] = value; }
        }

        [DisplayName("Country Name"), Expression("jCountry.[Name]"), MinSelectLevel(SelectLevel.List), QuickSearch]
        public String CountryName
        {
            get => fields.CountryName[this];
            set => fields.CountryName[this] = value;
        }

        public StateRow()
            : base()
        {
        }

        public StateRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field Id;
            public StringField Name;
            public StringField StateCode;
            public Int32Field CountryId;
            public StringField CountryName;
        }
    }
}
