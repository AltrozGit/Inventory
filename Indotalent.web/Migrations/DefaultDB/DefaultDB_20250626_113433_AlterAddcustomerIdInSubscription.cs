using DocumentFormat.OpenXml.Drawing.Charts;
using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20250626113433)]
    public class DefaultDB_20250626_113433_AlterAddcustomerIdInSubscription : ForwardOnlyMigration
    {
        public override void Up()
        {

            if (Schema.Table("Subscription").Column("TenantId").Exists())
            {
                Delete.ForeignKey("FK_Subscription_Tenant").OnTable("Subscription");
                Delete.Column("TenantId").FromTable("Subscription");
            }
            Alter.Table("Subscription").InSchema("dbo")
             .AddColumn("CustomerId").AsInt32().Nullable()
                    .ForeignKey("FK_Subscription_CustomerId", "Customer", "Id");

        }
  
    }
}
