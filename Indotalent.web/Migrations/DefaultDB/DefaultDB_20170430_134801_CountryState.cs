using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20170430134801)]
    public class DefaultDB_20170430_134801_CountryState : AutoReversingMigration
    {
        public override void Up()
        {

            Create.Table("Country")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
                .WithColumn("Name").AsString().Nullable();

            Create.UniqueConstraint("CountryUniqueConstraint").OnTable("Country").Columns("Name");

            Create.Table("State")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
                .WithColumn("Name").AsString().Nullable()
                .WithColumn("CountryId").AsInt32().NotNullable()
                .ForeignKey("FK_Country_Id", "Country", "Id");
        }
    }
}
