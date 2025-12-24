using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<Indotalent.Projects.ProjectFundRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Indotalent.Projects.ProjectFundRow;

namespace Indotalent.Projects
{
    public interface IProjectFundSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class ProjectFundSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IProjectFundSaveHandler
    {
        public ProjectFundSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}