using Indotalent.Administration;
using Indotalent.Web.Common;
using Indotalent.Web.Modules.Reminder.BulkEmailFileUpload;
using Indotalent.Web.Modules.Reminder.BulkEmailSender;
using Indotalent.Web.Modules.Reminder.EmailNotification;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using Serenity;
using Serenity.Abstractions;
using Serenity.Data;
using Serenity.Reporting;
using Serenity.Services;
using Serenity.Web;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using static Indotalent.Web.Common.Enums;
using static MVC.Views.Administration;
using static MVC.Views.Reminder;
using MyRow = Indotalent.Reminder.BulkEmailFileUploadRow;

namespace Indotalent.Reminder.Endpoints
{
    [Route("Services/Reminder/BulkEmailFileUpload/[action]")]
    [ConnectionKey(typeof(MyRow)), ServiceAuthorize(typeof(MyRow))]
    public class BulkEmailFileUploadController : ServiceEndpoint
    {

        protected IUserAccessor UserAccessor { get; }
        private IUserRetrieveService UserRetriever { get; }
        private readonly EmailNotificationService _emailNotificationService;
        private readonly BulkEmailService _bulkEmailService;
        public BulkEmailFileUploadController(EmailNotificationService emailNotificationService, BulkEmailService bulkEmailService)
        {
            _emailNotificationService = emailNotificationService;
            _bulkEmailService = bulkEmailService;
        }
        [HttpPost]
        public string GetTenantId(IUnitOfWork uow, [FromServices] IUserRetrieveService userRetrieveService)
        {
            var user = (UserDefinition)User.GetUserDefinition(userRetrieveService);
            return user.TenantId.ToString(); // Return the TenantId as string
        }
        //[HttpPost]
        //public CheckSubscriptionResponse CheckSubscription(CheckSubscriptionRequest request, IUnitOfWork uow, [FromServices] IUserRetrieveService userRetrieveService)
        //{
        //    var user = (UserDefinition)User.GetUserDefinition(userRetrieveService);
        //    var tenantId = user.TenantId;

        //    // Ensure TenantId is not null
        //    if (tenantId == null)
        //        throw new ArgumentNullException(nameof(request.TenantId));

        //    request.TenantId = tenantId;

        //    var subscription = uow.Connection.Query<SubscriptionRow>(
        //                         "SELECT * FROM Subscription WHERE TenantId = @tenantId AND IsActive = 1",
        //                         new { tenantId }).FirstOrDefault();

        //    // If no active subscription is found, return inactive status
        //    if (subscription == null)
        //        return new CheckSubscriptionResponse { IsActive = false };

        //    return new CheckSubscriptionResponse
        //    {
        //        IsActive = true,
        //        EndDate = subscription.EndDate,
        //        CurrentBalanceUnits = (int)subscription.CurrentBalanceUnits,
        //        TenantId = tenantId
        //    };
        //}

        [HttpPost, AuthorizeCreate(typeof(MyRow))]
        public CustomSaveResponse Create(
            IUnitOfWork uow,
            SaveRequest<MyRow> request,
            [FromServices] IBulkEmailFileUploadSaveHandler handler,
            [FromServices] IUserRetrieveService userRetrieveService)
        {
            var response = new CustomSaveResponse();

            try
            {
                // Retrieve TenantId from the logged-in user
                var user = (UserDefinition)User.GetUserDefinition(userRetrieveService);
                var tenantId = user.TenantId;

                // Ensure TenantId is not provided directly in the request
                if (request.Entity.TenantId != null)
                {
                    response.CustomErrorMessage = "TenantId should not be provided directly in the request.";
                    return response;
                }

                // Validate the file path
                if (string.IsNullOrWhiteSpace(request.Entity.FilePath))
                {
                    response.CustomErrorMessage = "File path is required.";
                    return response;
                }

                // Set TenantId from user context
                request.Entity.TenantId = tenantId;

                // Check for an active subscription
                var subscription = uow.Connection.Query<SubscriptionRow>(
                        "SELECT * FROM Subscription WHERE ApplicationTenantId = @tenantId AND IsActive = 1",
                        new { tenantId }).FirstOrDefault();

                if (subscription == null)
                {
                    response.CustomErrorMessage = "No active subscription found for the given tenant.";
                    return response;
                }

                // Check subscription validity
                if (DateTime.UtcNow > subscription.EndDate)
                {
                    response.CustomErrorMessage = "Subscription has expired. Please renew to continue.";
                    return response;
                }
                if(subscription.CurrentBalanceUnits<=100)
                {
                    response.CustomWarningMessage = "Current Unit Balance should be Less Than 100";
                  
                }
                // Save the entity
                var saveResponse = handler.Create(uow, request);

                // Process the uploaded file
                var bulkEmailData = _bulkEmailService.ReadBulkEmailData(
                        request.Entity.FilePath, tenantId, user.UserId);

                // Insert email notification data
                _emailNotificationService.InsertIntoEmailNotification(
                    bulkEmailData, uow, (long)saveResponse.EntityId);

                //response.CustomErrorMessage = "Records saved successfully.";

                return response;
            }
            catch (Exception ex)
            {
                response.CustomErrorMessage = $"An unexpected error occurred: {ex.Message}";
                return response;
            }
        }


