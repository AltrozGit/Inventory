using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20240802165748)]
    public class DefaultDB_20240802_165748_Indotalent_AddColumnTaxColumn_UnderSalesTax : AutoReversingMigration
    {
        public override void Up()
        {

            Alter.Table("SalesTax").InSchema("dbo")
             .AddColumn("TaxType ").AsInt32().Nullable()
             .AddColumn("SGST ").AsDouble().Nullable()
             .AddColumn("CGST").AsDouble().Nullable()
             .AddColumn("IGST").AsDouble().Nullable();

          
		}
    }
}