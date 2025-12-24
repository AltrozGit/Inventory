using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Indotalent.Material.StatusMasterRow>;
using MyRow = Indotalent.Material.StatusMasterRow;

namespace Indotalent.Material
{
    public interface IStatusMasterListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class StatusMasterListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IStatusMasterListHandler
    {
        public StatusMasterListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}