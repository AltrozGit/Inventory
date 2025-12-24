using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20240803130000)]
    public class DefaultDB_20240803_130000_Adding_Dispatch_Fields_To_Po : AutoReversingMigration
    {
        public override void Up()
        {

            Alter.Table("PurchaseOrder").InSchema("dbo")
                .AddColumn("DispatchedBy").AsString(500).Nullable()
                .AddColumn("DispatchedTo").AsString(500).Nullable()
                .AddColumn("DispatchDetails").AsString(500).Nullable();

        }
    }
}