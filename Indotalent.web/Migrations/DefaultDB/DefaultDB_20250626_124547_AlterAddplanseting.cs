using FluentMigrator;
using Serenity.Extensions;
using System;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20250626124547)]
    public class DefaultDB_20250626_124547_AlterAddplanseting : AutoReversingMigration
    {
        public override void Up()
        {
            Alter.Table("PlanSetting")
                .AddColumn("ApplicationId").AsInt32().Nullable()
                    .ForeignKey("FK_PlanSetting_ApplicationId", "Applications", "Id");
            Alter.Table("AddBalance")
                .AddColumn("ApplicationId").AsInt32().Nullable()
                    .ForeignKey("FK_AddBalance_ApplicationId", "Applications", "Id")
              .AddColumn("ApplicationTenantId").AsInt32().Nullable();


            Alter.Table("Subscription")
              .AddColumn("ApplicationCode").AsString(50).Nullable()
              .AddColumn("ApplicationTenantId").AsInt32().Nullable();


        }
    }
}
