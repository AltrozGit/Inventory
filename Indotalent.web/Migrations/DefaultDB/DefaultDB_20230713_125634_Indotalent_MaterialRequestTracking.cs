using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20230713125634)]
    public class DefaultDB_20230713_125634_Indotalent_MaterialRequestTracking : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("MaterialRequestTracking")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
                 .WithColumn("MaterialRequestId").AsInt32().NotNullable()
                   .ForeignKey("FK_MaterialRequestTracking_MaterialRequestId", "MaterialRequest", "Id")

                .WithColumn("Comment").AsString(int.MaxValue).NotNullable()
                .WithColumn("InsertDate").AsDateTime().Nullable()

                .WithColumn("InsertUserId").AsInt32().Nullable()

                .WithColumn("TenantId").AsInt32().NotNullable();
        }
    }
}