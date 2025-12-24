using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20241109124856)]
    public class DefaultDB_20241109_124856_addFromAddressInEmailNotification : AutoReversingMigration
    {
        public override void Up()
        {


          
            Alter.Table("EmailNotification").InSchema("dbo")
          .AddColumn("FromAddress").AsString(255).Nullable();






        }
    }
}
