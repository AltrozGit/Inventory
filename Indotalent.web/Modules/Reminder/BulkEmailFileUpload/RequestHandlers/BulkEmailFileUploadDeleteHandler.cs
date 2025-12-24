using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = Indotalent.Reminder.BulkEmailFileUploadRow;

namespace Indotalent.Reminder
{
    public interface IBulkEmailFileUploadDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class BulkEmailFileUploadDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IBulkEmailFileUploadDeleteHandler
    {
        public BulkEmailFileUploadDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}