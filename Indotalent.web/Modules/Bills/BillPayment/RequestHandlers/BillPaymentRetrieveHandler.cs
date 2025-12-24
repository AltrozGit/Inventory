using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Indotalent.Bills.BillPaymentRow>;
using MyRow = Indotalent.Bills.BillPaymentRow;

namespace Indotalent.Bills
{
    public interface IBillPaymentRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class BillPaymentRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IBillPaymentRetrieveHandler
    {
        public BillPaymentRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}