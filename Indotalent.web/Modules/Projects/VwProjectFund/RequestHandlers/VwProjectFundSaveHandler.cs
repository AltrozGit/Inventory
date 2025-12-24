using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<Indotalent.Projects.vwProjectFundRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Indotalent.Projects.vwProjectFundRow;

namespace Indotalent.Projects
{
    public interface IVwProjectFundSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class VwProjectFundSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IVwProjectFundSaveHandler
    {
        public VwProjectFundSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}