using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20242610165747)]
    public class DefaultDB_20242610_165747_Indotalent_AlterPurchaseOrder_Discount : AutoReversingMigration
    {
        public override void Up()
        {

            Alter.Table("PurchaseOrder").InSchema("dbo")
             .AlterColumn("Discount").AsDouble().Nullable();
			 
		}
    }
}