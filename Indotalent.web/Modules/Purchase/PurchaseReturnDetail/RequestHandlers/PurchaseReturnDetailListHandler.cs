using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Indotalent.Purchase.PurchaseReturnDetailRow>;
using MyRow = Indotalent.Purchase.PurchaseReturnDetailRow;

namespace Indotalent.Purchase
{
    public interface IPurchaseReturnDetailListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class PurchaseReturnDetailListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IPurchaseReturnDetailListHandler
    {
        public PurchaseReturnDetailListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}