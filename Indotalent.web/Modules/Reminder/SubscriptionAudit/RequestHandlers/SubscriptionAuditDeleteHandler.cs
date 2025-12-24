using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = Indotalent.Reminder.SubscriptionAuditRow;

namespace Indotalent.Reminder
{
    public interface ISubscriptionAuditDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class SubscriptionAuditDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, ISubscriptionAuditDeleteHandler
    {
        public SubscriptionAuditDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}