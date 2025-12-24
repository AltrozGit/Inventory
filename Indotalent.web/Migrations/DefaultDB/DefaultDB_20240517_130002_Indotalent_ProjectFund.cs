using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20240517130002)]
    public class DefaultDB_20240517_130002_Indotalent_ProjectFund : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("ProjectFund")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
                .WithColumn("ProjectId").AsInt32().NotNullable()
                    .ForeignKey("FK_ProjectFund_ProjectId", "Project", "Id")
                .WithColumn("AddedFund").AsDouble().NotNullable()
                .WithColumn("FundingDate").AsDateTime().NotNullable()
                .WithColumn("Description").AsString(1000).Nullable()
                .WithColumn("InsertDate").AsDateTime().Nullable()
                .WithColumn("InsertUserId").AsInt32().Nullable()
                .WithColumn("UpdateDate").AsDateTime().Nullable()
                .WithColumn("UpdateUserId").AsInt32().Nullable()
                .WithColumn("TenantId").AsInt32().NotNullable();
        }
    }
}