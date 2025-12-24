using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Indotalent.Purchase.PurchaseReturnRow>;
using MyRow = Indotalent.Purchase.PurchaseReturnRow;

namespace Indotalent.Purchase
{
    public interface IPurchaseReturnRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class PurchaseReturnRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IPurchaseReturnRetrieveHandler
    {
        public PurchaseReturnRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}