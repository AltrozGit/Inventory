using FluentMigrator;
using Serenity.Extensions;



namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20240929011040)]
    public class DefaultDB_20240929_011040_Indotalent_AddColForGSTAmountCalculate_UnderSalesOrderDetailTable : AutoReversingMigration
    {
        public override void Up()
        {
            Alter.Table("SalesOrderDetail").InSchema("dbo")
             .AddColumn("SGSTAmount").AsDouble().Nullable()
             .AddColumn("CGSTAmount").AsDouble().Nullable()
             .AddColumn("IGSTAmount").AsDouble().Nullable();

        }
    }
}
