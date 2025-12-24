using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = Indotalent.Merchandise.HSNRow;

namespace Indotalent.Merchandise
{
    public interface IHSNDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class HSNDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IHSNDeleteHandler
    {
        public HSNDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}