using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20250711162748)]
    public class DefaultDB_20250711_162748_AddColumnInternalCodeAllDetailTable : AutoReversingMigration
    {
        public override void Up()
        {
            Alter.Table("MaterialIssueDetail").InSchema("dbo")
             .AddColumn("InternalCode").AsString(100).Nullable();

            Alter.Table("SalesOrderDetail").InSchema("dbo")
             .AddColumn("InternalCode").AsString(100).Nullable();

            Alter.Table("SalesDeliveryDetail").InSchema("dbo")
             .AddColumn("InternalCode").AsString(100).Nullable();

            Alter.Table("SalesReturnDetail").InSchema("dbo")
             .AddColumn("InternalCode").AsString(100).Nullable();

            Alter.Table("BillDetail").InSchema("dbo")
             .AddColumn("InternalCode").AsString(100).Nullable();

            Alter.Table("PurchaseOrderDetail").InSchema("dbo")
             .AddColumn("InternalCode").AsString(100).Nullable();

            Alter.Table("PurchaseReceiptDetail").InSchema("dbo")
             .AddColumn("InternalCode").AsString(100).Nullable();

            Alter.Table("PurchaseReturnDetail").InSchema("dbo")
             .AddColumn("InternalCode").AsString(100).Nullable();

            Alter.Table("PositiveAdjustmentDetail").InSchema("dbo")
             .AddColumn("InternalCode").AsString(100).Nullable();

            Alter.Table("NegativeAdjustmentDetail").InSchema("dbo")
             .AddColumn("InternalCode").AsString(100).Nullable();

            Alter.Table("TransferOrderDetail").InSchema("dbo")
             .AddColumn("InternalCode").AsString(100).Nullable();

            

        }
    }
}