using Serenity.Services;

namespace Indotalent.Web.Modules.Reminder.DueDateReminder
{
    public class TenantDetailsRequest : ServiceRequest
    {
        public int TenantId { get; set; }
    }

}
