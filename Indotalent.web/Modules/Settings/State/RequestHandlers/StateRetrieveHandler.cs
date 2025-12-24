using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Indotalent.Settings.StateRow>;
using MyRow = Indotalent.Settings.StateRow;

namespace Indotalent.Settings
{
    public interface IStateRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class StateRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IStateRetrieveHandler
    {
        public StateRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}