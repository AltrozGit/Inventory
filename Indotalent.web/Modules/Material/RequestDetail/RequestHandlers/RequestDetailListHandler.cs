using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Indotalent.Material.RequestDetailRow>;
using MyRow = Indotalent.Material.RequestDetailRow;

namespace Indotalent.Material
{
    public interface IRequestDetailListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class RequestDetailListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IRequestDetailListHandler
    {
        public RequestDetailListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}