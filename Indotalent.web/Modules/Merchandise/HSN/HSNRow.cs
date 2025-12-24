using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;
using System.IO;

namespace Indotalent.Merchandise
{
    [ConnectionKey("Default"), Module("Merchandise"), TableName("[dbo].[HSN]")]
    [DisplayName("Hsn"), InstanceName("Hsn")]
    [ReadPermission("Merchandise:HSN")]
    [ModifyPermission("Merchandise:Product")]
    [LookupScript]

    public sealed class HSNRow : Row<HSNRow.RowFields>, IIdRow, INameRow
    {
        [DisplayName("Id"), Identity, IdProperty]
        public Int32? Id
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
        }


        [DisplayName("Hsn Name"), Size(1000), QuickSearch, NameProperty]
        public String HsnName
        {
            get => fields.HsnName[this];
            set => fields.HsnName[this] = value;
        }

        [DisplayName("Hsn Code"), Size(255)]
        public String HsnCode
        {
            get => fields.HsnCode[this];
            set => fields.HsnCode[this] = value;
        }

        [DisplayName("Hsn Description"), Size(1000)]
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
            public StringField HsnName;
            public StringField HsnCode;
            public StringField HsnDescription;
        }
    }
}
