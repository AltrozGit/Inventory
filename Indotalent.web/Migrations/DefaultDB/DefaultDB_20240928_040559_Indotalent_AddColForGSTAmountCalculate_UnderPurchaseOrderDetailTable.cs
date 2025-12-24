using FluentMigrator;

using Serenity.Extensions;



namespace Indotalent.Migrations.DefaultDB

{

    [Migration(20240928040559)]

    public class DefaultDB_20240928_040559_Indotalent_AddColForGSTAmountCalculate_UnderPurchaseOrderDetailTable : AutoReversingMigration

    {

        public override void Up()

        {

            Alter.Table("PurchaseOrderDetail").InSchema("dbo")

             .AddColumn("SGSTAmount").AsDouble().Nullable()

             .AddColumn("CGSTAmount").AsDouble().Nullable()

             .AddColumn("IGSTAmount").AsDouble().Nullable();

        }

    }

}

