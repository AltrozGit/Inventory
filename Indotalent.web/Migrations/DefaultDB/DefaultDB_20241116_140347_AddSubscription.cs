using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20241116140347)]
    public class DefaultDB_20241116_140347_AddSubscription : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("PlanSetting")
               .WithColumn("Id").AsInt32().PrimaryKey().Identity()

               .WithColumn("PlanName").AsString(200).NotNullable()
               .WithColumn("Product").AsString(100).NotNullable()
               .WithColumn("Cost").AsDecimal().NotNullable()
               .WithColumn("Units").AsInt32().NotNullable()
               .WithColumn("Frequency").AsString(50).NotNullable()
               .WithColumn("IsActive").AsBoolean().WithDefaultValue(true)
               .WithColumn("Type").AsString(50).NotNullable()
                .WithColumn("InsertDate").AsDateTime().Nullable()
               .WithColumn("InsertUserId").AsInt32().Nullable()
               .WithColumn("UpdateDate").AsDateTime().Nullable()
               .WithColumn("UpdateUserId").AsInt32().Nullable();

            Create.Table("AddBalance")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("TenantId").AsInt32().NotNullable().ForeignKey("FK_AddBalance_Tenant", "Tenant", "TenantId")
                .WithColumn("RechargeDate").AsDate().NotNullable()
                .WithColumn("PlanId").AsInt32().NotNullable().ForeignKey("FK_AddBalance_PlanSetting", "PlanSetting", "Id")
                .WithColumn("ValidThrough").AsDate().Nullable()
                    .WithColumn("PaymentAmount").AsDecimal().Nullable()
             .WithColumn("TransactionDetails").AsString(500).Nullable()
                 .WithColumn("InsertDate").AsDateTime().Nullable()
                .WithColumn("InsertUserId").AsInt32().Nullable()
                .WithColumn("UpdateDate").AsDateTime().Nullable()
                .WithColumn("UpdateUserId").AsInt32().Nullable();

            Create.Table("Subscription")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("PlanId").AsInt32().NotNullable().ForeignKey("FK_Subscription_PlanSetting", "PlanSetting", "Id")
                .WithColumn("TenantId").AsInt32().NotNullable().ForeignKey("FK_Subscription_Tenant", "Tenant", "TenantId")
                .WithColumn("StartDate").AsDate().NotNullable()
                .WithColumn("EndDate").AsDate().NotNullable()
                .WithColumn("IsActive").AsBoolean().WithDefaultValue(true)
                   .WithColumn("IsArchive").AsBoolean().WithDefaultValue(false)
                .WithColumn("ActiveEndDate").AsDate().Nullable()
                .WithColumn("TotalUnits").AsInt32().NotNullable()
                .WithColumn("CurrentBalanceUnits").AsInt32().NotNullable()
                 .WithColumn("InsertDate").AsDateTime().Nullable()
                .WithColumn("InsertUserId").AsInt32().Nullable()
                .WithColumn("UpdateDate").AsDateTime().Nullable()
                .WithColumn("UpdateUserId").AsInt32().Nullable();
            Create.Table("TenantUnitTransaction")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("TenantId").AsInt32().NotNullable().ForeignKey("FK_TenantUnitTransaction_Tenant", "Tenant", "TenantId")
                .WithColumn("SubscriptionId").AsInt32().NotNullable().ForeignKey("FK_TenantUnitTransaction_Subscription", "Subscription", "Id")
                .WithColumn("Units").AsInt32().NotNullable()
                .WithColumn("ReferenceId").AsInt32().Nullable()
                .WithColumn("Remark").AsString(500).Nullable()
                     .WithColumn("InsertDate").AsDateTime().Nullable()
                .WithColumn("InsertUserId").AsInt32().Nullable()
                .WithColumn("UpdateDate").AsDateTime().Nullable()
                .WithColumn("UpdateUserId").AsInt32().Nullable();

            Create.Table("SubscriptionAudit")
                 .WithColumn("AuditId").AsInt32().PrimaryKey().Identity()
                 .WithColumn("SubscriptionId").AsInt32().NotNullable().ForeignKey("FK_SubscriptionAudit_Subscription", "Subscription", "Id")
                 .WithColumn("TenantId").AsInt32().NotNullable()
                 .WithColumn("PlanId").AsInt32().NotNullable()
                 .WithColumn("StartDate").AsDate().NotNullable()
                 .WithColumn("EndDate").AsDate().NotNullable()
                 .WithColumn("ActiveEndDate").AsDate().Nullable()
                 .WithColumn("TotalUnits").AsInt32().NotNullable()
                 .WithColumn("CurrentBalanceUnits").AsInt32().NotNullable()
                 .WithColumn("IsActive").AsBoolean().NotNullable()
                 .WithColumn("IsArchive").AsBoolean().NotNullable()
                 .WithColumn("OperationType").AsString(50).NotNullable() // 'INSERT' or 'UPDATE'
                 .WithColumn("AuditTimestamp").AsDateTime().NotNullable().WithDefaultValue(SystemMethods.CurrentDateTime)
                 .WithColumn("InsertDate").AsDateTime().Nullable()
                 .WithColumn("InsertUserId").AsInt32().Nullable()
                 .WithColumn("UpdateDate").AsDateTime().Nullable()
                 .WithColumn("UpdateUserId").AsInt32().Nullable();
        }
    }
}
