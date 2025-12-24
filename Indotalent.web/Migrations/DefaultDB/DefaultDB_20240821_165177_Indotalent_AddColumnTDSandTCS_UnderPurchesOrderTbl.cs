using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{

    [Migration(20240821165177)]
    public class DefaultDB_20240821_165177_Indotalent_AddColumnTDSandTCS_UnderPurchesOrderTbl : AutoReversingMigration
    {

        public override void Up()
        {
            Alter.Table("PurchaseOrder").InSchema("dbo")
            .AddColumn("TDS ").AsDouble().Nullable()
             .AddColumn("TCS").AsDouble().Nullable();            
        }
    }
}
