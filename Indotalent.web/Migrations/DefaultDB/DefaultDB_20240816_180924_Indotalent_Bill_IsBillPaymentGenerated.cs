using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20240816180925)]
    public class DefaultDB_20240816_180924_Indotalent_Bill_IsBillPaymentGenerated : AutoReversingMigration
    {
        public override void Up()
        {

            Alter.Table("Bill").InSchema("dbo").
             AddColumn("IsBillPaymentGenerated").AsBoolean().NotNullable().WithDefaultValue(false);


        }
    }
}