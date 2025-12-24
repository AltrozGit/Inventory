using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20251401165748)]
    public class DefaultDB_20251401_165748_AddColumnRequestStatus : AutoReversingMigration
    {
        public override void Up()
        {
			Alter.Table("MaterialRequest").InSchema("dbo")
	.AddColumn("RequestStatus").AsInt32().NotNullable().WithDefaultValue(1);


		}
    }
}