using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20241109500007)]
    public class DefaultDB_20241109_500007_ProjectMaterialRequest : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("ProjectMaterialRequest")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
               .WithColumn("Number").AsString(200).NotNullable()

            
               .WithColumn("Description").AsString(1000).Nullable()
               .WithColumn("RequestDate").AsDateTime().NotNullable()

                .WithColumn("ProjectId").AsInt32().NotNullable()
                   .ForeignKey("FK_ProjectMaterialRequest_ProjectId", "Project", "Id")

               .WithColumn("TotalQtyRequest").AsDouble().NotNullable()

              .WithColumn("DeliveryDate").AsDateTime().NotNullable()
              .WithColumn("Total").AsDouble().Nullable()


               .WithColumn("InsertDate").AsDateTime().Nullable()
               .WithColumn("InsertUserId").AsInt32().Nullable()
               .WithColumn("UpdateDate").AsDateTime().Nullable()
               .WithColumn("UpdateUserId").AsInt32().Nullable()
               .WithColumn("TenantId").AsInt32().NotNullable();
            Create.UniqueConstraint("ProjectMaterialRequestUniqueConstraint").OnTable("ProjectMaterialRequest").Columns("Number", "TenantId");

            Create.Table("ProjectMaterialRequestDetail")
               .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
               .WithColumn("ProjectMaterialRequestId").AsInt32().NotNullable()
                   .ForeignKey("FK_ProjectMaterialRequestDetail_ProjectMaterialRequestId", "ProjectMaterialRequest", "Id")
               .WithColumn("ProductId").AsInt32().NotNullable()
                   .ForeignKey("FK_ProjectMaterialRequestDetaill_ProductId", "Product", "Id")
               .WithColumn("QtyRequest").AsDouble().NotNullable()
                .WithColumn("PurchasePrice").AsDouble().Nullable()
                .WithColumn("SubTotal").AsDouble().Nullable()
               .WithColumn("InsertDate").AsDateTime().Nullable()
               .WithColumn("InsertUserId").AsInt32().Nullable()
               .WithColumn("UpdateDate").AsDateTime().Nullable()
               .WithColumn("UpdateUserId").AsInt32().Nullable()
               .WithColumn("TenantId").AsInt32().NotNullable();


        }
    }
}