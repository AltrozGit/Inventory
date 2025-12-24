using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = Indotalent.Projects.ProjectMaterialRequestRow;

namespace Indotalent.Projects
{
    public interface IProjectMaterialRequestDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class ProjectMaterialRequestDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IProjectMaterialRequestDeleteHandler
    {
        public ProjectMaterialRequestDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}