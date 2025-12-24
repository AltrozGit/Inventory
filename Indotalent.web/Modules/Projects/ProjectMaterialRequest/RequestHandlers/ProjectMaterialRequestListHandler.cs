using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Indotalent.Projects.ProjectMaterialRequestRow>;
using MyRow = Indotalent.Projects.ProjectMaterialRequestRow;

namespace Indotalent.Projects
{
    public interface IProjectMaterialRequestListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class ProjectMaterialRequestListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IProjectMaterialRequestListHandler
    {
        public ProjectMaterialRequestListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}