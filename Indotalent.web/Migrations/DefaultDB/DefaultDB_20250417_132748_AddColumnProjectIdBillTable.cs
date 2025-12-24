using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20250417132748)]
    public class DefaultDB_20250417_132748_AddColumnProjectIdBillTable : AutoReversingMigration
    {
        public override void Up()
        {
			Alter.Table("Bill").InSchema("dbo")
	.AddColumn("ProjectId").AsInt32().NotNullable().WithDefaultValue(0).ForeignKey("FK_Bill_ProjectId", "Project", "Id");


		}
    }
}