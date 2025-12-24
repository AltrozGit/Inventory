using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20250228140700)]
    public class DefaultDB_20250228_140700_AddColumnProjectMaterialRequestId_MaterialRequestTbl : AutoReversingMigration
    {
        public override void Up()
        {
			Alter.Table("MaterialRequest").InSchema("dbo")
	.AddColumn("ProjectMaterialRequestId").AsInt32().Nullable().WithDefaultValue(0);


		}
    }
}