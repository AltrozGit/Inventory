using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<Indotalent.Projects.ProjectRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Indotalent.Projects.ProjectRow;

namespace Indotalent.Projects
{
    public interface IProjectSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class ProjectSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IProjectSaveHandler
    {
        public ProjectSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}