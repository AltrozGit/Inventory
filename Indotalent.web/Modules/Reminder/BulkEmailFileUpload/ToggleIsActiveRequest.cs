using Serenity.Services;

namespace Indotalent.Reminder.Endpoints
{
    public class ToggleIsActiveRequest: ListRequest
    {

        public bool? IsActive { get;  set; }
        public int BulkEmailFileId { get;  set; }
    }
}