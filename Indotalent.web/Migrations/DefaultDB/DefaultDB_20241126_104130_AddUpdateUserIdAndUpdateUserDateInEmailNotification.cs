using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20241126104130)]
    public class DefaultDB_20241126_104130_AddUpdateUserIdAndUpdateUserDateInEmailNotification: AutoReversingMigration
    {
        public override void Up()
        {


            Alter.Table("EmailNotification").InSchema("dbo")
            .AddColumn("UpdateDate").AsDateTime().Nullable()
               .AddColumn("UpdateUserId").AsInt32().Nullable();





        }
    }
}
