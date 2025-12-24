using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20250618140348)]
    public class DefaultDB_20250618_140348_AddWhatsappTable : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("WhatsApp")
               .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()


               .WithColumn("TemplateName").AsString(100).NotNullable()
               .WithColumn("BroadcastName").AsString(100).NotNullable()
               .WithColumn("Url").AsString(100).Nullable()


               .WithColumn("IsActive").AsBoolean().NotNullable()
                .WithColumn("TenantId").AsInt32().NotNullable()
               .WithColumn("InsertDate").AsDateTime().Nullable()
               .WithColumn("InsertUserId").AsInt32().Nullable()
               .WithColumn("UpdateDate").AsDateTime().Nullable()
               .WithColumn("UpdateUserId").AsInt32().Nullable();

            Alter.Table("DueDateReminder")
                 .AddColumn("WhatsAppId").AsInt32().Nullable()
                  .ForeignKey("FK_DueDateReminder_WhatsAppId", "WhatsApp", "Id")
                .AddColumn("PlanId").AsInt32().Nullable().ForeignKey("FK_DueDateReminder_PlanSetting", "PlanSetting", "Id");


        }
    }
}