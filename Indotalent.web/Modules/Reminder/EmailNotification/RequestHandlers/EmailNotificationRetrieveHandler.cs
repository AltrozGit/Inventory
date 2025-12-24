using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Indotalent.Reminder.EmailNotificationRow>;
using MyRow = Indotalent.Reminder.EmailNotificationRow;

namespace Indotalent.Reminder
{
    public interface IEmailNotificationRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class EmailNotificationRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IEmailNotificationRetrieveHandler
    {
        public EmailNotificationRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}