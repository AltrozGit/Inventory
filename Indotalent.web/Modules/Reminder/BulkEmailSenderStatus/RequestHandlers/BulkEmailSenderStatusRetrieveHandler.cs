using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Indotalent.Reminder.BulkEmailSenderStatusRow>;
using MyRow = Indotalent.Reminder.BulkEmailSenderStatusRow;

namespace Indotalent.Reminder
{
    public interface IBulkEmailSenderStatusRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class BulkEmailSenderStatusRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IBulkEmailSenderStatusRetrieveHandler
    {
        public BulkEmailSenderStatusRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}