using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = Indotalent.Reminder.EmailNotificationRow;

namespace Indotalent.Reminder
{
    public interface IEmailNotificationDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class EmailNotificationDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IEmailNotificationDeleteHandler
    {
        public EmailNotificationDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}