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
    [ConnectionKey("Default"), Module("Material"), TableName("[dbo].[MaterialRequestTracking]")]
    [DisplayName("Comment"), InstanceName("Comment")]
    [ReadPermission("Material:MaterialRequestTracking")]
    [ModifyPermission("Material:MaterialRequestTracking")]
    [LookupScript(LookupType = typeof(MultiTenantRowLookupScript<>))]


    public sealed class MaterialRequestTrackingRow : Row<MaterialRequestTrackingRow.RowFields>, IIdRow, IMultiTenantRow, IInsertLogRow
    {
        [DisplayName("Id"), Identity, IdProperty]
        public Int32? Id
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
        }

        [DisplayName("Material Request"), NotNull, ForeignKey("[dbo].[MaterialRequest]", "Id"), LeftJoin("jMaterialRequest"), TextualField("MaterialRequestNumber")]
        public Int32? MaterialRequestId
        {
            get => fields.MaterialRequestId[this];
            set => fields.MaterialRequestId[this] = value;
        }

        [DisplayName("Material Request"), Expression("jMaterialRequest.[Number]"),]
        public String MaterialRequestNumber
        {
            get => fields.MaterialRequestNumber[this];
            set => fields.MaterialRequestNumber[this] = value;
        }
        [DisplayName("Comment"), NotNull, QuickSearch]
        public String Comment
        {
            get => fields.Comment[this];
            set => fields.Comment[this] = value;
        }

        [DisplayName("Commented On"), NotNull, Insertable(false), Updatable(false), QuickSearch]
        public DateTime? InsertDate
        {
            get => fields.InsertDate[this];
            set => fields.InsertDate[this] = value;
        }

        
        [DisplayName("Insert User Id"),ForeignKey("[dbo].[Users]", "UserId"), LeftJoin("jUsers"), TextualField("Username")]
        public Int32? InsertUserId
        {
            get => fields.InsertUserId[this];
            set => fields.InsertUserId[this] = value;
        }
        [DisplayName("Commented By"), Expression("jUsers.[Username]"), MinSelectLevel(SelectLevel.List)]
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

        public MaterialRequestTrackingRow()
            : base()
        {
        }

        public MaterialRequestTrackingRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field Id;
            public Int32Field MaterialRequestId;
            public StringField MaterialRequestNumber;

            public StringField Comment;
            public DateTimeField InsertDate;
            public Int32Field InsertUserId;
            public Int32Field TenantId;
            public StringField TenantName;
            public StringField InsertUserDisplayName;
        }
    }
}
