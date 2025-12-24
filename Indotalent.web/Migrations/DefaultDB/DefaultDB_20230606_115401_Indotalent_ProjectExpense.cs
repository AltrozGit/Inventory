using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20230606115401)]
    public class DefaultDB_20230606_115401_Indotalent_ProjectExpense : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("ProjectExpense")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
                .WithColumn("ProjectId").AsInt32().NotNullable()
                    .ForeignKey("FK_ProjectExpense_ProjectId", "Project", "Id")
                .WithColumn("ExpenseId").AsInt32().NotNullable()
                    .ForeignKey("FK_ProjectExpense_ExpenseId", "Expense", "Id")
                      .WithColumn("Cost").AsDouble().NotNullable()
               .WithColumn("ExpenseDate").AsDateTime().NotNullable()
                .WithColumn("InsertDate").AsDateTime().Nullable()
                .WithColumn("InsertUserId").AsInt32().Nullable()
                .WithColumn("UpdateDate").AsDateTime().Nullable()
                .WithColumn("UpdateUserId").AsInt32().Nullable()
                .WithColumn("TenantId").AsInt32().NotNullable();
        }
    }
}