using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20241127151623)]
    public class DefaultDB_20241127_151623_AddIsDefaultinSmtpConfiguration : AutoReversingMigration
    {
        public override void Up()
        {


            Alter.Table("SmtpConfiguration").InSchema("dbo")
             .AddColumn("IsDefault").AsBoolean().Nullable();
         
        }
    }
}
