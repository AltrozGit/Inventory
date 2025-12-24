using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = Indotalent.Reminder.SubscriptionRow;

namespace Indotalent.Reminder
{
    public interface ISubscriptionDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class SubscriptionDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, ISubscriptionDeleteHandler
    {
        public SubscriptionDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}