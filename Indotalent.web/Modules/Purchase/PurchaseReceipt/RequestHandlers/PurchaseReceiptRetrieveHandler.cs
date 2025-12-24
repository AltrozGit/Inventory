using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Indotalent.Purchase.PurchaseReceiptRow>;
using MyRow = Indotalent.Purchase.PurchaseReceiptRow;

namespace Indotalent.Purchase
{
    public interface IPurchaseReceiptRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class PurchaseReceiptRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IPurchaseReceiptRetrieveHandler
    {
        public PurchaseReceiptRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}