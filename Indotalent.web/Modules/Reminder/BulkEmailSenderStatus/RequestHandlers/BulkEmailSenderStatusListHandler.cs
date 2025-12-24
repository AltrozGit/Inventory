using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Indotalent.Reminder.BulkEmailSenderStatusRow>;
using MyRow = Indotalent.Reminder.BulkEmailSenderStatusRow;

namespace Indotalent.Reminder
{
    public interface IBulkEmailSenderStatusListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class BulkEmailSenderStatusListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IBulkEmailSenderStatusListHandler
    {
        public BulkEmailSenderStatusListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}