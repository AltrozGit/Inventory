using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20241010_130002)]
    public class DefaultDB_20241010_130002_AddingMessageBoday_Remainder1andRemainder2 : AutoReversingMigration
    {
        public override void Up()
        {
            Alter.Table("DueDateReminder").InSchema("dbo")

                .AddColumn("MessageBody").AsString().Nullable()
            .AddColumn("Remainder1").AsDateTime().Nullable()
            .AddColumn("Remainder2").AsDateTime().Nullable()
            .AddColumn("SendRemainderOnEmail").AsBoolean().Nullable()
            .AddColumn("SendRemainderOnWhatsapp").AsBoolean().Nullable();
        }
    }
}