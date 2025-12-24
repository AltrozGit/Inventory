using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20240809165795)]
    public class DefaultDB_20240809_165795_Indotalent_AddColumnTaxColumn_UnderPurchesOrder : AutoReversingMigration
    {
        public override void Up()
        {

            Alter.Table("PurchaseOrder").InSchema("dbo")
            .AddColumn("SGST ").AsDouble().Nullable()
             .AddColumn("CGST").AsDouble().Nullable()
             .AddColumn("IGST").AsDouble().Nullable();

          
		}
    }
}