using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20240731165747)]
    public class DefaultDB_20240731_165747_Indotalent_AddColumnTaxColumn_UnderPurchesTax : AutoReversingMigration
    {
        public override void Up()
        {

            Alter.Table("PurchaseTax").InSchema("dbo")
             .AddColumn("TaxType ").AsInt32().Nullable()
             .AddColumn("SGST ").AsDouble().Nullable()
             .AddColumn("CGST").AsDouble().Nullable()
             .AddColumn("IGST").AsDouble().Nullable();

          
		}
    }
}