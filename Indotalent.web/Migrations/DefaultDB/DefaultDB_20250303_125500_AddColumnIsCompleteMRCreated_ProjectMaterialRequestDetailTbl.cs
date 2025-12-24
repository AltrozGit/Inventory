using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20250303125500)]
    public class DefaultDB_20250303_125500_AddColumnIsCompleteMRCreated_ProjectMaterialRequestDetailTbl : AutoReversingMigration
    {
        public override void Up()
        {
			Alter.Table("ProjectMaterialRequestDetail").InSchema("dbo")
           .AddColumn("IsCompleteMRCreated").AsBoolean().WithDefaultValue(false);


        }
    }
}