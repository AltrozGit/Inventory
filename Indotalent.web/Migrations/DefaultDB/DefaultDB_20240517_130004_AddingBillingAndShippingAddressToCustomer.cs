using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20240517130004)]
    public class DefaultDB_20240517_130004_AddingBillingAndShippingAddressToCustomer : AutoReversingMigration
    {
        public override void Up()
        {
            Alter.Table("Customer").InSchema("dbo")
                .AddColumn("BillingAddress").AsString().Nullable()
                .AddColumn("ShippingAddress").AsString().Nullable();
        }
    }
}