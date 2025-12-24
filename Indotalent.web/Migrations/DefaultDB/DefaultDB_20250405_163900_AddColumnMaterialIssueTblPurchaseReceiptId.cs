
using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20250405163900)]
    public class DefaultDB_20250405_163900_AddColumnMaterialIssueTblPurchaseReceiptId : AutoReversingMigration
    {
        public override void Up()
        {
            Alter.Table("MaterialIssue").InSchema("dbo")
           .AddColumn("PurchaseReceiptId").AsInt32().Nullable();
            //.AddColumn("PurchaseReceiptNumber ").AsString(200).Nullable();



            Alter.Table("MaterialIssueDetail").InSchema("dbo")
           .AddColumn("PurchaseReceiptId").AsInt32().Nullable();
           //.AddColumn("PurchaseReceiptNumber ").AsString(200).Nullable();

           

        }


    }
}