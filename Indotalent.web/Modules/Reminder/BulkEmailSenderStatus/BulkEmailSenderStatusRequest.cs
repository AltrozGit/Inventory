using Serenity.Services;

namespace Indotalent.Web.Modules.Reminder.BulkEmailSenderStatus
{
    public class BulkEmailSenderStatusRequest : ListRequest
    {
        public int TenantId { get; set; }
    }

}
