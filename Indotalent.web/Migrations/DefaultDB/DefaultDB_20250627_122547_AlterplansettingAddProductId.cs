using DocumentFormat.OpenXml.Drawing.Charts;
using FluentMigrator;
using Serenity.Extensions;
using System;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20250627122547)]
    public class DefaultDB_20250627_122547_AlterplansettingAddProductId : ForwardOnlyMigration
    {
        public override void Up()
        {

            if (Schema.Table("PlanSetting").Column("Product").Exists())
            {
                Delete.Column("Product").FromTable("PlanSetting");
            }
            Alter.Table("PlanSetting")
                .AddColumn("ProductId").AsInt32().Nullable()
                    .ForeignKey("FK_PlanSetting_ProductId", "Product", "Id");
            Alter.Table("AddBalance")
                   .AddColumn("ProductId").AsInt32().Nullable()
                  .ForeignKey("FK_AddBalance_ProductId", "Product", "Id");



            Alter.Table("Subscription")
              .AddColumn("ProductName").AsString(50).Nullable();
          


        }
    }
}
