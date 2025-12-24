using FluentMigrator;
using Serenity.Extensions;



namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20240929011541)]
    public class DefaultDB_20240929_011541_Indotalent_AddColForGSTAmountCalculate_UnderInvoiceDetailTable : AutoReversingMigration
    {
        public override void Up()
        {
            Alter.Table("InvoiceDetail").InSchema("dbo")
             .AddColumn("SGSTAmount").AsDouble().Nullable()
             .AddColumn("CGSTAmount").AsDouble().Nullable()
             .AddColumn("IGSTAmount").AsDouble().Nullable();

        }

    }
}
