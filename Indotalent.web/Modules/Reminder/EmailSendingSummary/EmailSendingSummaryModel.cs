using System.Collections.Generic;

namespace Indotalent.Reminder
{
    public class EmailSendingSummaryModel
    {
        public int EmailsSentToday { get; set; }
        public int EmailsSentCurrentMonth { get; set; }
        public int EmailsSentCurrentSubscription { get; set; }
        public int FailedEmailsToday { get; set; }
        public List<PlanSettingRow> ActivePlans { get; set; }
        public List<SubscriptionRow> Subscriptions { get; set; }
        public int TotalEmailsSent { get;  set; }
        public int EmailsSentBeforeSubscription { get;  set; }
        public int EmailsSentAfterSubscription { get;  set; }
    }
}