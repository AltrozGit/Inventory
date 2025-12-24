using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;
using System.IO;
using Serenity.Extensions.Entities;

namespace Indotalent.Material
{
    [ConnectionKey("Default"), Module("Material"), TableName("[dbo].[MaterialRequestStatusMaster]")]
    [DisplayName("Status Master"), InstanceName("Status Master")]
    [ReadPermission("Material:StatusMaster")]
    [ModifyPermission("Material:StatusMaster")]
    [LookupScript(LookupType = typeof(MultiTenantRowLookupScript<>))]

    public sealed class StatusMasterRow : LoggingRow<StatusMasterRow.RowFields>, IIdRow, INameRow,IMultiTenantRow
    {
        [DisplayName("Id"), Identity, IdProperty]
        
        public Int32? Id
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
        }

        [DisplayName("Status Name"), Size(200), NotNull, QuickSearch, NameProperty]
        public String MaterialRequestStatusName
        {
            get => fields.MaterialRequestStatusName[this];
            set => fields.MaterialRequestStatusName[this] = value;
        }

        [DisplayName("Description"), Size(1000), QuickSearch]
        public String MaterialRequestStatusDescription
        {
            get => fields.MaterialRequestStatusDescription[this];
            set => fields.MaterialRequestStatusDescription[this] = value;
        }

        //[DisplayName("Insert Date")]
        //public DateTime? InsertDate
        //{
        //    get => fields.InsertDate[this];
        //    set => fields.InsertDate[this] = value;
        //}

        //[DisplayName("Insert User Id")]
        //public Int32? InsertUserId
        //{
        //    get => fields.InsertUserId[this];
        //    set => fields.InsertUserId[this] = value;
        //}

        //[DisplayName("Update Date")]
        //public DateTime? UpdateDate
        //{
        //    get => fields.UpdateDate[this];
        //    set => fields.UpdateDate[this] = value;
        //}

        //[DisplayName("Update User Id")]
        //public Int32? UpdateUserId
        //{
        //    get => fields.UpdateUserId[this];
        //    set => fields.UpdateUserId[this] = value;
        //}


        [DisplayName("Tenant"), ForeignKey("Tenant", "TenantId"), LeftJoin("jTenant")]
        [Insertable(false), Updatable(false)]
        public Int32? TenantId
        {
            get { return Fields.TenantId[this]; }
            set { Fields.TenantId[this] = value; }
        }

        [DisplayName("Tenant"), Expression("jTenant.TenantName")]
        public String TenantName
        {
            get { return Fields.TenantName[this]; }
            set { Fields.TenantName[this] = value; }
        }

        public Int32Field TenantIdField
        {
            get { return Fields.TenantId; }
        }


        public StatusMasterRow()
            : base()
        {
        }

        public StatusMasterRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : LoggingRowFields
        {
            public Int32Field Id;
            public StringField MaterialRequestStatusName;
            public StringField MaterialRequestStatusDescription;
            //public DateTimeField InsertDate;
            //public Int32Field InsertUserId;
            //public DateTimeField UpdateDate;
            //public Int32Field UpdateUserId;
            public Int32Field TenantId;
            public StringField TenantName;

        }
    }
}
