using Indotalent.Administration;
using Serenity.Data;
using Serenity.Services;
using System.Data;

namespace Indotalent.Web.Modules.Reminder.DueDateReminder.RequestHandlers
{
    public interface ITenantDetailsHandler
    {
        TenantDetailsResponse GetTenantDetails(IDbConnection connection, TenantDetailsRequest request);
    }

    public class TenantDetailsHandler : ITenantDetailsHandler
    {
        private readonly IRequestContext context;

        public TenantDetailsHandler(IRequestContext context)
        {
            this.context = context;
        }

        public TenantDetailsResponse GetTenantDetails(IDbConnection connection, TenantDetailsRequest request)
        {
            var row = new TenantRow();

            var tenant = connection.TryById<TenantRow>(request.TenantId);
            if (tenant == null)
                throw new ValidationError("Tenant not found");

            return new TenantDetailsResponse
            {
                TenantName = tenant.TenantName,
                Phone = tenant.Phone,
                Email = tenant.Email
               
            };
        }
    }

}
