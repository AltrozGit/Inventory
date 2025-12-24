using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20231010113730)]
    public class DefaultDB_20231010_113730_Indotalent_Quotation : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("Quotation")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
                .WithColumn("Number").AsString(200).NotNullable()
                .WithColumn("Description").AsString(1000).Nullable()
                .WithColumn("ExternalReferenceNumber").AsString(200).Nullable()
              
                .WithColumn("QuotationDate").AsDateTime().NotNullable()
                .WithColumn("ProjectId").AsInt32().NotNullable()
                    .ForeignKey("FK_Quotation_ProjectId", "Project", "Id")
                .WithColumn("SubTotal").AsDouble().NotNullable()
                .WithColumn("Discount").AsDouble().NotNullable()
                .WithColumn("BeforeTax").AsDouble().NotNullable()
                .WithColumn("TaxAmount").AsDouble().NotNullable()
                .WithColumn("Total").AsDouble().NotNullable()
                .WithColumn("OtherCharge").AsDouble().NotNullable().WithDefaultValue(0)
                 .WithColumn("InsertDate").AsDateTime().Nullable()
                 .WithColumn("InsertUserId").AsInt32().Nullable()
                 .WithColumn("UpdateDate").AsDateTime().Nullable()
                 .WithColumn("UpdateUserId").AsInt32().Nullable()
                 .WithColumn("TenantId").AsInt32().NotNullable();

            Create.UniqueConstraint("QuotationUniqueConstraint").OnTable("Quotation").Columns("Number", "TenantId");
            Create.Table("QuotationDetail")
               .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
               .WithColumn("QuotationId").AsInt32().NotNullable()
                   .ForeignKey("FK_QuotationDetail_QuotationId", "Quotation", "Id")
               .WithColumn("ProductId").AsInt32().NotNullable()
                   .ForeignKey("FK_QuotationDetail_ProductId", "Product", "Id")
               .WithColumn("Price").AsDouble().NotNullable()
               .WithColumn("Qty").AsDouble().NotNullable()
               .WithColumn("SubTotal").AsDouble().NotNullable()
               .WithColumn("Discount").AsDouble().NotNullable()
               .WithColumn("BeforeTax").AsDouble().NotNullable()
               .WithColumn("TaxPercentage").AsDouble().NotNullable()
               .WithColumn("TaxAmount").AsDouble().NotNullable()
               .WithColumn("Total").AsDouble().NotNullable()
               .WithColumn("InsertDate").AsDateTime().Nullable()
               .WithColumn("InsertUserId").AsInt32().Nullable()
               .WithColumn("UpdateDate").AsDateTime().Nullable()
               .WithColumn("UpdateUserId").AsInt32().Nullable()
               .WithColumn("TenantId").AsInt32().NotNullable();

        }
    }
}