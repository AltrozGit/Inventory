using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = Indotalent.Reminder.TenantUnitTransactionRow;

namespace Indotalent.Reminder
{
    public interface ITenantUnitTransactionDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class TenantUnitTransactionDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, ITenantUnitTransactionDeleteHandler
    {
        public TenantUnitTransactionDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}