using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Indotalent.Purchase.PaymentTermRow>;
using MyRow = Indotalent.Purchase.PaymentTermRow;

namespace Indotalent.Purchase
{
    public interface IPaymentTermListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class PaymentTermListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IPaymentTermListHandler
    {
        public PaymentTermListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}