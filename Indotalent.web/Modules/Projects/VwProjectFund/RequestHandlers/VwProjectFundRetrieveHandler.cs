using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Indotalent.Projects.vwProjectFundRow>;
using MyRow = Indotalent.Projects.vwProjectFundRow;

namespace Indotalent.Projects
{
    public interface IVwProjectFundRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class VwProjectFundRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IVwProjectFundRetrieveHandler
    {
        public VwProjectFundRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}