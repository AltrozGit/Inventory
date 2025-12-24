using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Indotalent.Projects.ProjectExpenseRow>;
using MyRow = Indotalent.Projects.ProjectExpenseRow;

namespace Indotalent.Projects
{
    public interface IProjectExpenseListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class ProjectExpenseListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IProjectExpenseListHandler
    {
        public ProjectExpenseListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}