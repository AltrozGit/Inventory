using Dapper;
using Indotalent.Administration;
using Indotalent.Purchase;
using Serenity;
using Serenity.Abstractions;
using Serenity.Data;
using Serenity.Services;
using System.Data;

namespace Indotalent.Invoice
{
    public class InvoiceDetailIsInvoicePaymentGeneratedRequest : ServiceRequest
    {
        public int InvoiceId { get; set; }
    }

    public class InvoiceDetailIsInvoicePaymentGeneratedResponse : ServiceResponse
    {
        public bool IsInvoicePaymentGenerated { get; set; }
    }

    public interface IInvoiceDetailIsInvoicePaymentGeneratedHandler : IRequestHandler
    {
        InvoiceDetailIsInvoicePaymentGeneratedResponse CheckInvoicePaymentGenerated(IDbConnection connection, InvoiceDetailIsInvoicePaymentGeneratedRequest request);
    }

    public class InvoiceDetailIsInvoicePaymentGeneratedHandler : IInvoiceDetailIsInvoicePaymentGeneratedHandler
    {
        protected IUserAccessor UserAccessor { get; }
        private IUserRetrieveService UserRetriever { get; }

        public InvoiceDetailIsInvoicePaymentGeneratedHandler(IUserAccessor userAccessor, IUserRetrieveService userRetriever)
        {
            UserAccessor = userAccessor;
            UserRetriever = userRetriever;
        }


        public InvoiceDetailIsInvoicePaymentGeneratedResponse CheckInvoicePaymentGenerated(IDbConnection connection, InvoiceDetailIsInvoicePaymentGeneratedRequest request)
        {
            var result = new InvoiceDetailIsInvoicePaymentGeneratedResponse();

            
            if (request.InvoiceId <= 0)
            {
                result.IsInvoicePaymentGenerated = false; 
                return result;
            }


            var isInvoicePaymentGenerated = connection.ExecuteScalar<bool>(
            @"SELECT IsInvoicePaymentGenerated
              FROM Invoice
              WHERE Id = @InvoiceId;",
            new { InvoiceId = request.InvoiceId });

            result.IsInvoicePaymentGenerated = isInvoicePaymentGenerated;
            return result;
        }
    }
}
