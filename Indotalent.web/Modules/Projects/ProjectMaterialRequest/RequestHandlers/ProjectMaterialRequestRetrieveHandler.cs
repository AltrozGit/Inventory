using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Indotalent.Projects.ProjectMaterialRequestRow>;
using MyRow = Indotalent.Projects.ProjectMaterialRequestRow;

namespace Indotalent.Projects
{
    public interface IProjectMaterialRequestRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class ProjectMaterialRequestRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IProjectMaterialRequestRetrieveHandler
    {
        public ProjectMaterialRequestRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}