using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
using FluentMigrator;
using Serenity.Extensions;
using static MVC.Views.Administration;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20250110130000)]
    public class DefaultDB_20250110_130000_Create_Action_Template_ActionNotificationTables : AutoReversingMigration
    {
        public override void Up()
        {
           
            Create.Table("Action")
               .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
               .WithColumn("ActionName ").AsString(200).NotNullable().Unique()

               .WithColumn("Description").AsString(1000).Nullable()
               .WithColumn("InsertDate").AsDateTime().Nullable()

               .WithColumn("InsertUserId").AsInt32().Nullable()
               .WithColumn("UpdateDate").AsDateTime().Nullable()
               .WithColumn("UpdateUserId").AsInt32().Nullable()
			   .WithColumn("IsActive").AsBoolean().Nullable()
			   .WithColumn("TenantId").AsInt32().NotNullable();

			Create.Table("Template")
			  .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
			  .WithColumn("TemplateName ").AsString(200).NotNullable()

			  .WithColumn("Body").AsString(2500).NotNullable()
			  .WithColumn("Parameter").AsString(250).Nullable()
			  .WithColumn("InsertDate").AsDateTime().Nullable()

			  .WithColumn("InsertUserId").AsInt32().Nullable()
			  .WithColumn("UpdateDate").AsDateTime().Nullable()
			  .WithColumn("UpdateUserId").AsInt32().Nullable()
			.WithColumn("IsActive").AsBoolean().Nullable()
			.WithColumn("TenantId").AsInt32().NotNullable();

			//ActionNotification: Id, ActionName, TenantId, EmailRecipient, whatsappRecipient, Isactive, TemplateId

			Create.Table("ActionNotification")
			  .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
			  .WithColumn("ActionId ").AsInt32().NotNullable()
				.ForeignKey("FK_ActionNotification_ActionId", "Action", "Id")
			  .WithColumn("TemplateId ").AsInt32().NotNullable()
				.ForeignKey("FK_ActionNotification_TemplateId", "Template", "Id")

			  .WithColumn("EmailRecipient").AsString(2500).NotNullable()
			  .WithColumn("whatsappRecipient").AsString(250).Nullable()

			  .WithColumn("InsertDate").AsDateTime().Nullable()

			  .WithColumn("InsertUserId").AsInt32().Nullable()
			  .WithColumn("UpdateDate").AsDateTime().Nullable()
			  .WithColumn("UpdateUserId").AsInt32().Nullable()
			.WithColumn("IsActive").AsBoolean().Nullable()
			.WithColumn("TenantId").AsInt32().NotNullable();


		}
	}
}