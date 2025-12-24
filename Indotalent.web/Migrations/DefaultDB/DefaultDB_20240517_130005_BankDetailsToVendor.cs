using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20240517130005)]
    public class DefaultDB_20240517_130005_BankDetailsToVendor : AutoReversingMigration
    {
        public override void Up()
        {
            Alter.Table("Vendor").InSchema("dbo")
                .AddColumn("BankName").AsString().Nullable()
                .AddColumn("BankBranch").AsString().Nullable()
                .AddColumn("PanNumber").AsString().Nullable();
        }
    }
}