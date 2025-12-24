using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20230602121201)]
    public class DefaultDB_20230602_121201_Indotalent_Expense : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("Expense")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
                .WithColumn("Name").AsString(200).NotNullable()
                .WithColumn("Description").AsString(1000).Nullable()
                .WithColumn("InsertDate").AsDateTime().Nullable()
                .WithColumn("InsertUserId").AsInt32().Nullable()
                .WithColumn("UpdateDate").AsDateTime().Nullable()
                .WithColumn("UpdateUserId").AsInt32().Nullable()
                .WithColumn("TenantId").AsInt32().NotNullable();

            Create.UniqueConstraint("ExpenseUniqueConstraint").OnTable("Expense").Columns("Name", "TenantId");
        }
    }
}