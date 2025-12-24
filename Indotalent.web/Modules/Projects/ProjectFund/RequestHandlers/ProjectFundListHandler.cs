using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Indotalent.Projects.ProjectFundRow>;
using MyRow = Indotalent.Projects.ProjectFundRow;

namespace Indotalent.Projects
{
    public interface IProjectFundListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class ProjectFundListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IProjectFundListHandler
    {
        public ProjectFundListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}