using Microsoft.AspNetCore.Mvc;
using Serenity;
using Serenity.Abstractions;
using Serenity.Data;
using Serenity.Web;
using System;
using System.Linq;
using Indotalent.Reminder; // Assuming BulkEmailSenderStatusRow is here
using System.Collections.Generic;
using MyRow = Indotalent.Reminder.BulkEmailSenderStatusRow;
using Indotalent.Common;
using static MVC.Views.Administration;

namespace Indotalent.Web.Modules.Reminder.EmailSendingSummary
{
    [PageAuthorize]
    [ReadPermission("Notifications:EmailSendingSummary")]
    public class EmailSendingSummaryController : Controller
    {
        protected ISqlConnections SqlConnections { get; }
        protected IUserRetrieveService UserRetrieveService { get; }
        public EmailSendingSummaryController(ISqlConnections sqlConnections, IUserRetrieveService userRetrieveService)
        {
            SqlConnections = sqlConnections;
            UserRetrieveService = userRetrieveService;
        }

        [Route("Notifications/EmailSendingSummary")]
        public ActionResult Index()
        {
            var emailSendingSummaryModel = new EmailSendingSummaryModel();
            var user = (UserDefinition)User.GetUserDefinition(UserRetrieveService);

            DateTime today = DateTime.Today;
            DateTime startOfMonth = new DateTime(today.Year, today.Month, 1);

            DateTime? subscriptionStart = null;
            DateTime? subscriptionEnd = null;

            using (var subscriptionConnection = SqlConnections.NewFor<SubscriptionRow>())
            {
                var subscriptionRow = SubscriptionRow.Fields;

                var activeSubscriptions = subscriptionConnection.List<SubscriptionRow>(q => q
                    .Select(subscriptionRow.PlanId, subscriptionRow.StartDate, subscriptionRow.EndDate, subscriptionRow.ActiveEndDate)
                    .Where(subscriptionRow.IsActive == 1 & subscriptionRow.ApplicationTenantId == user.TenantId)
                    .OrderBy(subscriptionRow.StartDate));

                if (activeSubscriptions.Any())
                {
                    var currentSubscription = activeSubscriptions.First(); // Take earliest
                    subscriptionStart = currentSubscription.StartDate;
                    subscriptionEnd = currentSubscription.ActiveEndDate ?? currentSubscription.EndDate;
                }
            }

            using (var connection = SqlConnections.NewFor<MyRow>())
            {
                var bulkEmailFileUploadRow = BulkEmailFileUploadRow.Fields;
                var bulkEmailSenderStatusRow = MyRow.Fields;

                // Emails Sent Today
                emailSendingSummaryModel.EmailsSentToday = connection.Query<int>(new SqlQuery()
                    .From(bulkEmailSenderStatusRow.As("sender"))
                    .InnerJoin(bulkEmailFileUploadRow.As("[file]"),
                        new Criteria("[file].Id") == new Criteria("sender.BulkEmailSenderId"))
                    .Select("COUNT(*)")
                    .Where(
                        new Criteria("sender.SentOn") >= today &
                        new Criteria("sender.TenantId") == user.TenantId &
                        new Criteria("[file].IsActive") == 1))
                    .FirstOrDefault();

                // Emails Sent This Month
                emailSendingSummaryModel.EmailsSentCurrentMonth = connection.Query<int>(new SqlQuery()
                    .From(bulkEmailSenderStatusRow.As("senderMonth"))
                    .InnerJoin(bulkEmailFileUploadRow.As("[fileMonth]"),
                        new Criteria("[fileMonth].Id") == new Criteria("senderMonth.BulkEmailSenderId"))
                    .Select("COUNT(*)")
                    .Where(
                        new Criteria("senderMonth.SentOn") >= startOfMonth &
                        new Criteria("senderMonth.TenantId") == user.TenantId &
                        new Criteria("[fileMonth].IsActive") == 1))
                    .FirstOrDefault();

                // Emails Sent in Current Subscription
                if (subscriptionStart != null && subscriptionEnd != null)
                {
                    emailSendingSummaryModel.EmailsSentCurrentSubscription = connection.Query<int>(new SqlQuery()
                        .From(bulkEmailSenderStatusRow.As("senderYear"))
                        .InnerJoin(bulkEmailFileUploadRow.As("[fileYear]"),
                            new Criteria("[fileYear].Id") == new Criteria("senderYear.BulkEmailSenderId"))
                        .Select("COUNT(*)")
                        .Where(
                            new Criteria("senderYear.SentOn") >= subscriptionStart.Value &
                            new Criteria("senderYear.SentOn") <= subscriptionEnd.Value &
                            new Criteria("senderYear.TenantId") == user.TenantId &
                            new Criteria("[fileYear].IsActive") == 1))
                        .FirstOrDefault();
                }
                else
                {
                    emailSendingSummaryModel.EmailsSentCurrentSubscription = 0;
                }

                // Total Emails Sent Till Date
                emailSendingSummaryModel.TotalEmailsSent = connection.Query<int>(new SqlQuery()
                    .From(bulkEmailSenderStatusRow.As("senderTotal"))
                    .InnerJoin(bulkEmailFileUploadRow.As("[fileTotal]"),
                        new Criteria("[fileTotal].Id") == new Criteria("senderTotal.BulkEmailSenderId"))
                    .Select("COUNT(*)")
                    .Where(
                        new Criteria("senderTotal.SentOn").IsNotNull() &
                        new Criteria("senderTotal.TenantId") == user.TenantId &
                        new Criteria("[fileTotal].IsActive") == 1))
                    .FirstOrDefault();
            }

            // Get active plans
            using (var connection = SqlConnections.NewFor<SubscriptionRow>())
            {
                var subscriptionRow = SubscriptionRow.Fields;

                var subscribedPlanIds = connection.List<SubscriptionRow>(q => q
                    .Select(subscriptionRow.PlanId)
                    .Where(subscriptionRow.IsActive == 1 & subscriptionRow.ApplicationTenantId == user.TenantId))
                    .Select(x => x.PlanId)
                    .Distinct()
                    .ToList();

                using (var planConnection = SqlConnections.NewFor<PlanSettingRow>())
                {
                    if (subscribedPlanIds.Any())
                    {
                        emailSendingSummaryModel.ActivePlans = planConnection.List<PlanSettingRow>(
                            new Criteria("IsActive") == 1 & new Criteria("Id").In(subscribedPlanIds));
                    }
                    else
                    {
                        emailSendingSummaryModel.ActivePlans = new List<PlanSettingRow>();
                    }
                }

                // Order subscriptions by StartDate
                var subscriptions = connection.List<SubscriptionRow>(q => q
                    .Select(subscriptionRow.PlanName, subscriptionRow.StartDate, subscriptionRow.EndDate,
                            subscriptionRow.ActiveEndDate, subscriptionRow.TotalUnits, subscriptionRow.CurrentBalanceUnits)
                    .Where(subscriptionRow.IsActive == 1 & subscriptionRow.ApplicationTenantId == user.TenantId)
                    .OrderBy(subscriptionRow.StartDate));

               
                if (subscriptions.Any())
                {
                    var primarySubscription = subscriptions.First();
                    primarySubscription.CurrentBalanceUnits = primarySubscription.TotalUnits - emailSendingSummaryModel.EmailsSentCurrentSubscription;


                    if (primarySubscription.CurrentBalanceUnits < 0)
                        primarySubscription.CurrentBalanceUnits = 0;

                    for (int i = 1; i < subscriptions.Count; i++)
                    {
                        subscriptions[i].CurrentBalanceUnits = subscriptions[i].TotalUnits;
                    }
                }

                emailSendingSummaryModel.Subscriptions = subscriptions;

                return View(MVC.Views.EmailSendingSummary.EmailSendingSummaryIndex, emailSendingSummaryModel);
            }
        }

    }
}
    
