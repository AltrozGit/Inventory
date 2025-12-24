using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<Indotalent.Sales.SalesReturnDetailRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Indotalent.Sales.SalesReturnDetailRow;

namespace Indotalent.Sales
{
    public interface ISalesReturnDetailSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class SalesReturnDetailSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, ISalesReturnDetailSaveHandler
    {
        public SalesReturnDetailSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}