
using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20250402123900)]
    public class DefaultDB_20250402_123900_AddColumnPurchaseOrderDetailTbl_ISPRCreatedAndQtyofPRCreated : AutoReversingMigration
    {
        public override void Up()
        {
            Alter.Table("PurchaseOrderDetail").InSchema("dbo")
           .AddColumn("QuanityOfPRCreated").AsInt32().Nullable().WithDefaultValue(0)
           .AddColumn("IsPRCreate").AsBoolean().WithDefaultValue(false);

            
            Alter.Table("PurchaseReceiptDetail").InSchema("dbo")
           .AddColumn("PurchaseOrderId").AsInt32().Nullable().WithDefaultValue(0);



        }


    }
}