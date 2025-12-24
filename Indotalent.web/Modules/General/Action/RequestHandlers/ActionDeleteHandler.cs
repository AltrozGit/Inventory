using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = Indotalent.General.ActionRow;

namespace Indotalent.General
{
    public interface IActionDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class ActionDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IActionDeleteHandler
    {
        public ActionDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}