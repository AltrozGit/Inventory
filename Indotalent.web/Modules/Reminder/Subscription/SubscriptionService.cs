using Indotalent.Reminder;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;

namespace Indotalent.Web.Modules.Reminder.Subscription
{
    public class SubscriptionService
    {
        private readonly ISubscriptionAuditSaveHandler _subscriptionAuditSaveHandler;
        private readonly IAddBalanceSaveHandler _addBalanceSaveHandler;

        public SubscriptionService(ISubscriptionAuditSaveHandler subscriptionAuditSaveHandler, IAddBalanceSaveHandler addBalanceSaveHandler)
        {
            _subscriptionAuditSaveHandler = subscriptionAuditSaveHandler ?? throw new ArgumentNullException(nameof(subscriptionAuditSaveHandler));
            _addBalanceSaveHandler = addBalanceSaveHandler ?? throw new ArgumentNullException(nameof(addBalanceSaveHandler));
        }

        private PlanSettingRow GetPlanDetails(IUnitOfWork uow, int planId)
        {
            var plan = uow.Connection.TryFirst<PlanSettingRow>(q => q
                .Select(PlanSettingRow.Fields.Id, PlanSettingRow.Fields.PlanName, PlanSettingRow.Fields.Cost, PlanSettingRow.Fields.Units, PlanSettingRow.Fields.Frequency,
                PlanSettingRow.Fields.Type, PlanSettingRow.Fields.ProductId,PlanSettingRow.Fields.ProductName)
                .Where(PlanSettingRow.Fields.Id == planId));

            if (plan == null)
                throw new Exception("Plan not found.");

            return plan;
        }

        public SubscriptionAuditRow InsertSubscriptionWithAudit(SubscriptionRow subscription, IUnitOfWork uow)
        {
            ValidateSubscription(subscription);
            var plan = GetPlanDetails(uow, (int)subscription.PlanId);
            return new SubscriptionAuditRow
            {
                SubscriptionId = subscription.Id,
                TenantId = subscription.ApplicationTenantId,
                PlanId = subscription.PlanId,
                PlanName = subscription.PlanName,
                StartDate = subscription.StartDate,
                EndDate = subscription.EndDate,
                ActiveEndDate = subscription.ActiveEndDate,
                TotalUnits = subscription.TotalUnits,
                CurrentBalanceUnits = subscription.CurrentBalanceUnits,
                IsActive = subscription.IsActive,
                IsArchive = subscription.IsArchive,
                OperationType = "INSERT", // Indicating this is an insert
                AuditTimestamp = DateTime.Now
            };
        }

        public SubscriptionAuditRow UpdateSubscriptionWithAudit(SubscriptionRow subscription, IUnitOfWork uow)
        {
            ValidateSubscription(subscription);
            var plan = GetPlanDetails(uow, (int)subscription.PlanId);
            return new SubscriptionAuditRow
            {
                SubscriptionId = subscription.Id,
                TenantId = subscription.ApplicationTenantId,
                PlanId = subscription.PlanId,
                PlanName = plan.PlanName,
                StartDate = subscription.StartDate,
                EndDate = subscription.EndDate,
                ActiveEndDate = subscription.ActiveEndDate,
                TotalUnits = subscription.TotalUnits,
                CurrentBalanceUnits = subscription.CurrentBalanceUnits,
                IsActive = subscription.IsActive,
                IsArchive = subscription.IsArchive,
                OperationType = "UPDATE", // Indicating this is an update
                AuditTimestamp = DateTime.Now
            };
        }

        public void SaveSubscriptionAudit(IUnitOfWork uow, SubscriptionAuditRow subscriptionAudit)
        {
            if (subscriptionAudit == null)
                throw new ArgumentNullException(nameof(subscriptionAudit), "Subscription audit data is required.");

            var saveRequest = new SaveRequest<SubscriptionAuditRow> { Entity = subscriptionAudit };
            _subscriptionAuditSaveHandler.Create(uow, saveRequest);
        }

        private void ValidateSubscription(SubscriptionRow subscription)
        {
            if (subscription == null)
                throw new ArgumentNullException(nameof(subscription), "The subscription object is required.");
            if (subscription.Id == null)
                throw new ArgumentException("Subscription ID is required.", nameof(subscription.Id));
            if (subscription.PlanId == null)
                throw new ArgumentException("PlanName is required.", nameof(subscription.PlanId));
            if (subscription.StartDate == null)
                throw new ArgumentException("StartDate is required.", nameof(subscription.StartDate));
            if (subscription.EndDate == null)
                throw new ArgumentException("EndDate is required.", nameof(subscription.EndDate));
        }
    }
}
