using FluentMigrator;
using Serenity.Extensions;
using System;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20250626121047)]
    public class DefaultDB_20250626_121047_AddApplicationss : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("Applications")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("ApplicationCode").AsString(200).NotNullable()
                .WithColumn("InsertDate").AsDateTime().Nullable()
                .WithColumn("InsertUserId").AsInt32().Nullable()
                .WithColumn("UpdateDate").AsDateTime().Nullable()
                .WithColumn("UpdateUserId").AsInt32().Nullable();
            Create.Index("UX_Applications_ApplicationCode")
    .OnTable("Applications")
    .OnColumn("ApplicationCode").Unique();
            // Insert initial data
            Insert.IntoTable("Applications").Row(new
            {
                ApplicationCode = "HRMS",
                InsertDate = DateTime.UtcNow
            });

            Insert.IntoTable("Applications").Row(new
            {
                ApplicationCode = "Inventory",
                InsertDate = DateTime.UtcNow
            });

            Insert.IntoTable("Applications").Row(new
            {
                ApplicationCode = "EBS",
                InsertDate = DateTime.UtcNow
            });


        }
    }
}
