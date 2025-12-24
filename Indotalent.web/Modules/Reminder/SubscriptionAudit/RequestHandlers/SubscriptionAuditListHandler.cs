using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Indotalent.Reminder.SubscriptionAuditRow>;
using MyRow = Indotalent.Reminder.SubscriptionAuditRow;

namespace Indotalent.Reminder
{
    public interface ISubscriptionAuditListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class SubscriptionAuditListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, ISubscriptionAuditListHandler
    {
        public SubscriptionAuditListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}