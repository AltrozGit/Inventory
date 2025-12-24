using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = Indotalent.Settings.StateRow;

namespace Indotalent.Settings
{
    public interface IStateDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class StateDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IStateDeleteHandler
    {
        public StateDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}