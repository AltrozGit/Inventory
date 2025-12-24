using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20241107110356)]
    public class DefaultDB_20241107_110356_addIsActiveInEmailNotificationandbulkemailSender : AutoReversingMigration
    {
        public override void Up()
        {


            Alter.Table("EmailNotification").InSchema("dbo")
           .AddColumn("IsActive").AsBoolean().WithDefaultValue(true);
            Alter.Table("BulkEmailSender").InSchema("dbo")
          .AddColumn("IsActive").AsBoolean().WithDefaultValue(true);






        }
    }
}
