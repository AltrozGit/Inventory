using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<Indotalent.Reminder.SubscriptionRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Indotalent.Reminder.SubscriptionRow;

namespace Indotalent.Reminder
{
    public interface ISubscriptionSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class SubscriptionSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, ISubscriptionSaveHandler
    {
        public SubscriptionSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}