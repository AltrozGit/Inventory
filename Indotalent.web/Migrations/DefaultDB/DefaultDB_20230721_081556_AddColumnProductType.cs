using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20230721081556)]
    public class DefaultDB_20230721_081556_AddColumnProductType : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("HSN")
                .InSchema("dbo")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
                .WithColumn("HSN Code").AsString(255).Nullable()
                .WithColumn("HSN Description").AsString(255).Nullable()
                .WithColumn("HSN Name").AsString(255).Nullable();

            Create.Table("SAC")
                    .InSchema("dbo")
                    .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
                    .WithColumn("SAC Code").AsString(255).Nullable()
                    .WithColumn("SAC Description").AsString(255).Nullable()
                    .WithColumn("SAC Name").AsString(255).Nullable();

            Alter.Table("Product").InSchema("dbo")
             .AddColumn("ProductType").AsInt32().Nullable()
             .AddColumn("HsnId").AsInt32().Nullable().ForeignKey("Product_HSN_Id","HSN","Id")
             .AddColumn("SacId").AsInt32().Nullable().ForeignKey("Product_SAC_Id", "SAC", "Id");


        }
    }
}