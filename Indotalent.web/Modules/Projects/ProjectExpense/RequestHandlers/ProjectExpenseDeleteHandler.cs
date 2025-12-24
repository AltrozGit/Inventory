using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = Indotalent.Projects.ProjectExpenseRow;

namespace Indotalent.Projects
{
    public interface IProjectExpenseDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class ProjectExpenseDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IProjectExpenseDeleteHandler
    {
        public ProjectExpenseDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}