using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20250307095500)]
    public class DefaultDB_20250307_095500_AddColumnMaterialReturnPrefixAndLength_TenantTbl : AutoReversingMigration
    {
        public override void Up()
        {
            Alter.Table("Tenant").InSchema("dbo")
                .AddColumn("MaterialReturnNumberPrefix").AsString(5).Nullable().WithDefaultValue("MTRN")
                .AddColumn("MaterialReturnNumberUseDate").AsBoolean().Nullable().WithDefaultValue(true)
                .AddColumn("MaterialReturnNumberLength").AsInt16().NotNullable().WithDefaultValue(16);

        }
    }
}