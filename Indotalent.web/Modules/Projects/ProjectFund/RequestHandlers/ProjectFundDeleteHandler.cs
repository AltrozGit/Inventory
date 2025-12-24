using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = Indotalent.Projects.ProjectFundRow;

namespace Indotalent.Projects
{
    public interface IProjectFundDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class ProjectFundDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IProjectFundDeleteHandler
    {
        public ProjectFundDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}