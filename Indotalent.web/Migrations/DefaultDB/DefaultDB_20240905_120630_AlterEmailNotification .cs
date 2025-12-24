using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20240905120630)]
    public class DefaultDB_20240905_120630_AlterEmailNotification : AutoReversingMigration
    {
        public override void Up()
        {


            Alter.Table("EmailNotification").InSchema("dbo")
           .AddColumn("CC").AsString(255).Nullable()
           .AddColumn("RecipientName").AsString(255).Nullable()
           .AddColumn("CompanyName").AsString(255).Nullable();

              

               
        }
    }
}
