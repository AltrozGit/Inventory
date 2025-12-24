using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = Indotalent.Reminder.BulkEmailSenderStatusRow;

namespace Indotalent.Reminder
{
    public interface IBulkEmailSenderStatusDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class BulkEmailSenderStatusDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IBulkEmailSenderStatusDeleteHandler
    {
        public BulkEmailSenderStatusDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}