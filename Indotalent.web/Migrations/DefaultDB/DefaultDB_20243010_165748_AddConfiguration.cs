using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20243010165748)]
    public class DefaultDB_20243010_165748_AddConfiguration : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("Configuration")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()               
                .WithColumn("Description").AsString(1000).Nullable()
                .WithColumn("Key").AsString(200).NotNullable()
                .WithColumn("Value").AsString(200).NotNullable()
                .WithColumn("InsertDate").AsDateTime().Nullable()
                .WithColumn("InsertUserId").AsInt32().Nullable()
                .WithColumn("UpdateDate").AsDateTime().Nullable()
                .WithColumn("UpdateUserId").AsInt32().Nullable()
                .WithColumn("TenantId").AsInt32().NotNullable();

           
        }
    }
}