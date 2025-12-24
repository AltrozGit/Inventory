using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<Indotalent.Projects.ProjectExpenseRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Indotalent.Projects.ProjectExpenseRow;

namespace Indotalent.Projects
{
    public interface IProjectExpenseSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class ProjectExpenseSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IProjectExpenseSaveHandler
    {
        public ProjectExpenseSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}