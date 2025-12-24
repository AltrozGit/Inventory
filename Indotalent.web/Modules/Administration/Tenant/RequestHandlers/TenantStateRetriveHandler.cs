using Indotalent.Administration;
using Serenity;
using Serenity.Abstractions;
using Serenity.Data;
using Serenity.Services;
using System.Data;

namespace Indotalent.Web.Modules.Administration.Tenant.RequestHandlers
{
    public class TenantStateRetriveRequest : ServiceRequest
    {
    }

    public class TenantStateRetriveResponse : ServiceResponse
    {
        public string StateId { get; set; }
    }
    public interface ITenantStateRetriveHandler : IRequestHandler
    {
        TenantStateRetriveResponse GetState(IDbConnection connection, TenantStateRetriveRequest request);
    }
    public class TenantStateRetriveHandler : ITenantStateRetriveHandler
    {
        protected IUserAccessor UserAccessor { get; }
        private IUserRetrieveService UserRetriever { get; }
        public TenantStateRetriveHandler(IUserAccessor userAccessor, IUserRetrieveService userRetriever)
        {
            UserAccessor = userAccessor;
            UserRetriever = userRetriever;
        }
        public TenantStateRetriveResponse GetState(IDbConnection connection, TenantStateRetriveRequest request)
        {
            var user = UserAccessor.User?.GetUserDefinition(UserRetriever) as UserDefinition;
            var tenant = connection.First<TenantRow>(x => x.SelectTableFields().Where(TenantRow.Fields.TenantId == user.TenantId));
            var result = new TenantStateRetriveResponse();
            result.StateId = tenant.StateName;
            return result;
        }
    }
}
