using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Indotalent.Reminder.AddBalanceRow>;
using MyRow = Indotalent.Reminder.AddBalanceRow;

namespace Indotalent.Reminder
{
    public interface IAddBalanceListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class AddBalanceListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IAddBalanceListHandler
    {
        public AddBalanceListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}