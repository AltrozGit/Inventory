using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Indotalent.Projects.ProjectExpenseRow>;
using MyRow = Indotalent.Projects.ProjectExpenseRow;

namespace Indotalent.Projects
{
    public interface IProjectExpenseRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class ProjectExpenseRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IProjectExpenseRetrieveHandler
    {
        public ProjectExpenseRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}