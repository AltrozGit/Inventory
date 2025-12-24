using Dapper;
using Indotalent.Administration;

using Serenity;
using Serenity.Abstractions;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;

namespace Indotalent.Sales
{
    public class SalesOrderDetailIsInvoiceGeneratedRequest : ServiceRequest
    {
        public int SalesOrderId { get; set; }
    }

    public class SalesOrderDetailIsInvoiceGeneratedResponse : ServiceResponse
    {
        public bool IsInvoiceGenerated { get; set; }
    }

    public interface ISalesOrderDetailIsInvoiceGeneratedHandler : IRequestHandler
    {
        SalesOrderDetailIsInvoiceGeneratedResponse CheckInvoiceGenerated(IDbConnection connection, SalesOrderDetailIsInvoiceGeneratedRequest request);
    }

    public class SalesOrderDetailIsInvoiceGeneratedHandler : ISalesOrderDetailIsInvoiceGeneratedHandler
    {
        protected IUserAccessor UserAccessor { get; }
        private IUserRetrieveService UserRetriever { get; }

        public SalesOrderDetailIsInvoiceGeneratedHandler(IUserAccessor userAccessor, IUserRetrieveService userRetriever)
        {
            UserAccessor = userAccessor;
            UserRetriever = userRetriever;
        }

        public SalesOrderDetailIsInvoiceGeneratedResponse CheckInvoiceGenerated(IDbConnection connection, SalesOrderDetailIsInvoiceGeneratedRequest request)
        {
            var result = new SalesOrderDetailIsInvoiceGeneratedResponse();

            if (request.SalesOrderId <= 0)
            {
                result.IsInvoiceGenerated = false;
                return result;
            }

            var isInvoiceGenerated = connection.ExecuteScalar<bool>(
                @"SELECT IsInvoiceGenerated
                  FROM SalesOrder
                  WHERE Id = @SalesOrderId;",
                new { SalesOrderId = request.SalesOrderId });

            result.IsInvoiceGenerated = isInvoiceGenerated;
            return result;
        }

    }
}
