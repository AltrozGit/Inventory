using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;
using System.IO;

namespace Indotalent.Inventory
{
    [ConnectionKey("Default"), Module("Inventory")]
    [DisplayName("Stocks"), InstanceName("Stock")]
    [LookupScript]
    [ReadPermission("Inventory:Stock")]
    [ModifyPermission("Inventory:Stock")]
    public sealed class StockRow : Row<StockRow.RowFields>, IIdRow, INameRow
    {
        [DisplayName("Id"), Identity, IdProperty]
        public Int32? Id
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
        }

        [DisplayName("Product Name"), Size(100), NotNull, QuickSearch, NameProperty]
        public String ProductName
        {
            get => fields.ProductName[this];
            set => fields.ProductName[this] = value;
        }

        [DisplayName("Internal Code /HSN No"), Size(50)]
        public String InternalCode
        {
            get => fields.InternalCode[this];
            set => fields.InternalCode[this] = value;
        }

        [DisplayName("Barcode"), Size(50)]
        public String Barcode
        {
            get => fields.Barcode[this];
            set => fields.Barcode[this] = value;
        }
        [DisplayName("Project Name"), Size(100)]
        public String ProjectName
        {
            get => fields.ProjectName[this];
            set => fields.ProjectName[this] = value;
        }
        [DisplayName("Warehouse Name"), Size(100)]
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

        

        [DisplayName("Total Price")]
        public Double? TotalPrice
        {
            get => fields.TotalPrice[this];
            set => fields.TotalPrice[this] = value;
        }

        [DisplayName("Uom"), Size(50)]
        public String Uom
        {
            get => fields.Uom[this];
            set => fields.Uom[this] = value;
        }

        public StockRow()
            : base()
        {
        }

        public StockRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field Id;
            public StringField ProductName;
            public StringField InternalCode;
            public StringField Barcode;
            public StringField ProjectName;

            public StringField WarehouseName;
            public DoubleField Qty;
            public StringField Uom;
            public DoubleField TotalPrice;
        }
    }
}
