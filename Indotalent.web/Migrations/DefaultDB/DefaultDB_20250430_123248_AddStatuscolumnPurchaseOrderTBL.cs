using FluentMigrator;

using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB

{

    [Migration(20250430123248)]

    public class DefaultDB_20250430_123248_AddStatuscolumnPurchaseOrderTBL : AutoReversingMigration

    {

        public override void Up()
        {
            Alter.Table("PurchaseOrder").InSchema("dbo")
              .AddColumn("Status").AsInt32().NotNullable().WithDefaultValue(1);

            Alter.Table("PurchaseReceipt").InSchema("dbo")
             .AddColumn("Status").AsInt32().NotNullable().WithDefaultValue(1);
        }

    }

}

