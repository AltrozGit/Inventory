

using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20250324124000)]
    public class DefaultDB_20250324124000_AddNewNameHSNandSACColumn_UnderHSNSACTbl : AutoReversingMigration
    {
        public override void Up()
        {

            Alter.Table("HSN").InSchema("dbo")
                .AddColumn("HsnName").AsString(1000).Nullable()
                .AddColumn("HsnCode").AsString(255).Nullable()
                .AddColumn("HsnDescription").AsString(1000).Nullable();

            Alter.Table("SAC").InSchema("dbo")
                 .AddColumn("SacName").AsString(1000).Nullable()
                .AddColumn("SacCode").AsString(255).Nullable()
                .AddColumn("SacDescription").AsString(1000).Nullable();

        }
    }
}
