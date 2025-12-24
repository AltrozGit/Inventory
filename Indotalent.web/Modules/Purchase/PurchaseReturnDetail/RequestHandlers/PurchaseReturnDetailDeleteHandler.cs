using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = Indotalent.Purchase.PurchaseReturnDetailRow;

namespace Indotalent.Purchase
{
    public interface IPurchaseReturnDetailDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class PurchaseReturnDetailDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IPurchaseReturnDetailDeleteHandler
    {
        public PurchaseReturnDetailDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}