using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<Indotalent.Material.StatusMasterRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Indotalent.Material.StatusMasterRow;

namespace Indotalent.Material
{
    public interface IStatusMasterSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class StatusMasterSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IStatusMasterSaveHandler
    {
        public StatusMasterSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}