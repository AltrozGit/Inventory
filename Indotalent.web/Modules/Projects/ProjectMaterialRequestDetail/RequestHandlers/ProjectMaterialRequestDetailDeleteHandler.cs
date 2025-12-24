using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = Indotalent.Projects.ProjectMaterialRequestDetailRow;

namespace Indotalent.Projects
{
    public interface IProjectMaterialRequestDetailDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class ProjectMaterialRequestDetailDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IProjectMaterialRequestDetailDeleteHandler
    {
        public ProjectMaterialRequestDetailDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}