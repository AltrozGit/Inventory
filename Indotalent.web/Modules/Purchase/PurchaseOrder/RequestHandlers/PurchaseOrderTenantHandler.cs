using Indotalent.Administration;
using Serenity;
using Serenity.Abstractions;
using Serenity.Data;
using Serenity.Services;
using System.Data;

namespace Indotalent.Purchase
{
    public class PurchaseOrderTenantRequest : ServiceRequest
    {

    }

    public class PurchaseOrderTenantResponse : ServiceResponse
    {
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string StateId { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

    }
    public interface IPurchaseOrderTenantHandler : IRequestHandler
    {
        PurchaseOrderTenantResponse GetTenant(IDbConnection connection, PurchaseOrderTenantRequest request);
    }
    public class PurchaseOrderTenantHandler : IPurchaseOrderTenantHandler
    {
        protected IUserAccessor UserAccessor { get; }
        private IUserRetrieveService UserRetriever { get; }
        public PurchaseOrderTenantHandler(IUserAccessor userAccessor, IUserRetrieveService userRetriever)
        {
            UserAccessor = userAccessor;
            UserRetriever = userRetriever;
        }
        public PurchaseOrderTenantResponse GetTenant(IDbConnection connection, PurchaseOrderTenantRequest request)
        {
            var user = UserAccessor.User?.GetUserDefinition(UserRetriever) as UserDefinition;
            //var tenant = connection.First<TenantRow>(x => x.SelectTableFields().Where(TenantRow.Fields.TenantId == user.TenantId));
            var tenant = connection.First<TenantRow>(x =>
              x.SelectTableFields()
               .Select(TenantRow.Fields.StateName)
              .Where(TenantRow.Fields.TenantId == user.TenantId));
            var result = new PurchaseOrderTenantResponse();

            result.Name = tenant.TenantName;
            result.Street = tenant.Street;
            result.City = tenant.City;
            result.ZipCode = tenant.ZipCode;
            result.StateId = tenant.StateName;
            result.Phone = tenant.Phone;
            result.Email = tenant.Email;

            return result;
        }
    }
}
