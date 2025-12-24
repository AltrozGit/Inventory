using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Indotalent.Merchandise.HSNRow>;
using MyRow = Indotalent.Merchandise.HSNRow;

namespace Indotalent.Merchandise
{
    public interface IHSNListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class HSNListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IHSNListHandler
    {
        public HSNListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}