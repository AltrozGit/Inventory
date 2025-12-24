using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using Serenity.Extensions.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
namespace Indotalent.Material
{
    [ConnectionKey("Default"), Module("Material"), TableName("[dbo].[MaterialRequestStatus]")]
    [DisplayName("Status"), InstanceName("Status")]
    [ReadPermission("Material:MaterialRequestStatus")]
    [ModifyPermission("Material:MaterialRequestStatus")]
    [LookupScript(LookupType = typeof(MultiTenantRowLookupScript<>))]

    public sealed class MaterialRequestStatusRow : Row<MaterialRequestStatusRow.RowFields>, IIdRow, INameRow,IMultiTenantRow, IInsertLogRow
    {
        [DisplayName("Id"), Identity, IdProperty]
        public Int32? Id
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
        }

        [DisplayName("Request"), NotNull, ForeignKey("[dbo].[MaterialRequest]", "Id"), LeftJoin("jMaterialRequest"), TextualField("MaterialRequestNumber")]
        public Int32? MaterialRequestId
        {
            get => fields.MaterialRequestId[this];
            set => fields.MaterialRequestId[this] = value;
        }

        [DisplayName("Status"), NotNull, ForeignKey("[dbo].[MaterialRequestStatusMaster]", "Id"), LeftJoin("jStatus"), TextualField("MaterialRequestStatusName")]
        [LookupEditor(typeof(StatusMasterRow), InplaceAdd = true)]

        public Int32? StatustId
        {
            get => fields.StatustId[this];
            set => fields.StatustId[this] = value;
        }

        [DisplayName("Description"), Size(1000), QuickSearch,NameProperty]
        public String Description
        {
            get => fields.Description[this];
            set => fields.Description[this] = value;
        }

        [DisplayName("Material Request Number"), Expression("jMaterialRequest.[Number]")]
        public String MaterialRequestNumber
        {
            get => fields.MaterialRequestNumber[this];
            set => fields.MaterialRequestNumber[this] = value;
        }

    

        [DisplayName("Status"), Expression("jStatus.[MaterialRequestStatusName]"), MinSelectLevel(SelectLevel.List)]
        public String MaterialRequestStatusName
        {
            get => fields.MaterialRequestStatusName[this];
            set => fields.MaterialRequestStatusName[this] = value;
        }
        [DisplayName("Changed On"), NotNull, Insertable(false), Updatable(false), QuickSearch]
        public DateTime? InsertDate
        {
            get => fields.InsertDate[this];
            set => fields.InsertDate[this] = value;
        }


        [DisplayName("Insert User Id"), ForeignKey("[dbo].[Users]", "UserId"), LeftJoin("jUsers"), TextualField("Username")]
        public Int32? InsertUserId
        {
            get => fields.InsertUserId[this];
            set => fields.InsertUserId[this] = value;
        }
        [DisplayName("Changed By"), Expression("jUsers.[Username]"), MinSelectLevel(SelectLevel.List)]
        public String InsertUserDisplayName
        {
            get { return Fields.InsertUserDisplayName[this]; }
            set { Fields.InsertUserDisplayName[this] = value; }
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
        public Field InsertUserIdField
        {
            get
            {
                return Fields.InsertUserId;
            }
        }

        public DateTimeField InsertDateField
        {
            get
            {
                return Fields.InsertDate;
            }
        }

        public MaterialRequestStatusRow()
            : base()
        {
        }

        public MaterialRequestStatusRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field Id;
            public Int32Field MaterialRequestId;
            public Int32Field StatustId;
            public StringField Description;
         
            public Int32Field TenantId;

            public StringField MaterialRequestNumber;

            public StringField TenantName;

            public StringField MaterialRequestStatusName;
            public DateTimeField InsertDate;
            public Int32Field InsertUserId;
            public StringField InsertUserDisplayName;
          

        }
    }
}
