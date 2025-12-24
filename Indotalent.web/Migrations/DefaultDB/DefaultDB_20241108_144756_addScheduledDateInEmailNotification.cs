using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20241108144756)]
    public class DefaultDB_20241108_144756_addScheduledDateInEmailNotification : AutoReversingMigration
    {
        public override void Up()
        {


          
            Alter.Table("EmailNotification").InSchema("dbo")
          .AddColumn("ScheduledDate").AsDateTime().Nullable();






        }
    }
}
