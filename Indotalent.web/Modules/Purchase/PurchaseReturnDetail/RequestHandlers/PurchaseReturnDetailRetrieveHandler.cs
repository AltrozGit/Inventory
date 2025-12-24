using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Indotalent.Purchase.PurchaseReturnDetailRow>;
using MyRow = Indotalent.Purchase.PurchaseReturnDetailRow;

namespace Indotalent.Purchase
{
    public interface IPurchaseReturnDetailRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class PurchaseReturnDetailRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IPurchaseReturnDetailRetrieveHandler
    {
        public PurchaseReturnDetailRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}