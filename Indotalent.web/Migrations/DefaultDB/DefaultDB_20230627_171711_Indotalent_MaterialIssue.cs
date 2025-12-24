using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20230627171711)]
    public class DefaultDB_20230627_171711_Indotalent_MaterialIssue : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("MaterialIssue")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
               .WithColumn("Number").AsString(200).NotNullable()

            
               .WithColumn("Description").AsString(1000).Nullable()
               .WithColumn("IssueDate").AsDateTime().NotNullable()

                   
             .WithColumn("MaterialRequestId").AsInt32().NotNullable()
             .ForeignKey("FK_MaterialIssue_MaterialRequestId", "dbo", "MaterialRequest", "Id")

                  .WithColumn("TotalQtyIssue").AsDouble().NotNullable()

                    
               .WithColumn("InsertDate").AsDateTime().Nullable()
               .WithColumn("InsertUserId").AsInt32().Nullable()
               .WithColumn("UpdateDate").AsDateTime().Nullable()
               .WithColumn("UpdateUserId").AsInt32().Nullable()
               .WithColumn("TenantId").AsInt32().NotNullable();
            Create.UniqueConstraint("MaterialIssueUniqueConstraint").OnTable("MaterialIssue").Columns("Number", "TenantId");

            Create.Table("MaterialIssueDetail")
               .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
               .WithColumn("MaterialIssueId").AsInt32().NotNullable()
                   .ForeignKey("FK_MaterialIssueDetail_MaterialIssueId", "MaterialIssue", "Id")
               .WithColumn("ProductId").AsInt32().NotNullable()
                   .ForeignKey("FK_MaterialIssueDetaill_ProductId", "Product", "Id")
               .WithColumn("QtyIssue").AsDouble().NotNullable()
               .WithColumn("InsertDate").AsDateTime().Nullable()
               .WithColumn("InsertUserId").AsInt32().Nullable()
               .WithColumn("UpdateDate").AsDateTime().Nullable()
               .WithColumn("UpdateUserId").AsInt32().Nullable()
               .WithColumn("TenantId").AsInt32().NotNullable();


        }
    }
}