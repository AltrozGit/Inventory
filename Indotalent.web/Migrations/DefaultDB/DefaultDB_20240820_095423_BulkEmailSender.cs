using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20240820095423)]
    public class DefaultDB_20240820_095423_BulkEmailSender : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("BulkEmailSender")
             .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
             .WithColumn("Title").AsString().NotNullable()
             .WithColumn("FilePath").AsString().NotNullable()
             
             .WithColumn("InsertDate").AsDateTime().Nullable()
              .WithColumn("InsertUserId").AsInt32().Nullable()
              .WithColumn("UpdateDate").AsDateTime().Nullable()
              .WithColumn("UpdateUserId").AsInt32().Nullable()
             .WithColumn("TenantId").AsInt32().NotNullable();

          
        }
    }
}
