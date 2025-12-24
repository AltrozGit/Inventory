using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Indotalent.Reminder.TenantUnitTransactionRow>;
using MyRow = Indotalent.Reminder.TenantUnitTransactionRow;

namespace Indotalent.Reminder
{
    public interface ITenantUnitTransactionRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class TenantUnitTransactionRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, ITenantUnitTransactionRetrieveHandler
    {
        public TenantUnitTransactionRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}