using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20250227103401)]
    public class DefaultDB_20250227_103401_CreateMaterialReturnModuleTbl : AutoReversingMigration
    {
        public override void Up()
        {


            Create.Table("MaterialReturn")
               .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
               .WithColumn("Number").AsString(200).NotNullable()
               .WithColumn("Description").AsString(1000).Nullable()
               .WithColumn("ProcurementGroup").AsString(200).Nullable()
               .WithColumn("ReturnDate").AsDateTime().NotNullable()
               .WithColumn("MaterialIssueId").AsInt32().NotNullable()
                   .ForeignKey("FK_MaterialReturn_MaterialIssueId", "MaterialIssue", "Id")
                .WithColumn("ProjectId").AsInt32().NotNullable()
             .ForeignKey("FK_MaterialReturn_ProjectId", "dbo", "Project", "Id")
               .WithColumn("WarehouseId").AsInt32().NotNullable()
                 .ForeignKey("FK_MaterialReturn_WarehouseId", "Warehouse", "Id")
               .WithColumn("LocationId").AsInt32().Nullable()
                  .ForeignKey("FK_MaterialReturn_LocationId", "Location", "Id")
               .WithColumn("TotalQtyReturn").AsDouble().NotNullable()
               .WithColumn("InsertDate").AsDateTime().Nullable()
               .WithColumn("InsertUserId").AsInt32().Nullable()
               .WithColumn("UpdateDate").AsDateTime().Nullable()
               .WithColumn("UpdateUserId").AsInt32().Nullable()
               .WithColumn("TenantId").AsInt32().NotNullable();

            Create.UniqueConstraint("MaterialReturnUniqueConstraint").OnTable("MaterialReturn").Columns("Number", "TenantId");

            Create.Table("MaterialReturnDetail")
               .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
               .WithColumn("MaterialReturnId").AsInt32().NotNullable()
                   .ForeignKey("FK_MaterialReturnDetail_MaterialReturnId", "MaterialReturn", "Id")
               .WithColumn("ProductId").AsInt32().NotNullable()
                   .ForeignKey("FK_MaterialReturnDetaill_ProductId", "Product", "Id")
               .WithColumn("QtyReturn").AsDouble().NotNullable()
               .WithColumn("InsertDate").AsDateTime().Nullable()
               .WithColumn("InsertUserId").AsInt32().Nullable()
               .WithColumn("UpdateDate").AsDateTime().Nullable()
               .WithColumn("UpdateUserId").AsInt32().Nullable()
               .WithColumn("TenantId").AsInt32().NotNullable();

        }
    }
}
