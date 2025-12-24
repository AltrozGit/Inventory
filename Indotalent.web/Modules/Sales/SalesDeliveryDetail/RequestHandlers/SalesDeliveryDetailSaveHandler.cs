using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<Indotalent.Sales.SalesDeliveryDetailRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Indotalent.Sales.SalesDeliveryDetailRow;

namespace Indotalent.Sales
{
    public interface ISalesDeliveryDetailSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class SalesDeliveryDetailSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, ISalesDeliveryDetailSaveHandler
    {
        public SalesDeliveryDetailSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}