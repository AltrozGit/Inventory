using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20250108153002)]
    public class DefaultDB_20250108_153002_AddingLastProcessedDateInDueDateReminderCount : AutoReversingMigration
    {
        public override void Up()
        {
            Alter.Table("DueDateReminderCount").InSchema("dbo")


            .AddColumn("LastProcessedDate").AsDateTime().Nullable();
        }
    }
}