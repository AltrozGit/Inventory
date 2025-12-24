using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = Indotalent.Purchase.PurchaseReceiptDetailRow;

namespace Indotalent.Purchase
{
    public interface IPurchaseReceiptDetailDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class PurchaseReceiptDetailDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IPurchaseReceiptDetailDeleteHandler
    {
        public PurchaseReceiptDetailDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}