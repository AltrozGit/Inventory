using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20240823120530)]
    public class DefaultDB_20240823_120530_EmailNotification : AutoReversingMigration
    {
        public override void Up()
        {
         

            Create.Table("EmailNotification")
               .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
             
               .WithColumn("ToEmail").AsString(255).NotNullable()
              

               .WithColumn("Subject").AsString(255).NotNullable()
               .WithColumn("Body").AsString(int.MaxValue).NotNullable() // Use a large max value for the body
               .WithColumn("Attachment").AsString(1000).Nullable() // Nullable since not all emails will have attachments
               .WithColumn("IsSent").AsBoolean().NotNullable().WithDefaultValue(false) // Default value false
               .WithColumn("SentOn").AsDateTime().Nullable() // Nullable since it may not be sent yet
               .WithColumn("RetryCount").AsInt32().Nullable().WithDefaultValue(0)
           

               .WithColumn("InsertUserId").AsInt32().NotNullable() // Not nullable
               .WithColumn("InsertDate").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime) // Not nullable with default
               .WithColumn("TenantId").AsInt32().NotNullable()
               .WithColumn("BulkEmailSenderId").AsInt32().Nullable()
             .ForeignKey("FK_EmailNotification_BulkEmailSenderId", "dbo", "BulkEmailSender", "Id");
        }
    }
}
