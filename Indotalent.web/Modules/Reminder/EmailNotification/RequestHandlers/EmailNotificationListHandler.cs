using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Indotalent.Reminder.EmailNotificationRow>;
using MyRow = Indotalent.Reminder.EmailNotificationRow;

namespace Indotalent.Reminder
{
    public interface IEmailNotificationListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class EmailNotificationListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IEmailNotificationListHandler
    {
        public EmailNotificationListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}