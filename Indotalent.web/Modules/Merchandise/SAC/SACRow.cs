using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;
using System.IO;

namespace Indotalent.Merchandise
{
    [ConnectionKey("Default"), Module("Merchandise"), TableName("[dbo].[SAC]")]
    [DisplayName("Sac"), InstanceName("Sac")]
    [ReadPermission("Merchandise:SAC")]
    [ModifyPermission("Merchandise:Product")]
    [LookupScript]
    public sealed class SACRow : Row<SACRow.RowFields>, IIdRow, INameRow
    {
        [DisplayName("Id"), Identity, IdProperty]
        public Int32? Id
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
        }

        [DisplayName("Sac Name"), Size(1000), QuickSearch, NameProperty]
        public String SacName
        {
            get => fields.SacName[this];
            set => fields.SacName[this] = value;
        }

        [DisplayName("Sac Code"), Size(255)]
        public String SacCode
        {
            get => fields.SacCode[this];
            set => fields.SacCode[this] = value;
        }

        [DisplayName("Sac Description"), Size(1000)]
        public String SacDescription
        {
            get => fields.SacDescription[this];
            set => fields.SacDescription[this] = value;
        }

        public SACRow()
            : base()
        {
        }

        public SACRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field Id;
            public StringField SacName;
            public StringField SacCode;
            public StringField SacDescription;
        }
    }
}
