
using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20250404163900)]
    public class DefaultDB_20250404_163900_AddColumnBillDetailTbl_ISBillCreatedAndQtyofBillCreated : AutoReversingMigration
    {
        public override void Up()
        {
            Alter.Table("PurchaseReceiptDetail").InSchema("dbo")
           .AddColumn("QuanityOfBillCreated").AsInt32().Nullable().WithDefaultValue(0)
           .AddColumn("IsBillCreate").AsBoolean().WithDefaultValue(false);

            
            Alter.Table("BillDetail").InSchema("dbo")
           .AddColumn("PurchaseReceiptId").AsInt32().Nullable().WithDefaultValue(0);

            Alter.Table("PurchaseReceipt").InSchema("dbo")

           .AddColumn("IsBillCreate").AsBoolean().WithDefaultValue(false);

        }


    }
}