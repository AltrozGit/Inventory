using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20241411140001)]
    public class DefaultDB_20241411_140001_AddingStateCodeAndCountryCodeInStateAndCountry : AutoReversingMigration
    {
        public override void Up()
        {

            Alter.Table("State").InSchema("dbo")
                .AddColumn("StateCode").AsString(200).Nullable();

            Alter.Table("Country").InSchema("dbo")
              .AddColumn("CountryCode").AsString(200).Nullable();



        }
    }
}