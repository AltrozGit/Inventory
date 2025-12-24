using Serenity.Services;
using System;

namespace Indotalent.Reminder.Endpoints
{
    public class CheckSubscriptionResponse : ServiceResponse
    {
        public bool IsActive { get; set; }
        public DateTime? EndDate { get; set; }
        public int CurrentBalanceUnits { get; set; }
        public int TenantId { get; set; }
    }
}