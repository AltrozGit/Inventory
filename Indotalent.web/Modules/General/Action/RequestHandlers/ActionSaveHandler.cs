using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<Indotalent.General.ActionRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Indotalent.General.ActionRow;

namespace Indotalent.General
{
    public interface IActionSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class ActionSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IActionSaveHandler
    {
        public ActionSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}