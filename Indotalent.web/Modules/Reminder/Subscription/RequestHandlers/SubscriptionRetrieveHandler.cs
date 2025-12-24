using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Indotalent.Reminder.SubscriptionRow>;
using MyRow = Indotalent.Reminder.SubscriptionRow;

namespace Indotalent.Reminder
{
    public interface ISubscriptionRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class SubscriptionRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, ISubscriptionRetrieveHandler
    {
        public SubscriptionRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}