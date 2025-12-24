using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20230630113219)]
    public class DefaultDB_20230630_113219_Indotalent_StatusTable : AutoReversingMigration
    {
        public override void Up()
        {
           
            Create.Table("MaterialRequestStatusMaster")
               .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
               .WithColumn("MaterialRequestStatusName ").AsString(200).NotNullable()

               .WithColumn("MaterialRequestStatusDescription").AsString(1000).NotNullable()
               .WithColumn("InsertDate").AsDateTime().Nullable()

               .WithColumn("InsertUserId").AsInt32().Nullable()
               .WithColumn("UpdateDate").AsDateTime().Nullable()
               .WithColumn("UpdateUserId").AsInt32().Nullable()
               .WithColumn("TenantId").AsInt32().NotNullable();
        }
    }
}