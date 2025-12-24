
using Indotalent.Administration;
using Serenity;
using Serenity.Abstractions;
using Serenity.Data;
using Serenity.Services;
using System.Data;

namespace Indotalent.Sales
{
    public class SalesOrderDetailTenantStateHandlerRequest : ServiceRequest
    {
    }

    public class SalesOrderDetailTenantStateHandlerResponse : ServiceResponse
    {
        
        public string StateId { get; set; }
    }
    public interface ISalesOrderDetailTenantStateHandler : IRequestHandler
    {
        SalesOrderDetailTenantStateHandlerResponse CheckTenantStateId(IDbConnection connection, SalesOrderDetailTenantStateHandlerRequest request);
    }
    public class SalesOrderDetailTenantStateHandler : ISalesOrderDetailTenantStateHandler
    {
        protected IUserAccessor UserAccessor { get; }
        private IUserRetrieveService UserRetriever { get; }
        public SalesOrderDetailTenantStateHandler(IUserAccessor userAccessor, IUserRetrieveService userRetriever)
        {
            UserAccessor = userAccessor;
            UserRetriever = userRetriever;
        }
        public SalesOrderDetailTenantStateHandlerResponse CheckTenantStateId(IDbConnection connection, SalesOrderDetailTenantStateHandlerRequest request)
        {
            var user = UserAccessor.User?.GetUserDefinition(UserRetriever) as UserDefinition;
          
            var tenant = connection.First<TenantRow>(x =>
               x.SelectTableFields()
                .Select(TenantRow.Fields.StateName)
               .Where(TenantRow.Fields.TenantId == user.TenantId));
            var result = new SalesOrderDetailTenantStateHandlerResponse();
           
            result.StateId = tenant.StateName;
            return result;
        }
    }
}
