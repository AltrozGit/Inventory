using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = Indotalent.Projects.vwProjectFundRow;

namespace Indotalent.Projects
{
    public interface IVwProjectFundDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class VwProjectFundDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IVwProjectFundDeleteHandler
    {
        public VwProjectFundDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}