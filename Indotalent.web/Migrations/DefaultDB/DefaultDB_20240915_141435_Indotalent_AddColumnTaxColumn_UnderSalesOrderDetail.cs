using FluentMigrator;
using Serenity.Extensions;


namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20240915141435)]
    public class DefaultDB_20240915_141435_Indotalent_AddColumnTaxColumn_UnderSalesOrderDetail : AutoReversingMigration
    {
        public override void Up()
        {

            Alter.Table("SalesOrderDetail").InSchema("dbo")
            .AddColumn("SGST ").AsDouble().Nullable()
             .AddColumn("CGST").AsDouble().Nullable()
             .AddColumn("IGST").AsDouble().Nullable();


        }
    }
}
