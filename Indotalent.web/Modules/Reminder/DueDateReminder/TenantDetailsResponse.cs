using Serenity.Services;

namespace Indotalent.Web.Modules.Reminder.DueDateReminder
{
    public class TenantDetailsResponse : ServiceResponse
    {
        public string TenantName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
       
       
    }

}
