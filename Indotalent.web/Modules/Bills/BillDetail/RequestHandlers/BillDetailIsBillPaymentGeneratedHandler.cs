using Dapper;
using Indotalent.Administration;
using Serenity;
using Serenity.Abstractions;
using Serenity.Data;
using Serenity.Services;
using System.Data;

namespace Indotalent.Bills
{
    public class BillDetailIsBillPaymentGeneratedRequest : ServiceRequest
    {
        public int BillId { get; set; }
    }

    public class BillDetailIsBillPaymentGeneratedResponse : ServiceResponse
    {
        public bool IsBillPaymentGenerated { get; set; }
    }

    public interface IBillDetailIsBillPaymentGeneratedHandler : IRequestHandler
    {
        BillDetailIsBillPaymentGeneratedResponse CheckBillPaymentGenerated(IDbConnection connection, BillDetailIsBillPaymentGeneratedRequest request);
    }

    public class BillDetailIsBillPaymentGeneratedHandler : IBillDetailIsBillPaymentGeneratedHandler
    {
        protected IUserAccessor UserAccessor { get; }
        private IUserRetrieveService UserRetriever { get; }

        public BillDetailIsBillPaymentGeneratedHandler(IUserAccessor userAccessor, IUserRetrieveService userRetriever)
        {
            UserAccessor = userAccessor;
            UserRetriever = userRetriever;
        }


        public BillDetailIsBillPaymentGeneratedResponse CheckBillPaymentGenerated(IDbConnection connection, BillDetailIsBillPaymentGeneratedRequest request)
        {
            var result = new BillDetailIsBillPaymentGeneratedResponse();

            
            if (request.BillId <= 0)
            {
                result.IsBillPaymentGenerated = false; 
                return result;
            }

            
            var isBillPaymentGenerated = connection.ExecuteScalar<bool>(
                @"SELECT IsBillPaymentGenerated
                  FROM Bill
                  WHERE Id = @BillId;",
                new { BillId = request.BillId });

            result.IsBillPaymentGenerated = isBillPaymentGenerated;
            return result;
        }
    }
}
