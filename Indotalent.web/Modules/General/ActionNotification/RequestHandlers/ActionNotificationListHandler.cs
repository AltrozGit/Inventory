using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Indotalent.General.ActionNotificationRow>;
using MyRow = Indotalent.General.ActionNotificationRow;

namespace Indotalent.General
{
    public interface IActionNotificationListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class ActionNotificationListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IActionNotificationListHandler
    {
        public ActionNotificationListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}