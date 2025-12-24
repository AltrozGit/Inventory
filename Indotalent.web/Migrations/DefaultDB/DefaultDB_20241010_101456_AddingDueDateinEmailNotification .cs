using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20241010101456)]
    public class DefaultDB_20241010_101456_AddingDueDateinEmailNotification : AutoReversingMigration
    {
        public override void Up()
        {


            Alter.Table("EmailNotification").InSchema("dbo")
           .AddColumn("Placeholder").AsString(255).Nullable()
           .AddColumn("Placeholder1").AsString(255).Nullable();
          

              

               
        }
    }
}
