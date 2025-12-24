using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Indotalent.Sales.SalesDeliveryRow>;
using MyRow = Indotalent.Sales.SalesDeliveryRow;

namespace Indotalent.Sales
{
    public interface ISalesDeliveryRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class SalesDeliveryRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, ISalesDeliveryRetrieveHandler
    {
        public SalesDeliveryRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}