using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Indotalent.Material.RequestRow>;
using MyRow = Indotalent.Material.RequestRow;

namespace Indotalent.Material
{
    public interface IRequestListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class RequestListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IRequestListHandler
    {

        public RequestListHandler(IRequestContext context)
             : base(context)

        {

        }
    }
}