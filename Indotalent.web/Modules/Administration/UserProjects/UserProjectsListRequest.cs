using Serenity.Services;

namespace Indotalent.Administration
{
    public class UserProjectsListRequest : ServiceRequest
    {
        public int? UserID { get; set; }
    }
}