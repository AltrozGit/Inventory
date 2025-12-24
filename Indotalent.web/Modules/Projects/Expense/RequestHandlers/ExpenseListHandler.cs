using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Indotalent.Projects.ExpenseRow>;
using MyRow = Indotalent.Projects.ExpenseRow;

namespace Indotalent.Projects
{
    public interface IExpenseListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class ExpenseListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IExpenseListHandler
    {
        public ExpenseListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}