using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Indotalent.Purchase.PurchaseReceiptDetailRow>;
using MyRow = Indotalent.Purchase.PurchaseReceiptDetailRow;

namespace Indotalent.Purchase
{
    public interface IPurchaseReceiptDetailListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class PurchaseReceiptDetailListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IPurchaseReceiptDetailListHandler
    {
        public PurchaseReceiptDetailListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}