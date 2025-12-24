using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20241127171623)]
    public class DefaultDB_20241127_171623_AddIsSmtpActiveinSmtpConfiguration : AutoReversingMigration
    {
        public override void Up()
        {


            Alter.Table("SmtpConfiguration").InSchema("dbo")
             .AddColumn("IsSmtpActive").AsBoolean().Nullable().WithDefaultValue(true);
         
        }
    }
}
