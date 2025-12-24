using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Indotalent.Bills.BillRow>;
using MyRow = Indotalent.Bills.BillRow;

namespace Indotalent.Bills
{
    public interface IBillRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class BillRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IBillRetrieveHandler
    {
        public BillRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}