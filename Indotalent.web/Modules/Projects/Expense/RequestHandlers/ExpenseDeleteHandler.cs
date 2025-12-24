using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = Indotalent.Projects.ExpenseRow;

namespace Indotalent.Projects
{
    public interface IExpenseDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class ExpenseDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IExpenseDeleteHandler
    {
        public ExpenseDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}