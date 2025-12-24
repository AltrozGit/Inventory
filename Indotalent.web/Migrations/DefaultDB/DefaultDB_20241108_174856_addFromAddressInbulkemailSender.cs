using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20241108174856)]
    public class DefaultDB_20241108_174856_addFromAddressInbulkemailSender : AutoReversingMigration
    {
        public override void Up()
        {


          
            Alter.Table("BulkEmailSender").InSchema("dbo")
          .AddColumn("FromAddress").AsString(255).Nullable();






        }
    }
}
