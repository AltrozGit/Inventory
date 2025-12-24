using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Indotalent.Reminder.BulkEmailFileUploadRow>;
using MyRow = Indotalent.Reminder.BulkEmailFileUploadRow;

namespace Indotalent.Reminder
{
    public interface IBulkEmailFileUploadListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class BulkEmailFileUploadListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IBulkEmailFileUploadListHandler
    {
        public BulkEmailFileUploadListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}