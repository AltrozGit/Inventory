using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
	[Migration(20230822122723)]
	public class DefaultDB_20230822_122723_Indotalent_AlterStatusColumn : Migration
	{
		public override void Down()
		{
			throw new System.NotImplementedException();
		}

		public override void Up()
		{


			Alter.Table("MaterialRequestStatus").AlterColumn("Description").AsString(1000).Nullable();
			Alter.Table("MaterialRequestStatusMaster").AlterColumn("MaterialRequestStatusDescription").AsString(1000).Nullable();



		}
	}
}