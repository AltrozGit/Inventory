using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20231018122810)]
    public class DefaultDB_20231018_122810_Indotalent_DueDateReminder : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("DueDateReminder")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
               
                .WithColumn("ConsentDueDate").AsDateTime().NotNullable()
                .WithColumn("InsertDate").AsDateTime().Nullable()
                .WithColumn("InsertUserId").AsInt32().Nullable()
                .WithColumn("UpdateDate").AsDateTime().Nullable()
                .WithColumn("UpdateUserId").AsInt32().Nullable()
                .WithColumn("TenantId").AsInt32().NotNullable();
        }
    }
}