using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20240528140001)]
    public class DefaultDB_20240528_140001_UpdatingRemainderModule1 : AutoReversingMigration
    {
        public override void Up()
        {
            Alter.Table("DueDateReminder").InSchema("dbo")
                .AddColumn("IsActionComplete").AsBoolean().Nullable()
                .AddColumn("IsEnable").AsBoolean().Nullable();
        }
    }
}