using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;
using System.IO;

namespace Indotalent.Web.Modules.Merchandise.HSN
{
    [ConnectionKey("Default"), Module("InternalCode"), TableName("[dbo].[HSN]")]
    [DisplayName("Hsn"), InstanceName("Hsn")]
    [ReadPermission("InternalCode:HSN")]
    [ModifyPermission("InternalCode:HSN")]
    public sealed class HSNRow : Row<HSNRow.RowFields>, IIdRow, INameRow
    {
        [DisplayName("Id"), IdProperty]
        public Int32? Id
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
        }

        [DisplayName("Hsn Code"), Column("HSN Code"), Size(255), QuickSearch, NameProperty]
        public String HsnCode
        {
            get => fields.HsnCode[this];
            set => fields.HsnCode[this] = value;
        }

        [DisplayName("Hsn Description"), Column("HSN Description"), Size(255)]
        public String HsnDescription
        {
            get => fields.HsnDescription[this];
            set => fields.HsnDescription[this] = value;
        }

        public HSNRow()
            : base()
        {
        }

        public HSNRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field Id;
            public StringField HsnCode;
            public StringField HsnDescription;

        }
    }
}
