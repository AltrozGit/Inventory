using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = Indotalent.Reminder.AddBalanceRow;

namespace Indotalent.Reminder
{
    public interface IAddBalanceDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class AddBalanceDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IAddBalanceDeleteHandler
    {
        public AddBalanceDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}