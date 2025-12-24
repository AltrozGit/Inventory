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
    [DisplayName("Minimum Stocks Alert"), InstanceName("Stock")]
    [ReadPermission("*")]
    [ModifyPermission("*")]
    public sealed class MinStockRow : Row<MinStockRow.RowFields>, IIdRow, INameRow
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

        [DisplayName("Warehouse"), Size(100)]
        public String WarehouseName
        {
            get => fields.WarehouseName[this];
            set => fields.WarehouseName[this] = value;
        }

        [DisplayName("Qty")]
        public Double? Qty
        {
            get => fields.Qty[this];
            set => fields.Qty[this] = value;
        }

        [DisplayName("Minimum")]
        public Double? MinimumQty
        {
            get => fields.MinimumQty[this];
            set => fields.MinimumQty[this] = value;
        }

        [DisplayName("Uom"), Size(50)]
        public String Uom
        {
            get => fields.Uom[this];
            set => fields.Uom[this] = value;
        }

        public MinStockRow()
            : base()
        {
        }

        public MinStockRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field Id;
            public StringField ProductName;
            public StringField WarehouseName;
            public DoubleField Qty;
            public DoubleField MinimumQty;
            public StringField Uom;
        }
    }
}
