using Serenity.Services;

namespace Indotalent.Reminder.Endpoints
{
    public class CheckSubscriptionRequest : ServiceRequest
    {
        public int? TenantId { get; set; }
    }
}