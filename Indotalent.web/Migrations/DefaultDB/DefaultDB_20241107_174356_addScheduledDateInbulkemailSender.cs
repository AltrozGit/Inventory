using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20241107174356)]
    public class DefaultDB_20241107_174356_addScheduledDateInbulkemailSender : AutoReversingMigration
    {
        public override void Up()
        {


          
            Alter.Table("BulkEmailSender").InSchema("dbo")
          .AddColumn("ScheduledDate").AsDateTime().Nullable();






        }
    }
}
