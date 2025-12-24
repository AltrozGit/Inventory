
using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20250304112700)]
    public class DefaultDB_20250304_112700_AddColumnMaterialRequestId_PurchaseOrderDetailTbl : AutoReversingMigration
    {
        public override void Up()
        {
            Alter.Table("PurchaseOrderDetail").InSchema("dbo")
           .AddColumn("MaterialRequestId").AsInt32().Nullable().WithDefaultValue(0);


        }
    }
}