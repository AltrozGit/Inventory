using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Indotalent.Projects.ProjectRow>;
using MyRow = Indotalent.Projects.ProjectRow;

namespace Indotalent.Projects
{
    public interface IProjectRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class ProjectRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IProjectRetrieveHandler
    {
        public ProjectRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}