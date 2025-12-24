using Serenity.Services;

namespace Indotalent.Web.Modules.Reminder.BulkEmailFileUpload
{
    public class StopEmailNotificationResponse : ServiceResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
