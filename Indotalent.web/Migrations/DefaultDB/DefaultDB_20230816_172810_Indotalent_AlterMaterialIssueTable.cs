using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20230816172810)]
    public class DefaultDB_20230816_172810_Indotalent_AlterMaterialIssueTable : AutoReversingMigration
    {
        public override void Up()
        {

            Alter.Table("MaterialIssue").InSchema("dbo")
               .AddColumn("ProjectId").AsInt32().Nullable()
             .ForeignKey("FK_MaterialIssue_ProjectId", "dbo", "Project", "Id")
               .AddColumn("WarehouseId").AsInt32().Nullable()
                   .ForeignKey("FK_MaterialIssue_WarehouseId", "Warehouse", "Id");
        }

    }
}