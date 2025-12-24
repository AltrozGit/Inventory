using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20240823163523)]
    public class DefaultDB_20240823_163523_alterBulkEmailSender : AutoReversingMigration
    {
        public override void Up()
        {


            Alter.Table("BulkEmailSender").InSchema("dbo")
             .AddColumn("Description").AsString(1000).Nullable();
         
        }
    }
}
