using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = Indotalent.General.ActionNotificationRow;

namespace Indotalent.General
{
    public interface IActionNotificationDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class ActionNotificationDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IActionNotificationDeleteHandler
    {
        public ActionNotificationDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}