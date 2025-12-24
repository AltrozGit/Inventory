using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20230615113801)]
    public class DefaultDB_20230615_113801_Indotalent_UserProjects : AutoReversingMigration
    {
        public override void Up()
        {
			this.CreateTableWithId64("UserProjects", "UserProjectsId", s => s
					  .WithColumn("UserId").AsInt32().NotNullable()
						  .ForeignKey("FK_UserProjects_UserId", "Users", "UserId")
					  .WithColumn("ProjectId").AsInt32().NotNullable()
						  .ForeignKey("FK_UserProjects_ProjectId", "Project", "Id"));

			Create.Index("UQ_UserProjects_UserId_ProjectId")
				.OnTable("UserProjects")
				.OnColumn("UserId").Ascending()
				.OnColumn("ProjectId").Ascending()
				.WithOptions().Unique();

			Create.Index("IX_UserProjects_ProjectId_UserId")
				.OnTable("UserProjects")
				.OnColumn("ProjectId").Ascending()
				.OnColumn("UserId").Ascending();
		}
    }
}