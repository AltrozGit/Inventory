
using Indotalent.Administration;
using Serenity;
using Serenity.Abstractions;
using Serenity.Data;
using Serenity.Services;
using System.Data;

namespace Indotalent.Projects
{
    public class QuotationDetailTenantStateHandlerRequest : ServiceRequest
    {
    }

    public class QuotationDetailTenantStateHandlerResponse : ServiceResponse
    {
        
        public string StateId { get; set; }
    }
    public interface IQuotationDetailTenantStateHandler : IRequestHandler
    {
        QuotationDetailTenantStateHandlerResponse CheckTenantStateId(IDbConnection connection, QuotationDetailTenantStateHandlerRequest request);
    }
    public class QuotationDetailTenantStateHandler : IQuotationDetailTenantStateHandler
    {
        protected IUserAccessor UserAccessor { get; }
        private IUserRetrieveService UserRetriever { get; }
        public QuotationDetailTenantStateHandler(IUserAccessor userAccessor, IUserRetrieveService userRetriever)
        {
            UserAccessor = userAccessor;
            UserRetriever = userRetriever;
        }
        public QuotationDetailTenantStateHandlerResponse CheckTenantStateId(IDbConnection connection, QuotationDetailTenantStateHandlerRequest request)
        {
            var user = UserAccessor.User?.GetUserDefinition(UserRetriever) as UserDefinition;
          
            var tenant = connection.First<TenantRow>(x =>
               x.SelectTableFields()
                .Select(TenantRow.Fields.StateName)
               .Where(TenantRow.Fields.TenantId == user.TenantId));
            var result = new QuotationDetailTenantStateHandlerResponse();
           
            result.StateId = tenant.StateName;
            return result;
        }
    }
}
