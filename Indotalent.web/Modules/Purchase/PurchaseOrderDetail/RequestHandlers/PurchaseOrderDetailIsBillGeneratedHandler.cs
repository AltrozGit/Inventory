using Dapper;
using Indotalent.Administration;
using Indotalent.Purchase;
using Serenity;
using Serenity.Abstractions;
using Serenity.Data;
using Serenity.Services;
using System.Data;

namespace Indotalent.Purchase
{
    public class PurchaseOrderDetailIsBillGeneratedRequest : ServiceRequest
    {
        public int PurchaseOrderId { get; set; }
    }

    public class PurchaseOrderDetailIsBillGeneratedResponse : ServiceResponse
    {
        public bool IsBillGenerated { get; set; }
    }

    public interface IPurchaseOrderDetailIsBillGeneratedHandler : IRequestHandler
    {
        PurchaseOrderDetailIsBillGeneratedResponse CheckBillGenerated(IDbConnection connection, PurchaseOrderDetailIsBillGeneratedRequest request);
    }

    public class PurchaseOrderDetailIsBillGeneratedHandler : IPurchaseOrderDetailIsBillGeneratedHandler
    {
        protected IUserAccessor UserAccessor { get; }
        private IUserRetrieveService UserRetriever { get; }

        public PurchaseOrderDetailIsBillGeneratedHandler(IUserAccessor userAccessor, IUserRetrieveService userRetriever)
        {
            UserAccessor = userAccessor;
            UserRetriever = userRetriever;
        }


        public PurchaseOrderDetailIsBillGeneratedResponse CheckBillGenerated(IDbConnection connection, PurchaseOrderDetailIsBillGeneratedRequest request)
        {
            var result = new PurchaseOrderDetailIsBillGeneratedResponse();

            
            if (request.PurchaseOrderId <= 0)
            {
                result.IsBillGenerated = false; 
                return result;
            }

            
            var isBillGenerated = connection.ExecuteScalar<bool>(
                @"SELECT IsBillGenerated
                  FROM PurchaseOrder
                  WHERE Id = @PurchaseOrderId;",
                new { PurchaseOrderId = request.PurchaseOrderId });

            result.IsBillGenerated = isBillGenerated;
            return result;
        }
    }
}
