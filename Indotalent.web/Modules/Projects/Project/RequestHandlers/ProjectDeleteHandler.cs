using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = Indotalent.Projects.ProjectRow;

namespace Indotalent.Projects 
{
    public interface IProjectDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class ProjectDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IProjectDeleteHandler
    {
        public ProjectDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}