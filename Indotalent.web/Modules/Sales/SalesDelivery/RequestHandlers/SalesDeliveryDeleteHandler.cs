using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = Indotalent.Sales.SalesDeliveryRow;

namespace Indotalent.Sales
{
    public interface ISalesDeliveryDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class SalesDeliveryDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, ISalesDeliveryDeleteHandler
    {
        public SalesDeliveryDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}