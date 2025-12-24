using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Indotalent.Purchase.PurchaseReturnRow>;
using MyRow = Indotalent.Purchase.PurchaseReturnRow;

namespace Indotalent.Purchase
{
    public interface IPurchaseReturnListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class PurchaseReturnListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IPurchaseReturnListHandler
    {
        public PurchaseReturnListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}