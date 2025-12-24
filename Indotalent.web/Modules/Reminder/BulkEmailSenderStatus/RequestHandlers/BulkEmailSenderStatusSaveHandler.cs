using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<Indotalent.Reminder.BulkEmailSenderStatusRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Indotalent.Reminder.BulkEmailSenderStatusRow;

namespace Indotalent.Reminder
{
    public interface IBulkEmailSenderStatusSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class BulkEmailSenderStatusSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IBulkEmailSenderStatusSaveHandler
    {
        public BulkEmailSenderStatusSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}