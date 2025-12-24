using FluentMigrator;
using Serenity.Extensions;



namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20240928051040)]
    public class DefaultDB_20240928_051040_Indotalent_AddColForGSTAmountCalculate_UnderBillDetailTable : AutoReversingMigration
    {
        public override void Up()
        {
            Alter.Table("BillDetail").InSchema("dbo")
             .AddColumn("SGSTAmount").AsDouble().Nullable()
             .AddColumn("CGSTAmount").AsDouble().Nullable()
             .AddColumn("IGSTAmount").AsDouble().Nullable();

        }
    }
}
