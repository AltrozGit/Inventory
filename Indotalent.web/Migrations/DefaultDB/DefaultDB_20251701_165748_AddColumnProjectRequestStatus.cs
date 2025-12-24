using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20251701165748)]
    public class DefaultDB_20251701_165748_AddColumnProjectRequestStatus : AutoReversingMigration
    {
        public override void Up()
        {
			Alter.Table("ProjectMaterialRequest").InSchema("dbo")
	.AddColumn("RequestStatus").AsInt32().NotNullable().WithDefaultValue(1);


		}
    }
}