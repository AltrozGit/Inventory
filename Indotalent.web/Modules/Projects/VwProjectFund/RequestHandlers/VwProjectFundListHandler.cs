using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Indotalent.Projects.vwProjectFundRow>;
using MyRow = Indotalent.Projects.vwProjectFundRow;

namespace Indotalent.Projects
{
    public interface IVwProjectFundListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class VwProjectFundListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IVwProjectFundListHandler
    {
        public VwProjectFundListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}