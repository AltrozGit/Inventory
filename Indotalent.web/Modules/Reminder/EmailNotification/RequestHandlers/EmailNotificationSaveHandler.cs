using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<Indotalent.Reminder.EmailNotificationRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Indotalent.Reminder.EmailNotificationRow;

namespace Indotalent.Reminder
{
    public interface IEmailNotificationSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class EmailNotificationSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IEmailNotificationSaveHandler
    {
      
        public EmailNotificationSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}