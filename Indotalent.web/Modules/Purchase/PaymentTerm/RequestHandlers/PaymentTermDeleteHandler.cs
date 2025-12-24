using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = Indotalent.Purchase.PaymentTermRow;

namespace Indotalent.Purchase
{
    public interface IPaymentTermDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class PaymentTermDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IPaymentTermDeleteHandler
    {
        public PaymentTermDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}