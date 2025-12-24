using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = Indotalent.Sales.SalesReturnDetailRow;

namespace Indotalent.Sales
{
    public interface ISalesReturnDetailDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class SalesReturnDetailDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, ISalesReturnDetailDeleteHandler
    {
        public SalesReturnDetailDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}