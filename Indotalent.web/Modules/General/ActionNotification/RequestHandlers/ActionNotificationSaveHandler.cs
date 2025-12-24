using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<Indotalent.General.ActionNotificationRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Indotalent.General.ActionNotificationRow;

namespace Indotalent.General
{
    public interface IActionNotificationSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class ActionNotificationSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IActionNotificationSaveHandler
    {
        public ActionNotificationSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}