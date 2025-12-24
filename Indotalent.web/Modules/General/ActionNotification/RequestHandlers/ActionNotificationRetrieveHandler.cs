using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Indotalent.General.ActionNotificationRow>;
using MyRow = Indotalent.General.ActionNotificationRow;

namespace Indotalent.General
{
    public interface IActionNotificationRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class ActionNotificationRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IActionNotificationRetrieveHandler
    {
        public ActionNotificationRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}