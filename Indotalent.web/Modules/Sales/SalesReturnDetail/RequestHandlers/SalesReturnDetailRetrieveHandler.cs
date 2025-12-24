using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Indotalent.Sales.SalesReturnDetailRow>;
using MyRow = Indotalent.Sales.SalesReturnDetailRow;

namespace Indotalent.Sales
{
    public interface ISalesReturnDetailRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class SalesReturnDetailRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, ISalesReturnDetailRetrieveHandler
    {
        public SalesReturnDetailRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}