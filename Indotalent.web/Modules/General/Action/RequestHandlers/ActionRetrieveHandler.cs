using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Indotalent.General.ActionRow>;
using MyRow = Indotalent.General.ActionRow;

namespace Indotalent.General
{
    public interface IActionRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class ActionRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IActionRetrieveHandler
    {
        public ActionRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}