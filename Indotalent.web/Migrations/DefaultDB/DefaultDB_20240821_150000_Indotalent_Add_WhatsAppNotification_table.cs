using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20240821150000)]
    public class DefaultDB_20240821_150000_Indotalent_Add_WhatsAppNotification_table : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("WhatsappNotification")
               .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
               .WithColumn("CustomerName").AsString(255).NotNullable()
               .WithColumn("WhatsappNumber").AsString(255).NotNullable()
               .WithColumn("TemplateName").AsString(255).NotNullable()
               .WithColumn("BroadCastName").AsString(255).NotNullable()
               .WithColumn("MessageCaption").AsString(255).NotNullable()
               .WithColumn("Message").AsString(int.MaxValue).NotNullable() 
               .WithColumn("Attachment").AsString(1000).Nullable() 
               .WithColumn("IsSent").AsBoolean().NotNullable().WithDefaultValue(false) 
               .WithColumn("SentOn").AsDateTime().Nullable() 
               .WithColumn("RetryCount").AsInt32().Nullable().WithDefaultValue(0)
               .WithColumn("InsertUserId").AsInt32().NotNullable() 
               .WithColumn("InsertDate").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime) 
               .WithColumn("TenantId").AsInt32().NotNullable();
        }
    }
}
