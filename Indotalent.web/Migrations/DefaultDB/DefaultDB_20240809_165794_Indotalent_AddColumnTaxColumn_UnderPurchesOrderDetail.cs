using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20240809165794)]
    public class DefaultDB_20240809_165794_Indotalent_AddColumnTaxColumn_UnderPurchesOrderDetail : AutoReversingMigration
    {
        public override void Up()
        {

            Alter.Table("PurchaseOrderDetail").InSchema("dbo")
            .AddColumn("SGST ").AsDouble().Nullable()
             .AddColumn("CGST").AsDouble().Nullable()
             .AddColumn("IGST").AsDouble().Nullable();

          
		}
    }
}