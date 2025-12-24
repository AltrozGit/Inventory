using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Indotalent.Material.StatusMasterRow>;
using MyRow = Indotalent.Material.StatusMasterRow;

namespace Indotalent.Material
{
    public interface IStatusMasterRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class StatusMasterRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IStatusMasterRetrieveHandler
    {
        public StatusMasterRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}