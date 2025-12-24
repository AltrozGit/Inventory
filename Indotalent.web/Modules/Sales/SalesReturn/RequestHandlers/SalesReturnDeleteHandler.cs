using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = Indotalent.Sales.SalesReturnRow;

namespace Indotalent.Sales
{
    public interface ISalesReturnDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class SalesReturnDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, ISalesReturnDeleteHandler
    {
        public SalesReturnDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}