using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;
using System.IO;

namespace Indotalent.Common.DashboardInventory
{
    [ConnectionKey("Default")]
    [DisplayName("Most Frequent Sold Products"), InstanceName("Stock")]
    [ReadPermission("*")]
    [ModifyPermission("*")]
    public sealed class MostSoldRow : Row<MostSoldRow.RowFields>, IIdRow, INameRow
    {
        [DisplayName("Id"), Identity, IdProperty]
        public Int32? Id
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
        }

        [DisplayName("Product"), Size(100), NotNull, QuickSearch, NameProperty]
        public String ProductName
        {
            get => fields.ProductName[this];
            set => fields.ProductName[this] = value;
        }

        [DisplayName("Qty")]
        public Double? Qty
        {
            get => fields.Qty[this];
            set => fields.Qty[this] = value;
        }

        [DisplayName("Uom"), Size(50)]
        public String Uom
        {
            get => fields.Uom[this];
            set => fields.Uom[this] = value;
        }

        public MostSoldRow()
            : base()
        {
        }

        public MostSoldRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field Id;
            public StringField ProductName;
            public DoubleField Qty;
            public StringField Uom;
        }
    }
}
