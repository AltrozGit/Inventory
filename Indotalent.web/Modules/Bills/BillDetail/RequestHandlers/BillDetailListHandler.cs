using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Indotalent.Bills.BillDetailRow>;
using MyRow = Indotalent.Bills.BillDetailRow;

namespace Indotalent.Bills
{
    public interface IBillDetailListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class BillDetailListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IBillDetailListHandler
    {
        public BillDetailListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}