
using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20250401161600)]
    public class DefaultDB_20250401_161600_AddColumnPurchaseOrderTbl_ISPRCreate : AutoReversingMigration
    {
        public override void Up()
        {
            Alter.Table("PurchaseOrder").InSchema("dbo")
           
           .AddColumn("IsPRCreate").AsBoolean().WithDefaultValue(false);


        }
    }
}