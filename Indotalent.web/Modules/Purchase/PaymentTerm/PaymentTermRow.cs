using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using Serenity.Extensions.Entities;
using System;
using System.ComponentModel;
using System.IO;

namespace Indotalent.Purchase
{
    [ConnectionKey("Default"), Module("Purchase"), TableName("[dbo].[PaymentTerm]")]
    [DisplayName("Payment Term"), InstanceName("Payment Term")]
    [ReadPermission("Purchase:PaymentTerm")]
    [ModifyPermission("Purchase:PaymentTerm")]
	[LookupScript(LookupType = typeof(MultiTenantRowLookupScript<>))]

	public sealed class PaymentTermRow : LoggingRow<PaymentTermRow.RowFields>, IIdRow, INameRow, IMultiTenantRow
	{
        [DisplayName("Id"), Identity, IdProperty]
        public Int32? Id
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
        }

        [DisplayName("Term Name"), Size(200), NotNull, QuickSearch, NameProperty]
        public String TermName
        {
            get => fields.TermName[this];
            set => fields.TermName[this] = value;
        }

        [DisplayName("Term Name Code"), Size(200), NotNull]
        public String TermNameCode
        {
            get => fields.TermNameCode[this];
            set => fields.TermNameCode[this] = value;
        }

        [DisplayName("Description"), Size(1000)]
        public String Description
        {
            get => fields.Description[this];
            set => fields.Description[this] = value;
        }

        [DisplayName("Is Active"), NotNull]
        public Boolean? IsActive
        {
            get => fields.IsActive[this];
            set => fields.IsActive[this] = value;
        }

		[DisplayName("Tenant"), ForeignKey("Tenant", "TenantId"), LeftJoin("jTenant")]
		[Insertable(false), Updatable(false)]
		public int? TenantId
		{
			get { return Fields.TenantId[this]; }
			set { Fields.TenantId[this] = value; }
		}

		[DisplayName("Tenant"), Expression("jTenant.TenantName")]
		public string TenantName
		{
			get { return Fields.TenantName[this]; }
			set { Fields.TenantName[this] = value; }
		}

		public Int32Field TenantIdField
		{
			get { return Fields.TenantId; }
		}
		public PaymentTermRow()
            : base()
        {
        }

        public PaymentTermRow(RowFields fields)
            : base(fields)
        {
        }

		public class RowFields : LoggingRowFields
		{
			public Int32Field Id;
			public StringField TermName;
			public StringField TermNameCode;
			public StringField Description;

			public BooleanField IsActive;
			public Int32Field TenantId;
			public StringField TenantName;
		}
	}
}