        [HttpPost]
        public ServiceResponse StopEmailNotifications(IDbConnection connection, StopEmailNotificationsRequest request)
        {

            var emailNotifications = connection.List<EmailNotificationRow>(
    new Criteria("BulkEmailSenderId") == request.BulkEmailSenderId &
    new Criteria("IsActive") == 1);


            foreach (var emailNotification in emailNotifications)
            {
                emailNotification.IsActive = false;

               

                connection.UpdateById(emailNotification);
            }
            var bulkEmailRecord = connection.First<BulkEmailFileUploadRow>(new Criteria("Id") == request.BulkEmailSenderId);

            if (bulkEmailRecord != null)
            {
                bulkEmailRecord.IsStopped = true;

                connection.UpdateById(bulkEmailRecord);
            }
           
            


                return new StopEmailNotificationResponse
            {
                Success = true,
                Message = "Email notifications have been stopped."
            };
        }
        [HttpPost, AuthorizeUpdate(typeof(MyRow))]
        public ServiceResponse ToggleActiveStatus(IDbConnection connection, ToggleIsActiveRequest request)
        {
            var record = connection.TryById<BulkEmailFileUploadRow>(request.BulkEmailFileId);
            if (record == null)
                throw new ValidationError("Record not found!");

            record.IsActive = request.IsActive;
            connection.UpdateById(record);

            return new ServiceResponse();
        }
        [HttpPost, AuthorizeUpdate(typeof(MyRow))]
        public SaveResponse Update(IUnitOfWork uow, SaveRequest<MyRow> request,
            [FromServices] IBulkEmailFileUploadSaveHandler handler)
        {
            return handler.Update(uow, request);
        }
 
        [HttpPost, AuthorizeDelete(typeof(MyRow))]
        public DeleteResponse Delete(IUnitOfWork uow, DeleteRequest request,
            [FromServices] IBulkEmailFileUploadDeleteHandler handler)
        {
            return handler.Delete(uow, request);
        }

        [HttpPost]
        public RetrieveResponse<MyRow> Retrieve(IDbConnection connection, RetrieveRequest request,
            [FromServices] IBulkEmailFileUploadRetrieveHandler handler)
        {
          
            return handler.Retrieve(connection, request);
        }
        private string GetFileUrl(string filePath)
        {
            // Construct the file URL from the file path
            return $"{Request.Scheme}://{Request.Host}{filePath}";
        }

        [HttpPost]
        public ListResponse<MyRow> List(IDbConnection connection, ListRequest request,
            [FromServices] IBulkEmailFileUploadListHandler handler)
        {
            return handler.List(connection, request);
        }
       
        public FileContentResult ListExcel(IDbConnection connection, ListRequest request,
            [FromServices] IBulkEmailFileUploadListHandler handler,
            [FromServices] IExcelExporter exporter)
        {
            var data = List(connection, request, handler).Entities;
            var bytes = exporter.Export(data, typeof(Columns.BulkEmailFileUploadColumns), request.ExportColumns);
            return ExcelContentResult.Create(bytes, "BulkEmailSenderList_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture) + ".xlsx");
        }
        [HttpPost]
        public FileContentResult DownloadFileTemplate(IDbConnection connection, ListRequest request,
          [FromServices] IBulkEmailFileUploadListHandler handler,
          [FromServices] IExcelExporter exporter)
        {

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "App_Data\\upload", "File_Template.xlsx");

            var fileBytes = System.IO.File.ReadAllBytes(filePath);



            return ExcelContentResult.Create(fileBytes, "FileTemplateDownload_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture) + ".xlsx");
        }
    }
}