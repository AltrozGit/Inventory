using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20231014132030)]
    public class DefaultDB_20231014_132030_Indotalent_AlterMultitenant : AutoReversingMigration
    {
        public override void Up()
        {
            Alter.Table("Tenant").InSchema("dbo")
                 .AddColumn("QuotationNumberPrefix").AsString(5).Nullable().WithDefaultValue("QUOT")
                 .AddColumn("QuotationNumberUseDate").AsBoolean().Nullable().WithDefaultValue(true)

                 .AddColumn("QuotationNumberLength").AsInt16().NotNullable().WithDefaultValue(16);

        }
    }
}