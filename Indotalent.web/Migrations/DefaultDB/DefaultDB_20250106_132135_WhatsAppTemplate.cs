using FluentMigrator;
using Serenity.Extensions;
using System;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20250106132135)]
    public class DefaultDB_20250106_132135_WhatsAppTemplate : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("WhatsAppTemplate")
                 .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
                 .WithColumn("Name").AsString(100).NotNullable()
                 .WithColumn("PhoneNumber").AsString(100).NotNullable()
                 .WithColumn("TemplateName").AsString(100).NotNullable()
                 .WithColumn("BroadcastName").AsString(100).NotNullable()
                 .WithColumn("Url").AsString(100).Nullable()
                 .WithColumn("IsAttachmentReq").AsBoolean().NotNullable().WithDefaultValue(true)
				 .WithColumn("IsSent").AsBoolean().NotNullable().WithDefaultValue(false)
				 .WithColumn("IsActive").AsBoolean().NotNullable()
                 .WithColumn("TenantId").AsInt32().Nullable().ForeignKey("FK_WhatsAppTemplate_TenantId", "Tenant", "TenantId")
                 .WithColumn("InsertDate").AsDateTime().Nullable()
                 .WithColumn("InsertUserId").AsInt32().Nullable()
                 .WithColumn("UpdateDate").AsDateTime().Nullable()
                 .WithColumn("UpdateUserId").AsInt32().Nullable();
				

		}
    }
}