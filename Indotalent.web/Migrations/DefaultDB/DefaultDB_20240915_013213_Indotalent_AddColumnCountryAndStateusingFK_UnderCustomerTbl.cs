using FluentMigrator;
using Serenity.Extensions;


namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20240915013213)]
    public class DefaultDB_20240915_013213_Indotalent_AddColumnCountryAndStateusingFK_UnderCustomerTbl : AutoReversingMigration
    {
        public override void Up()
        {

            Alter.Table("Customer").InSchema("dbo")
             .AddColumn("CountryId").AsInt32().Nullable()
                .ForeignKey("FK_Customer_CountryId", "Country", "Id");

            Alter.Table("Customer").InSchema("dbo")
            .AddColumn("StateId").AsInt32().Nullable()
               .ForeignKey("FK_Customer_StateId", "State", "Id");

        }
    }
}
