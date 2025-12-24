using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Indotalent.Projects.ExpenseRow>;
using MyRow = Indotalent.Projects.ExpenseRow;

namespace Indotalent.Projects
{
    public interface IExpenseRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class ExpenseRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IExpenseRetrieveHandler
    {
        public ExpenseRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}