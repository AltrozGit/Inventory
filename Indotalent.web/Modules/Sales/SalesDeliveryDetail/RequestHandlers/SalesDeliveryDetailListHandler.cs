using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Indotalent.Sales.SalesDeliveryDetailRow>;
using MyRow = Indotalent.Sales.SalesDeliveryDetailRow;

namespace Indotalent.Sales
{
    public interface ISalesDeliveryDetailListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class SalesDeliveryDetailListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, ISalesDeliveryDetailListHandler
    {
        public SalesDeliveryDetailListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}