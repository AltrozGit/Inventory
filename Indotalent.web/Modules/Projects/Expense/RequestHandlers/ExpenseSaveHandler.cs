using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<Indotalent.Projects.ExpenseRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Indotalent.Projects.ExpenseRow;

namespace Indotalent.Projects
{
    public interface IExpenseSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class ExpenseSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IExpenseSaveHandler
    {
        public ExpenseSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}