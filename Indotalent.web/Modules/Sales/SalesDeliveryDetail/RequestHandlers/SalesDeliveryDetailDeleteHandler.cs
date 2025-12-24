using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = Indotalent.Sales.SalesDeliveryDetailRow;

namespace Indotalent.Sales
{
    public interface ISalesDeliveryDetailDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class SalesDeliveryDetailDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, ISalesDeliveryDetailDeleteHandler
    {
        public SalesDeliveryDetailDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}