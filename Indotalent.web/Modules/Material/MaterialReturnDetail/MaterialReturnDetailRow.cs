using Indotalent.Web.Modules.Merchandise.Product;
using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;
using System.IO;

namespace Indotalent.Material
{
    [ConnectionKey("Default"), Module("Material"), TableName("[dbo].[MaterialReturnDetail]")]
    [DisplayName("Material Return Detail"), InstanceName("Material Return Detail")]
    [ReadPermission("Material:MaterialReturnDetail")]
    [ModifyPermission("Material:MaterialReturnDetail")]
    [LookupScript(LookupType = typeof(MultiTenantRowLookupScript<>))]
    public sealed class MaterialReturnDetailRow : Row<MaterialReturnDetailRow.RowFields>, IIdRow, IMultiTenantRow
    {
        [DisplayName("Id"), Identity, IdProperty]
        public Int32? Id
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
        }

        [DisplayName("Material Return"), NotNull, ForeignKey("[dbo].[MaterialReturn]", "Id"), LeftJoin("jMaterialReturn"), TextualField("MaterialReturnNumber")]
        public Int32? MaterialReturnId
        {
            get => fields.MaterialReturnId[this];
            set => fields.MaterialReturnId[this] = value;
        }

        [DisplayName("Product"), NotNull, ForeignKey("[dbo].[Product]", "Id"), LeftJoin("jProduct"), TextualField("ProductName")]
        [LookupEditor(typeof(ProductLookup), InplaceAdd = true, DialogType = "Indotalent.Merchandise.ProductDialog")]

        public Int32? ProductId
        {
            get => fields.ProductId[this];
            set => fields.ProductId[this] = value;
        }

        [DisplayName("Product Name"), Expression("jProduct.[Name]"), MinSelectLevel(SelectLevel.List), NameProperty]
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

        [DisplayName("Material Return Number"), Expression("jMaterialReturn.[Number]")]
        public String MaterialReturnNumber
        {
            get => fields.MaterialReturnNumber[this];
            set => fields.MaterialReturnNumber[this] = value;
        }

        [DisplayName("Insert Date")]
        public DateTime? InsertDate
        {
            get => fields.InsertDate[this];
            set => fields.InsertDate[this] = value;
        }

        [DisplayName("Insert User Id")]
        public Int32? InsertUserId
        {
            get => fields.InsertUserId[this];
            set => fields.InsertUserId[this] = value;
        }

        [DisplayName("Update Date")]
        public DateTime? UpdateDate
        {
            get => fields.UpdateDate[this];
            set => fields.UpdateDate[this] = value;
        }

        [DisplayName("Update User Id")]
        public Int32? UpdateUserId
        {
            get => fields.UpdateUserId[this];
            set => fields.UpdateUserId[this] = value;
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

        public MaterialReturnDetailRow()
            : base()
        {
        }

        public MaterialReturnDetailRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field Id;
            public Int32Field MaterialReturnId;
            public Int32Field ProductId;
            public StringField ProductName;
            public DoubleField QtyReturn;
            public StringField MaterialReturnNumber;
            public DateTimeField InsertDate;
            public Int32Field InsertUserId;
            public DateTimeField UpdateDate;
            public Int32Field UpdateUserId;
            public Int32Field TenantId;
            public StringField TenantName;

           

           
          
        }
    }
}
