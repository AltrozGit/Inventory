using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20230720173923)]
    public class DefaultDB_20230720_173923_Indotalent_MaterialRequestStatusTable1 : AutoReversingMigration
    {
        public override void Up()
        {
           
            Create.Table("MaterialRequestStatus")
               .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
                  .WithColumn("MaterialRequestId").AsInt32().NotNullable()
                   .ForeignKey("FK_MaterialRequestStatus_MaterialRequestId", "MaterialRequest ", "Id")
                       .WithColumn("StatustId").AsInt32().NotNullable()
                   .ForeignKey("FK_MaterialRequestStatus_StatustId", "MaterialRequestStatusMaster", "Id")
               .WithColumn("Description").AsString(1000).NotNullable()
               .WithColumn("InsertDate").AsDateTime().Nullable()

               .WithColumn("InsertUserId").AsInt32().Nullable()
               .WithColumn("UpdateDate").AsDateTime().Nullable()
               .WithColumn("UpdateUserId").AsInt32().Nullable()
               .WithColumn("TenantId").AsInt32().NotNullable();
        }
    }
}