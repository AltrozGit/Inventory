using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20250417131248)]
    public class DefaultDB_20250417_131248_AddTaxDetailsQuotaionDetailTbl : AutoReversingMigration
    {
        public override void Up()
        {
            Alter.Table("QuotationDetail").InSchema("dbo")
             .AddColumn("SGSTAmount").AsDouble().Nullable()
             .AddColumn("CGSTAmount").AsDouble().Nullable()
             .AddColumn("IGSTAmount").AsDouble().Nullable()
             .AddColumn("SGST ").AsDouble().Nullable()
             .AddColumn("CGST").AsDouble().Nullable()
             .AddColumn("IGST").AsDouble().Nullable();

            Alter.Table("Quotation").InSchema("dbo")
           .AddColumn("CustomerId").AsInt32().NotNullable();




        }
    }
}