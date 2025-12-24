
using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20250320141000)]
    public class DefaultDB_20250320_141000_AddColumm_UnderPurchaseReceiptTblAndBillTbl : AutoReversingMigration
    {
        public override void Up()
        {

            Alter.Table("Bill").InSchema("dbo")
                .AddColumn("PurchaseReceiptId").AsInt32().Nullable()
                   .ForeignKey("FK_Bill_PurchaseReceiptId", "PurchaseReceipt", "Id");


            Alter.Table("PurchaseReceipt").InSchema("dbo")
               .AddColumn("InvoiceNumber").AsString().Nullable()
               .AddColumn("InvoiceDate").AsDateTime().Nullable();



        }
    }
}
