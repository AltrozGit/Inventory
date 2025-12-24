using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<Indotalent.Purchase.PaymentTermRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Indotalent.Purchase.PaymentTermRow;

namespace Indotalent.Purchase
{
    public interface IPaymentTermSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class PaymentTermSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IPaymentTermSaveHandler
    {
        public PaymentTermSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}