using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20250106144040)]
    public class DefaultDB_20250106_144040_addingSubjectinDueDateReminder : AutoReversingMigration
    {
        public override void Up()
        {
            Alter.Table("DueDateReminder").InSchema("dbo")
           .AddColumn("Subject").AsString(255).Nullable()
           .AddColumn("TenantPhone").AsString(255).Nullable()
           .AddColumn("CustomerPhone").AsString(255).Nullable()

           .AddColumn("TenantEmail").AsString(255).Nullable();






        }
    }
}
