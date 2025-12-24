using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<Indotalent.Reminder.TenantUnitTransactionRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Indotalent.Reminder.TenantUnitTransactionRow;

namespace Indotalent.Reminder
{
    public interface ITenantUnitTransactionSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class TenantUnitTransactionSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, ITenantUnitTransactionSaveHandler
    {
        public TenantUnitTransactionSaveHandler(IRequestContext context)
             : base(context)
        {
        }
        protected override void BeforeSave()
        {
            if (IsUpdate)
                throw new ValidationError("Transactions cannot be updated, only new ones can be created.");

            base.BeforeSave();
        }
    }
}