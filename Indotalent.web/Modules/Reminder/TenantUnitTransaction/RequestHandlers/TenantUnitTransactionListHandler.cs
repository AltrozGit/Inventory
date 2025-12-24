using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Indotalent.Reminder.TenantUnitTransactionRow>;
using MyRow = Indotalent.Reminder.TenantUnitTransactionRow;

namespace Indotalent.Reminder
{
    public interface ITenantUnitTransactionListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class TenantUnitTransactionListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, ITenantUnitTransactionListHandler
    {
        public TenantUnitTransactionListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}