using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Indotalent.Sales.SalesReturnRow>;
using MyRow = Indotalent.Sales.SalesReturnRow;

namespace Indotalent.Sales
{
    public interface ISalesReturnListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class SalesReturnListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, ISalesReturnListHandler
    {
        public SalesReturnListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}