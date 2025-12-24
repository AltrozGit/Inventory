using DocumentFormat.OpenXml.Drawing.Charts;
using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20252603164950)]
    public class DefaultDB_20252603_164950_RemovePurchaseOrderColumnNotNullConstraintBillTBL : AutoReversingMigration
    {
        public override void Up()
        {
            Alter.Table("Bill")
                .AlterColumn("PurchaseOrderId")
                .AsInt32()  
                .Nullable(); 

        }

    }
}