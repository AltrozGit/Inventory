using FluentMigrator;

using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB

{

    [Migration(20250505125748)]

    public class DefaultDB_20250505_125748_AddcolumnIsPRetrunPurchaseReceiptTBL : AutoReversingMigration

    {

        public override void Up()
        {
            Alter.Table("PurchaseReceipt").InSchema("dbo")

           .AddColumn("IsPReturnCreated").AsBoolean().WithDefaultValue(false);


        }

    }

}

