using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Indotalent.Sales.SalesReturnDetailRow>;
using MyRow = Indotalent.Sales.SalesReturnDetailRow;

namespace Indotalent.Sales
{
    public interface ISalesReturnDetailListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class SalesReturnDetailListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, ISalesReturnDetailListHandler
    {
        public SalesReturnDetailListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}