
using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20250410104900)]
    public class DefaultDB_20250410_104900_AddColumnPODetailTbl_ISBillCreatedAndQtyofBillCreated : AutoReversingMigration
    {
        public override void Up()
        {
            Alter.Table("MaterialRequest").InSchema("dbo")
           .AddColumn("IsIssueCreated").AsBoolean().WithDefaultValue(false);


            Alter.Table("PurchaseReceipt").InSchema("dbo")
           .AddColumn("IsIssueCreated").AsBoolean().WithDefaultValue(false);

            Alter.Table("PurchaseReceiptDetail").InSchema("dbo")
           .AddColumn("QuanityOfIssueCreated").AsInt32().Nullable().WithDefaultValue(0)
           .AddColumn("IsIssueCreated").AsBoolean().WithDefaultValue(false);


            Alter.Table("PurchaseOrder").InSchema("dbo")
           .AddColumn("IsBillCreated").AsBoolean().WithDefaultValue(false);



            Alter.Table("PurchaseOrderDetail").InSchema("dbo")

           .AddColumn("IsBillCreated").AsBoolean().WithDefaultValue(false)
           .AddColumn("QuanityOfBillCreated").AsInt32().Nullable().WithDefaultValue(0);


            Alter.Table("BillDetail").InSchema("dbo")
            .AddColumn("PurchaseOrderId").AsInt32().Nullable().WithDefaultValue(0);
        }


    }
}