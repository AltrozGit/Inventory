using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<Indotalent.Reminder.SubscriptionAuditRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Indotalent.Reminder.SubscriptionAuditRow;

namespace Indotalent.Reminder
{
    public interface ISubscriptionAuditSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class SubscriptionAuditSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, ISubscriptionAuditSaveHandler
    {
        public SubscriptionAuditSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}