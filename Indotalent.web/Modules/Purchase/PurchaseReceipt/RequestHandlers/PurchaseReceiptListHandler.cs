using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Indotalent.Purchase.PurchaseReceiptRow>;
using MyRow = Indotalent.Purchase.PurchaseReceiptRow;

namespace Indotalent.Purchase
{
    public interface IPurchaseReceiptListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class PurchaseReceiptListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IPurchaseReceiptListHandler
    {
        public PurchaseReceiptListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}