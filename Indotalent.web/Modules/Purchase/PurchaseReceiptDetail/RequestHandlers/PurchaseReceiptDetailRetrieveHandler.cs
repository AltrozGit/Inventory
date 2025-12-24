using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Indotalent.Purchase.PurchaseReceiptDetailRow>;
using MyRow = Indotalent.Purchase.PurchaseReceiptDetailRow;

namespace Indotalent.Purchase
{
    public interface IPurchaseReceiptDetailRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class PurchaseReceiptDetailRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IPurchaseReceiptDetailRetrieveHandler
    {
        public PurchaseReceiptDetailRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}