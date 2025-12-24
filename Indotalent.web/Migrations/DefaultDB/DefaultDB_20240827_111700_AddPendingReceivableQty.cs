using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20240827111700)]
    public class DefaultDB_20240827_111700_AddPendingReceivableQty : AutoReversingMigration
    {
        public override void Up()
        {
            Alter.Table("PurchaseReceiptDetail").InSchema("dbo")

                .AddColumn("PendingReceivableQty ").AsDouble().NotNullable().WithDefaultValue(0);
        }
    }
}