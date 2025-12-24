using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = Indotalent.Bills.BillRow;

namespace Indotalent.Bills
{
    public interface IBillDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class BillDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IBillDeleteHandler
    {
        public BillDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}