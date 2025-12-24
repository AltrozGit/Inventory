using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Indotalent.Reminder.BulkEmailFileUploadRow>;
using MyRow = Indotalent.Reminder.BulkEmailFileUploadRow;

namespace Indotalent.Reminder
{
    public interface IBulkEmailFileUploadRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

  
    public class BulkEmailFileUploadRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IBulkEmailFileUploadRetrieveHandler
    {
        public BulkEmailFileUploadRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}