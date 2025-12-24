using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Indotalent.Projects.ProjectFundRow>;
using MyRow = Indotalent.Projects.ProjectFundRow;

namespace Indotalent.Projects
{
    public interface IProjectFundRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class ProjectFundRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IProjectFundRetrieveHandler
    {
        public ProjectFundRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}