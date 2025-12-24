using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20240516130001)]
    public class DefaultDB_20240516_130001_UpdatingVendorFormAndMyCompanyForm : AutoReversingMigration
    {
        public override void Up()
        {
            Alter.Table("Vendor").InSchema("dbo")
                .AddColumn("GSTNumber").AsString().Nullable()
                .AddColumn("AccountNumber").AsString().Nullable()
                .AddColumn("IFSCCode").AsString().Nullable();

            Alter.Table("Tenant").InSchema("dbo")
               .AddColumn("GSTNumber").AsString().Nullable()
               .AddColumn("AccountNumber").AsString().Nullable()
               .AddColumn("IFSCCode").AsString().Nullable();

            Alter.Table("Customer").InSchema("dbo")
                .AddColumn("GSTNumber").AsString().Nullable();
        }
    }
}