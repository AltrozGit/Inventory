using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = Indotalent.Purchase.PurchaseReceiptRow;

namespace Indotalent.Purchase
{
    public interface IPurchaseReceiptDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class PurchaseReceiptDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IPurchaseReceiptDeleteHandler
    {
        public PurchaseReceiptDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}