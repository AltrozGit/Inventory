using Indotalent.Administration.Lookups;
using Indotalent.Inventory;
using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using Serenity.Extensions.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using Indotalent.Web.Modules.Projects.Project;
using Indotalent.Web.Modules.Inventory.Warehouse;

namespace Indotalent.General
{
    [ConnectionKey("Default"), Module("General"), TableName("[dbo].[Action]")]
    [DisplayName("Action"), InstanceName("Action")]
    [ReadPermission("General:Action")]
    [ModifyPermission("General:Action")]
	[LookupScript(LookupType = typeof(MultiTenantRowLookupScript<>))]
	public sealed class ActionRow : LoggingRow<ActionRow.RowFields>, IIdRow, INameRow, IMultiTenantRow
	{
        [DisplayName("Id"), Identity, IdProperty]
        public Int32? Id
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
        }

        [DisplayName("Action Name "), Column("ActionName "), Size(200), NotNull, QuickSearch, NameProperty]
        public String ActionName
        {
            get => fields.ActionName[this];
            set => fields.ActionName[this] = value;
        }

        [DisplayName("Description"), Size(1000)]
        public String Description
        {
            get => fields.Description[this];
            set => fields.Description[this] = value;
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

        [DisplayName("Is Active")]
        public Boolean? IsActive
        {
            get => fields.IsActive[this];
            set => fields.IsActive[this] = value;
        }

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

		public ActionRow()
            : base()
        {
        }

        public ActionRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : LoggingRowFields
		{
            public Int32Field Id;
            public StringField ActionName;
            public StringField Description;
            //public DateTimeField InsertDate;
            //public Int32Field InsertUserId;
            //public DateTimeField UpdateDate;
            //public Int32Field UpdateUserId;
            public BooleanField IsActive;
            public Int32Field TenantId;
			public StringField TenantName;
		}
    }
}
