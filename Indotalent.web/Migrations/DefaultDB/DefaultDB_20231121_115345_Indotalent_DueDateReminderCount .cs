using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20231121115345)]
    public class DefaultDB_20231121_115345_Indotalent_DueDateReminderCount : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("DueDateReminderCount")
                .WithColumn("CountId").AsInt32().PrimaryKey().Identity().NotNullable()
                .WithColumn("DueDateReminderId").AsInt32().NotNullable()
                    .ForeignKey("FK_ReminderCount_DueDateReminderId", "DueDateReminder", "Id")
                .WithColumn("ReminderCount").AsInt32().NotNullable()
                .WithColumn("InsertDate").AsDateTime().Nullable()
                .WithColumn("InsertUserId").AsInt32().Nullable()
                .WithColumn("UpdateDate").AsDateTime().Nullable()
                .WithColumn("UpdateUserId").AsInt32().Nullable();
        }
    }
}