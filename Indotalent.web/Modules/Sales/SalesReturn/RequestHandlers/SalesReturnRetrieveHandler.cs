using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Indotalent.Sales.SalesReturnRow>;
using MyRow = Indotalent.Sales.SalesReturnRow;

namespace Indotalent.Sales
{
    public interface ISalesReturnRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class SalesReturnRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, ISalesReturnRetrieveHandler
    {
        public SalesReturnRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}