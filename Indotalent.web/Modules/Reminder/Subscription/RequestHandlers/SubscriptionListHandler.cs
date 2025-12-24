using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Indotalent.Reminder.SubscriptionRow>;
using MyRow = Indotalent.Reminder.SubscriptionRow;

namespace Indotalent.Reminder
{
    public interface ISubscriptionListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class SubscriptionListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, ISubscriptionListHandler
    {
        public SubscriptionListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}