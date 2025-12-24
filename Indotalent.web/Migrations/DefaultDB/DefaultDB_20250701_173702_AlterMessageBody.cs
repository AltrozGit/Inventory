using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20250701173702)]
    public class DefaultDB_20250701_173702_AlterMessageBody : AutoReversingMigration
    {
        public override void Up()
        {
            Alter.Table("DueDateReminder").InSchema("dbo")
               .AlterColumn("MessageBody").AsString(int.MaxValue).Nullable();
        }
    }
}