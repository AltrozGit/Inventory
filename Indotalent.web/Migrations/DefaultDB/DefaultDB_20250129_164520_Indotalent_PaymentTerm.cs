using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
	[Migration(20250129164520)]
	public class DefaultDB_20250129_164520_Indotalent_PaymentTerm : AutoReversingMigration
	{
		public override void Up()
		{

			Create.Table("PaymentTerm")
			.WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
			.WithColumn("TermName").AsString(200).NotNullable()
			.WithColumn("TermNameCode").AsString(200).NotNullable()
			.WithColumn("Description").AsString(1000).Nullable()
			.WithColumn("InsertDate").AsDateTime().Nullable()
			.WithColumn("InsertUserId").AsInt32().Nullable()
			.WithColumn("UpdateDate").AsDateTime().Nullable()
			.WithColumn("UpdateUserId").AsInt32().Nullable()
			.WithColumn("IsActive").AsBoolean().NotNullable().WithDefaultValue(true)
			.WithColumn("TenantId").AsInt32().NotNullable();

			Create.UniqueConstraint("PaymentTermUniqueConstraint").OnTable("PaymentTerm").Columns("TermName", "TenantId");


		}
	}
}