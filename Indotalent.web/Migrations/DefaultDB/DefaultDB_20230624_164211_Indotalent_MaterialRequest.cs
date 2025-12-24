using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20230624164211)]
    public class DefaultDB_20230624_164211_Indotalent_MaterialRequest : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("MaterialRequest")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
               .WithColumn("Number").AsString(200).NotNullable()

            
               .WithColumn("Description").AsString(1000).Nullable()
               .WithColumn("RequestDate").AsDateTime().NotNullable()

                .WithColumn("ProjectId").AsInt32().NotNullable()
                   .ForeignKey("FK_MaterialRequest_ProjectId", "Project", "Id")

               .WithColumn("TotalQtyRequest").AsDouble().NotNullable()

              .WithColumn("DeliveryDate").AsDateTime().NotNullable()
                

               .WithColumn("InsertDate").AsDateTime().Nullable()
               .WithColumn("InsertUserId").AsInt32().Nullable()
               .WithColumn("UpdateDate").AsDateTime().Nullable()
               .WithColumn("UpdateUserId").AsInt32().Nullable()
               .WithColumn("TenantId").AsInt32().NotNullable();
            Create.UniqueConstraint("MaterialRequestUniqueConstraint").OnTable("MaterialRequest").Columns("Number", "TenantId");

            Create.Table("MaterialRequestDetail")
               .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
               .WithColumn("MaterialRequestId").AsInt32().NotNullable()
                   .ForeignKey("FK_MaterialRequestDetail_MaterialRequestId", "MaterialRequest", "Id")
               .WithColumn("ProductId").AsInt32().NotNullable()
                   .ForeignKey("FK_MaterialRequestDetaill_ProductId", "Product", "Id")
               .WithColumn("QtyRequest").AsDouble().NotNullable()
               .WithColumn("InsertDate").AsDateTime().Nullable()
               .WithColumn("InsertUserId").AsInt32().Nullable()
               .WithColumn("UpdateDate").AsDateTime().Nullable()
               .WithColumn("UpdateUserId").AsInt32().Nullable()
               .WithColumn("TenantId").AsInt32().NotNullable();


        }
    }
}