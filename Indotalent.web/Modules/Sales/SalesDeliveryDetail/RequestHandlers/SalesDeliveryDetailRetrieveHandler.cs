using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Indotalent.Sales.SalesDeliveryDetailRow>;
using MyRow = Indotalent.Sales.SalesDeliveryDetailRow;

namespace Indotalent.Sales
{
    public interface ISalesDeliveryDetailRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class SalesDeliveryDetailRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, ISalesDeliveryDetailRetrieveHandler
    {
        public SalesDeliveryDetailRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}