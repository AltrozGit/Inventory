using Indotalent.Web.Modules.Merchandise.Product;
using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using Serenity.Extensions.Entities;
using System;
using System.ComponentModel;
using System.IO;

namespace Indotalent.Sales
{
    [ConnectionKey("Default"), Module("Sales"), TableName("[dbo].[SalesReturnDetail]")]
    [DisplayName("Item Return Detail"), InstanceName("Item Return Detail")]
    [ReadPermission("Sales:SalesReturnDetail")]
    [ModifyPermission("Sales:SalesReturnDetail")]
    [LookupScript(LookupType = typeof(MultiTenantRowLookupScript<>))]
    public sealed class SalesReturnDetailRow : LoggingRow<SalesReturnDetailRow.RowFields>, IIdRow, IMultiTenantRow
   {

        [DisplayName("Id"), Identity, IdProperty]
        public Int32? Id
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
        }

        [DisplayName("Sales Return"), NotNull, ForeignKey("[dbo].[SalesReturn]", "Id"), LeftJoin("jSalesReturn"), TextualField("SalesReturnNumber")]
        public Int32? SalesReturnId
        {
            get => fields.SalesReturnId[this];
            set => fields.SalesReturnId[this] = value;
        }

        [DisplayName("Product"), NotNull, ForeignKey("[dbo].[Product]", "Id"), LeftJoin("jProduct"), TextualField("ProductName")]
        [LookupEditor(typeof(ProductLookup), InplaceAdd = true, DialogType = "Indotalent.Merchandise.ProductDialog")]
        public Int32? ProductId
        {
            get => fields.ProductId[this];
            set => fields.ProductId[this] = value;
        }

        [DisplayName("Product"), Expression("jProduct.[Name]"), MinSelectLevel(SelectLevel.List), NameProperty]
        public String ProductName
        {
            get => fields.ProductName[this];
            set => fields.ProductName[this] = value;
        }

        [DisplayName("Qty Return"), NotNull]
        [DefaultValue(1)]
        public Double? QtyReturn
        {
            get => fields.QtyReturn[this];
            set => fields.QtyReturn[this] = value;
        }

        [DisplayName("Sales Return Number"), Expression("jSalesReturn.[Number]")]
        public String SalesReturnNumber
        {
            get => fields.SalesReturnNumber[this];
            set => fields.SalesReturnNumber[this] = value;
        }

        [DisplayName("Tenant"), ForeignKey("Tenant", "TenantId"), LeftJoin("jTenant")]
        [Insertable(false), Updatable(false)]
        public Int32? TenantId
        {
            get { return Fields.TenantId[this]; }
            set { Fields.TenantId[this] = value; }
        }

        [DisplayName("Tenant"), Expression("jTenant.TenantName"), MinSelectLevel(SelectLevel.List)]
        public String TenantName
        {
            get { return Fields.TenantName[this]; }
            set { Fields.TenantName[this] = value; }
        }

        public Int32Field TenantIdField
        {
            get { return Fields.TenantId; }
        }

        public SalesReturnDetailRow()
            : base()
        {
        }

        public SalesReturnDetailRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : LoggingRowFields
        {
            public Int32Field Id;
            public Int32Field SalesReturnId;
            public Int32Field ProductId;
            public DoubleField QtyReturn;
            public StringField SalesReturnNumber;
            public StringField ProductName;
            public Int32Field TenantId;
            public StringField TenantName;
        }
    }
}
