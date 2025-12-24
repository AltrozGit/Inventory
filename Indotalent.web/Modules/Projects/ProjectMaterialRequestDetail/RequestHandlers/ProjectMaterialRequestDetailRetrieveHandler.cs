using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Indotalent.Projects.ProjectMaterialRequestDetailRow>;
using MyRow = Indotalent.Projects.ProjectMaterialRequestDetailRow;

namespace Indotalent.Projects
{
    public interface IProjectMaterialRequestDetailRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class ProjectMaterialRequestDetailRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IProjectMaterialRequestDetailRetrieveHandler
    {
        public ProjectMaterialRequestDetailRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}