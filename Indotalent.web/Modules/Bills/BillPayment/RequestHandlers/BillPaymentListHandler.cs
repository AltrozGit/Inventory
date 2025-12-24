using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Indotalent.Bills.BillPaymentRow>;
using MyRow = Indotalent.Bills.BillPaymentRow;

namespace Indotalent.Bills
{
    public interface IBillPaymentListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class BillPaymentListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IBillPaymentListHandler
    {
        public BillPaymentListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}