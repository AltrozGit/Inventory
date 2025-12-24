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
    [DisplayName("Movements"), InstanceName("Movement")]
    [LookupScript]
    [ReadPermission("Inventory:Movement")]
    [ModifyPermission("Inventory:Movement")]
    public sealed class MovementRow : Row<MovementRow.RowFields>, IIdRow, INameRow
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

        [DisplayName("Number"), Size(50), NotNull]
        public String Number
        {
            get => fields.Number[this];
            set => fields.Number[this] = value;
        }

        [DisplayName("Period"), Size(50), NotNull]
        public String Period
        {
            get => fields.Period[this];
            set => fields.Period[this] = value;
        }

        [DisplayName("Module"), Size(50), NotNull]
        public String Module
        {
            get => fields.Module[this];
            set => fields.Module[this] = value;
        }

        [DisplayName("Transaction Date"), NotNull]
        public DateTime? TransactionDate
        {
            get => fields.TransactionDate[this];
            set => fields.TransactionDate[this] = value;
        }

        [DisplayName("Internal Code/ HSN No"), Size(50)]
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

        [DisplayName("Uom"), Size(50)]
        public String Uom
        {
            get => fields.Uom[this];
            set => fields.Uom[this] = value;
        }

        public MovementRow()
            : base()
        {
        }

        public MovementRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field Id;
            public StringField Number;
            public StringField Period;
            public StringField Module;
            public DateTimeField TransactionDate;
            public StringField ProductName;
            public StringField InternalCode;
            public StringField Barcode;
            public StringField ProjectName;
            public StringField WarehouseName;
            public DoubleField Qty;
            public StringField Uom;
        }
    }
}
