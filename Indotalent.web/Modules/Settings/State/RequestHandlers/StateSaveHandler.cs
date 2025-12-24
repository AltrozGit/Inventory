using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<Indotalent.Settings.StateRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Indotalent.Settings.StateRow;

namespace Indotalent.Settings
{
    public interface IStateSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class StateSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IStateSaveHandler
    {
        public StateSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}