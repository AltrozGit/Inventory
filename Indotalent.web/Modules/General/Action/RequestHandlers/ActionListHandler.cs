using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Indotalent.General.ActionRow>;
using MyRow = Indotalent.General.ActionRow;

namespace Indotalent.General
{
    public interface IActionListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class ActionListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IActionListHandler
    {
        public ActionListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}