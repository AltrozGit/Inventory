using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = Indotalent.Purchase.PurchaseReturnRow;

namespace Indotalent.Purchase
{
    public interface IPurchaseReturnDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class PurchaseReturnDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IPurchaseReturnDeleteHandler
    {
        public PurchaseReturnDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}