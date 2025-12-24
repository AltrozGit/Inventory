using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<Indotalent.Purchase.PurchaseReturnDetailRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Indotalent.Purchase.PurchaseReturnDetailRow;

namespace Indotalent.Purchase
{
    public interface IPurchaseReturnDetailSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class PurchaseReturnDetailSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IPurchaseReturnDetailSaveHandler
    {
        public PurchaseReturnDetailSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}