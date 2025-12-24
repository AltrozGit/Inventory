using Indotalent.Administration;
using Serenity;
using Serenity.Abstractions;
using Serenity.Data;
using Serenity.Services;
using System.Data;

namespace Indotalent.Projects
{
    public class QuotationCurrencyRequest : ServiceRequest
    {
    }

    public class QuotationCurrencyResponse : ServiceResponse
    {
        public string Currency { get; set; }
    }
    public interface IQuotationCurrencyHandler : IRequestHandler
    {
        QuotationCurrencyResponse Currency(IDbConnection connection, QuotationCurrencyRequest request);
    }
    public class QuotationCurrencyHandler : IQuotationCurrencyHandler
    {
        protected IUserAccessor UserAccessor { get; }
        private IUserRetrieveService UserRetriever { get; }
        public QuotationCurrencyHandler(IUserAccessor userAccessor, IUserRetrieveService userRetriever)
        {
            UserAccessor = userAccessor;
            UserRetriever = userRetriever;
        }
        public QuotationCurrencyResponse Currency(IDbConnection connection, QuotationCurrencyRequest request)
        {
            var user = UserAccessor.User?.GetUserDefinition(UserRetriever) as UserDefinition;
            var tenant = connection.First<TenantRow>(x => x.SelectTableFields().Where(TenantRow.Fields.TenantId == user.TenantId));
            var result = new QuotationCurrencyResponse();
            result.Currency = tenant.Currency;
            return result;
        }
    }
}
