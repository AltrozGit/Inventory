using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Indotalent.Reminder.SubscriptionAuditRow>;
using MyRow = Indotalent.Reminder.SubscriptionAuditRow;

namespace Indotalent.Reminder
{
    public interface ISubscriptionAuditRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class SubscriptionAuditRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, ISubscriptionAuditRetrieveHandler
    {
        public SubscriptionAuditRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}