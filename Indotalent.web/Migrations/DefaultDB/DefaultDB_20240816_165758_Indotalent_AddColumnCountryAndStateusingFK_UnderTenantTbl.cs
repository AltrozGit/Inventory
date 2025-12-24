using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20240816165758)]
    public class DefaultDB_20240816_165758_Indotalent_AddColumnCountryAndStateusingFK_UnderTenantTbl : AutoReversingMigration
    {
        public override void Up()
        {

            Alter.Table("Tenant").InSchema("dbo")
             .AddColumn("CountryId").AsInt32().Nullable()
                .ForeignKey("FK_Tenant_CountryId", "Country", "Id");

            Alter.Table("Tenant").InSchema("dbo")
            .AddColumn("StateId").AsInt32().Nullable()
               .ForeignKey("FK_Tenant_StateId", "State", "Id");

        }
    }
}