using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;
using System.IO;

namespace Indotalent.Web.Modules.Merchandise.SAC
{
    [ConnectionKey("Default"), Module("InternalCode"), TableName("[dbo].[SAC]")]
    [DisplayName("Sac"), InstanceName("Sac")]
    [ReadPermission("InternalCode:SAC")]
    [ModifyPermission("InternalCode:SAC")]
    public sealed class SACRow : Row<SACRow.RowFields>, IIdRow, INameRow
    {
        [DisplayName("Id"), IdProperty]
        public Int32? Id
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
        }

        [DisplayName("Sac Code"), Column("SAC Code"), Size(255), QuickSearch, NameProperty]
        public String SacCode
        {
            get => fields.SacCode[this];
            set => fields.SacCode[this] = value;
        }

        [DisplayName("Sac Description"), Column("SAC Description"), Size(255)]
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
            public StringField SacCode;
            public StringField SacDescription;
        }
    }
}
