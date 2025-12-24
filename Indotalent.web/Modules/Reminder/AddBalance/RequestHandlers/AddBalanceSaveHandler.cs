using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<Indotalent.Reminder.AddBalanceRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Indotalent.Reminder.AddBalanceRow;

namespace Indotalent.Reminder
{
    public interface IAddBalanceSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class AddBalanceSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IAddBalanceSaveHandler
    {
        public AddBalanceSaveHandler(IRequestContext context)
             : base(context)
        {
        }
        protected override void BeforeSave()
        {
            base.BeforeSave();

            Row.TenantId = Row.ApplicationTenantId;
        }

    }
}