using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Indotalent.Sales.SalesDeliveryRow>;
using MyRow = Indotalent.Sales.SalesDeliveryRow;

namespace Indotalent.Sales
{
    public interface ISalesDeliveryListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class SalesDeliveryListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, ISalesDeliveryListHandler
    {
        public SalesDeliveryListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}