using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Indotalent.Web.Modules.Common.Project_Summary.ProjectExpense.ProjectExpensesRow>;
using MyRow = Indotalent.Web.Modules.Common.Project_Summary.ProjectExpense.ProjectExpensesRow;

namespace Indotalent.Web.Modules.Common.Project_Summary.ProjectExpense.RequestHandlers
{
    public interface IProjectExpensesListHandler : IListHandler<MyRow, MyRequest, MyResponse>
    {

    }


    public class ProjectExpensesListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IProjectExpensesListHandler
    {

        public ProjectExpensesListHandler(IRequestContext context)
             : base(context)
        {


        }

    }
}