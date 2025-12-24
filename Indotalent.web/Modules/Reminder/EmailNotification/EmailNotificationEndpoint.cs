using Indotalent.Administration;
using Indotalent.Web.Common;
using Indotalent.Web.Modules.Reminder.BulkEmailFileUpload;
using Indotalent.Web.Modules.Reminder.BulkEmailSender;
using Indotalent.Web.Modules.Reminder.EmailNotification;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using Serenity;
using Serenity.Abstractions;
using Serenity.Data;
using Serenity.Reporting;
using Serenity.Services;
using Serenity.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using static Indotalent.Reminder.Endpoints.EmailNotificationController;
using static MVC.Views.Reminder;
using MyRow = Indotalent.Reminder.EmailNotificationRow;

namespace Indotalent.Reminder.Endpoints
{
    [Route("Services/Reminder/EmailNotification/[action]")]
    [ConnectionKey(typeof(MyRow)), ServiceAuthorize(typeof(MyRow))]
    public class EmailNotificationController : ServiceEndpoint
    {
        private readonly EmailNotificationService _emailNotificationService;

        private readonly IBulkEmailFileUploadRetrieveHandler _bulkEmailFileUploadRetrieveHandler;
        private readonly BulkEmailService _bulkEmailService;


        public EmailNotificationController(
           EmailNotificationService emailNotificationService,
           IBulkEmailFileUploadRetrieveHandler bulkEmailFileUploadRetrieveHandler,BulkEmailService bulkEmailService)
        {
            _emailNotificationService = emailNotificationService;
            _bulkEmailFileUploadRetrieveHandler = bulkEmailFileUploadRetrieveHandler;
            _bulkEmailService = bulkEmailService;
        }
        [HttpPost, AuthorizeCreate(typeof(MyRow))]
        public SaveResponse Create(IUnitOfWork uow, SaveRequest<MyRow> request, [FromServices] SaveRequest<BulkEmailFileUploadRow> request1,
            [FromServices] IEmailNotificationSaveHandler handler)
        {
            var tenantId = request1.Entity.TenantId;
           // var insertUserId = request1.Entity.InsertUserId;
            var bulkEmailData = _bulkEmailService.ReadBulkEmailData(request1.Entity.FilePath, (int)tenantId, (int)request.Entity.InsertUserId);


            try
            {
                // Ensure that FilePath is provided in the request
                if (string.IsNullOrEmpty(request1.Entity.FilePath))
                {
                    throw new InvalidOperationException("No file found");
                }

                // Retrieve BulkEmailSenderId from the request
                var bulkEmailSenderId = request.Entity.BulkEmailSenderId;
                if (bulkEmailSenderId == null)
                {
                    throw new InvalidOperationException("bulkEmailSenderId must be provided");
                }

                // Fetch BulkEmailSender data
                var bulkEmailSenderRequest = new RetrieveRequest
                {
                    EntityId = bulkEmailSenderId.Value
                };

                var bulkEmailSenderResponse = _bulkEmailFileUploadRetrieveHandler.Retrieve(uow.Connection, bulkEmailSenderRequest);
                if (bulkEmailSenderResponse == null || bulkEmailSenderResponse.Entity == null)
                {
                    throw new InvalidOperationException("BulkEmailSender not found.");
                }
                var saveResponse = handler.Create(uow, request);
                var bulkEmailData1 = _bulkEmailService.ReadBulkEmailData(bulkEmailSenderResponse.Entity.FilePath, (int)bulkEmailSenderResponse.Entity.TenantId, (int)bulkEmailSenderResponse.Entity.InsertUserId);

                // Insert into EmailNotification table
                _emailNotificationService.InsertIntoEmailNotification(bulkEmailData1, uow, bulkEmailSenderId.Value);
                return saveResponse;

            }
            catch (Exception)
            {
                // Log and handle the exception as necessary
                throw new InvalidOperationException("Internal server error: {ex.Message}");
            }
        }






        [HttpPost, AuthorizeUpdate(typeof(MyRow))]
        public SaveResponse Update(IUnitOfWork uow, SaveRequest<MyRow> request, [FromServices] SaveRequest<BulkEmailFileUploadRow> request1,
    [FromServices] IEmailNotificationSaveHandler handler, [FromServices] IUserRetrieveService userRetrieveService,
    [FromForm] IFormFile file)
        {
            var user = (UserDefinition)User.GetUserDefinition(userRetrieveService);
            var tenantId = user.TenantId;
            request.Entity.TenantId = tenantId;
            var bulkEmailSenderId = request.Entity.BulkEmailSenderId;
            var insertUserId = user.UserId;
            if (request.Entity.TenantId == null)
            {
                throw new ArgumentException("TenantId must be provided.");
            }

           

            try
            {
                var bulkEmailData = _bulkEmailService.ReadBulkEmailData(request1.Entity.FilePath,tenantId,insertUserId);
                _emailNotificationService.InsertIntoEmailNotification(bulkEmailData, uow, bulkEmailSenderId.Value);
            }
            catch (Exception ex)
            {
                // Log and handle the exception as necessary
                throw new InvalidOperationException("Error processing the file", ex);
            }

            return handler.Update(uow, request);
        }


        [HttpPost, AuthorizeDelete(typeof(MyRow))]
        public DeleteResponse Delete(IUnitOfWork uow, DeleteRequest request,
            [FromServices] IEmailNotificationDeleteHandler handler)
        {
            return handler.Delete(uow, request);
        }

        [HttpPost]
        public RetrieveResponse<MyRow> Retrieve(IDbConnection connection, RetrieveRequest request,
            [FromServices] IEmailNotificationRetrieveHandler handler)
        {
            return handler.Retrieve(connection, request);
        }

        [HttpPost]
        public ListResponse<MyRow> List(IDbConnection connection, ListRequest request,
            [FromServices] IEmailNotificationListHandler handler)
        {
            return handler.List(connection, request);
        }
      

        //public FileContentResult ListExcel(IDbConnection connection, ListRequest request,
        //    [FromServices] IEmailNotificationListHandler handler,
        //    [FromServices] IExcelExporter exporter)
        //{
          //  var data = List(connection, request, handler).Entities;
           // var bytes = exporter.Export(data, typeof(Columns.EmailNotificationColumns), request.ExportColumns);
            //return ExcelContentResult.Create(bytes, "EmailNotificationList_" +
               // DateTime.Now.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture) + ".xlsx");
        //}
    }
}