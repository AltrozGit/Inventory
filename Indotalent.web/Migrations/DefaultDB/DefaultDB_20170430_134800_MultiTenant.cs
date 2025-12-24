using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20170430134800)]
    public class DefaultDB_20170430_134800_MultiTenant : AutoReversingMigration
    {
        public override void Up()
        {

            Create.Table("Tenant")
                .WithColumn("TenantId").AsInt32().PrimaryKey().Identity().NotNullable()
                .WithColumn("TenantName").AsString(200).Unique().NotNullable()
                .WithColumn("Description").AsString(1000).Nullable()
                .WithColumn("Currency").AsString(5).NotNullable()
                .WithColumn("Street").AsString(200).Nullable()
                .WithColumn("City").AsString(200).Nullable()
                .WithColumn("ZipCode").AsString(50).Nullable()
                .WithColumn("Phone").AsString(50).Nullable()
                .WithColumn("Email").AsString(200).Nullable()
                .WithColumn("ProductNumberPrefix").AsString(5).Nullable().WithDefaultValue("ART")
                .WithColumn("ProductNumberUseDate").AsBoolean().Nullable().WithDefaultValue(false)
                .WithColumn("ProductNumberLength").AsInt16().NotNullable().WithDefaultValue(16)
                .WithColumn("CustomerNumberPrefix").AsString(5).Nullable().WithDefaultValue("CST")
                .WithColumn("CustomerNumberUseDate").AsBoolean().Nullable().WithDefaultValue(true)
                .WithColumn("CustomerNumberLength").AsInt16().NotNullable().WithDefaultValue(16)
                .WithColumn("SalesNumberPrefix").AsString(5).Nullable().WithDefaultValue("SO")
                .WithColumn("SalesNumberUseDate").AsBoolean().Nullable().WithDefaultValue(true)
                .WithColumn("SalesNumberLength").AsInt16().NotNullable().WithDefaultValue(16)
                .WithColumn("InvoiceNumberPrefix").AsString(5).Nullable().WithDefaultValue("INV")
                .WithColumn("InvoiceNumberUseDate").AsBoolean().Nullable().WithDefaultValue(true)
                .WithColumn("InvoiceNumberLength").AsInt16().NotNullable().WithDefaultValue(16)
                .WithColumn("InvoicePaymentNumberPrefix").AsString(5).Nullable().WithDefaultValue("IVPY")
                .WithColumn("InvoicePaymentNumberUseDate").AsBoolean().Nullable().WithDefaultValue(true)
                .WithColumn("InvoicePaymentNumberLength").AsInt16().NotNullable().WithDefaultValue(16)
                .WithColumn("VendorNumberPrefix").AsString(5).Nullable().WithDefaultValue("VND")
                .WithColumn("VendorNumberUseDate").AsBoolean().Nullable().WithDefaultValue(true)
                .WithColumn("VendorNumberLength").AsInt16().NotNullable().WithDefaultValue(16)
                .WithColumn("PurchaseNumberPrefix").AsString(5).Nullable().WithDefaultValue("PO")
                .WithColumn("PurchaseNumberUseDate").AsBoolean().Nullable().WithDefaultValue(true)
                .WithColumn("PurchaseNumberLength").AsInt16().NotNullable().WithDefaultValue(16)
                .WithColumn("BillNumberPrefix").AsString(5).Nullable().WithDefaultValue("BLL")
                .WithColumn("BillNumberUseDate").AsBoolean().Nullable().WithDefaultValue(true)
                .WithColumn("BillNumberLength").AsInt16().NotNullable().WithDefaultValue(16)
                .WithColumn("BillPaymentNumberPrefix").AsString(5).Nullable().WithDefaultValue("BLPY")
                .WithColumn("BillPaymentNumberUseDate").AsBoolean().Nullable().WithDefaultValue(true)
                .WithColumn("BillPaymentNumberLength").AsInt16().NotNullable().WithDefaultValue(16)
                .WithColumn("SalesDeliveryNumberPrefix").AsString(5).Nullable().WithDefaultValue("DO")
                .WithColumn("SalesDeliveryNumberUseDate").AsBoolean().Nullable().WithDefaultValue(true)
                .WithColumn("SalesDeliveryNumberLength").AsInt16().NotNullable().WithDefaultValue(16)
                .WithColumn("SalesReturnNumberPrefix").AsString(5).Nullable().WithDefaultValue("DORN")
                .WithColumn("SalesReturnNumberUseDate").AsBoolean().Nullable().WithDefaultValue(true)
                .WithColumn("SalesReturnNumberLength").AsInt16().NotNullable().WithDefaultValue(16)
                .WithColumn("PurchaseReceiptNumberPrefix").AsString(5).Nullable().WithDefaultValue("GR")
                .WithColumn("PurchaseReceiptNumberUseDate").AsBoolean().Nullable().WithDefaultValue(true)
                .WithColumn("PurchaseReceiptNumberLength").AsInt16().NotNullable().WithDefaultValue(16)
                .WithColumn("PurchaseReturnNumberPrefix").AsString(5).Nullable().WithDefaultValue("GRRN")
                .WithColumn("PurchaseReturnNumberUseDate").AsBoolean().Nullable().WithDefaultValue(true)
                .WithColumn("PurchaseReturnNumberLength").AsInt16().NotNullable().WithDefaultValue(16)
                .WithColumn("PositiveAdjustmentNumberPrefix").AsString(5).Nullable().WithDefaultValue("AJPF")
                .WithColumn("PositiveAdjustmentNumberUseDate").AsBoolean().Nullable().WithDefaultValue(true)
                .WithColumn("PositiveAdjustmentNumberLength").AsInt16().NotNullable().WithDefaultValue(16)
                .WithColumn("NegativeAdjustmentNumberPrefix").AsString(5).Nullable().WithDefaultValue("AJNF")
                .WithColumn("NegativeAdjustmentNumberUseDate").AsBoolean().Nullable().WithDefaultValue(true)
                .WithColumn("NegativeAdjustmentNumberLength").AsInt16().NotNullable().WithDefaultValue(16)
                .WithColumn("TransferOrderNumberPrefix").AsString(5).Nullable().WithDefaultValue("TO")
                .WithColumn("TransferOrderNumberUseDate").AsBoolean().Nullable().WithDefaultValue(true)
                .WithColumn("TransferOrderNumberLength").AsInt16().NotNullable().WithDefaultValue(16)
                 .WithColumn("MaterialRequestNumberPrefix").AsString(5).Nullable().WithDefaultValue("MRPF")
                   .WithColumn("MaterialRequestNumberUseDate").AsBoolean().Nullable().WithDefaultValue(true)
                   .WithColumn("MaterialRequestNumberLength").AsInt16().NotNullable().WithDefaultValue(16)
                    .WithColumn("MaterialIssueNumberPrefix").AsString(5).Nullable().WithDefaultValue("MIPF")
                   .WithColumn("MaterialIssueNumberUseDate").AsBoolean().Nullable().WithDefaultValue(true)
                   .WithColumn("MaterialIssueNumberLength").AsInt16().NotNullable().WithDefaultValue(16)
                
                .WithColumn("MaximumUser").AsInt32().NotNullable()
                .WithColumn("InsertDate").AsDateTime().Nullable()
                .WithColumn("InsertUserId").AsInt32().Nullable()
                .WithColumn("UpdateDate").AsDateTime().Nullable()
                .WithColumn("UpdateUserId").AsInt32().Nullable();

            Insert.IntoTable("Tenant")
                .Row(new
                {
                    TenantName = "ADMIN ROOT",
                    Currency = "INR",
                    MaximumUser = 1000
                });

            Alter.Table("Users")
                .AddColumn("IsTenantAdmin").AsBoolean().NotNullable().WithDefaultValue(false)
                .AddColumn("TenantId").AsInt32().NotNullable().WithDefaultValue(1)
                    .ForeignKey("FK_Users_TenantId", "Tenant", "TenantId");

            Alter.Table("Roles")
                .AddColumn("TenantId").AsInt32().NotNullable().WithDefaultValue(1)
                    .ForeignKey("FK_Roles_TenantId", "Tenant", "TenantId");
        }
    }
}
