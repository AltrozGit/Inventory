using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20241112112646)]
    public class DefaultDB_20241112_112646_addIsStoopedInbulkemailSender : AutoReversingMigration
    {
        public override void Up()
        {


           
            Alter.Table("BulkEmailSender").InSchema("dbo")
          .AddColumn("IsStopped").AsBoolean().WithDefaultValue(false);






        }
    }
}
