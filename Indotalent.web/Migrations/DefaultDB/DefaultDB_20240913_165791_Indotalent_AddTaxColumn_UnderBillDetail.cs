using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20240913165791)]
    public class DefaultDB_20240913_165791_Indotalent_AddTaxColumn_UnderBillDetail : AutoReversingMigration
    {
        public override void Up()
        {

            Alter.Table("BillDetail").InSchema("dbo")
            .AddColumn("SGST ").AsDouble().Nullable()
             .AddColumn("CGST").AsDouble().Nullable()
             .AddColumn("IGST").AsDouble().Nullable();

          
		}
    }
}