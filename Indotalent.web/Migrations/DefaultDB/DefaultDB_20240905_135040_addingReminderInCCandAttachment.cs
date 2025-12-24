using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20240905135040)]
    public class DefaultDB_20240905_135040_addingReminderInCCandAttachment : AutoReversingMigration
    {
        public override void Up()
        {
            Alter.Table("DueDateReminder").InSchema("dbo")
           .AddColumn("ReminderInCC").AsString(255).Nullable()
           .AddColumn("Attachment").AsString(int.MaxValue).Nullable();

            
        }
    }
}
