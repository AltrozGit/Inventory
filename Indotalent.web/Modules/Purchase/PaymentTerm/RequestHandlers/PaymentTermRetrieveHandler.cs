using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Indotalent.Purchase.PaymentTermRow>;
using MyRow = Indotalent.Purchase.PaymentTermRow;

namespace Indotalent.Purchase
{
    public interface IPaymentTermRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class PaymentTermRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IPaymentTermRetrieveHandler
    {
        public PaymentTermRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}