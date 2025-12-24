using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = Indotalent.Material.StatusMasterRow;

namespace Indotalent.Material
{
    public interface IStatusMasterDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class StatusMasterDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IStatusMasterDeleteHandler
    {
        public StatusMasterDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}