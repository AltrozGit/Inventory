using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Indotalent.Reminder.AddBalanceRow>;
using MyRow = Indotalent.Reminder.AddBalanceRow;

namespace Indotalent.Reminder
{
    public interface IAddBalanceRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class AddBalanceRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IAddBalanceRetrieveHandler
    {
        public AddBalanceRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}