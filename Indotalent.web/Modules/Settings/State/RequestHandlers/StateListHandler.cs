using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Indotalent.Settings.StateRow>;
using MyRow = Indotalent.Settings.StateRow;

namespace Indotalent.Settings
{
    public interface IStateListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class StateListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IStateListHandler
    {
        public StateListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}