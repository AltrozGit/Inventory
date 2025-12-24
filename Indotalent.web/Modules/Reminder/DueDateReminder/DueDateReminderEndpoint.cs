using Indotalent.Web.Modules.Reminder;
using Indotalent.Web.Modules.Reminder.BulkEmailFileUpload;
using Indotalent.Web.Modules.Reminder.DueDateReminder.RequestHandlers;
using Indotalent.Web.Modules.Reminder.DueDateReminder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Serenity;
using Serenity.Data;
using Serenity.Reporting;
using Serenity.Services;
using Serenity.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Net.Mail;
using System.Threading.Tasks;
using MyRow = Indotalent.Reminder.DueDateReminderRow;

namespace Indotalent.Reminder.Endpoints
{
    [Route("Services/Reminder/DueDateReminder/[action]")]
    [ConnectionKey(typeof(MyRow)), ServiceAuthorize(typeof(MyRow))]
    public class DueDateReminderController : ServiceEndpoint
    {
        private readonly IConfiguration configuration;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public DueDateReminderController(IWebHostEnvironment webHostEnvironment,IConfiguration _configuration)
        {
            _webHostEnvironment = webHostEnvironment;
            configuration = _configuration;

        }
        [HttpPost]
        public TenantDetailsResponse GetTenantDetails(IDbConnection connection, TenantDetailsRequest request,
            [FromServices] ITenantDetailsHandler handler)
        {
            return handler.GetTenantDetails(connection, request);
        }
        [HttpPost, AuthorizeCreate(typeof(MyRow))]
        public SaveResponse Create(IUnitOfWork uow, SaveRequest<MyRow> request,
         [FromServices] IDueDateReminderSaveHandler handler)
        {
            var response = ValidateReminderDates(request);

            if (!string.IsNullOrEmpty(response.CustomErrorMessage))
            {
                return response; // Return early if validation failed
            }

            // Proceed with the save handler logic
            var saveResponse = handler.Create(uow, request);

            // Handle attachments if any
            ProcessAttachments(request.Entity, uow);

            return saveResponse;
        }

        private CustomSaveResponse ValidateReminderDates(SaveRequest<MyRow> request)
        {
            var response = new CustomSaveResponse();

            var reminder1 = request.Entity.Remainder1;
            var reminder2 = request.Entity.Remainder2;
            var consentDueDate = request.Entity.ConsentDueDate;

            if (consentDueDate != null)
            {
                if (reminder1 != null && reminder1 >= consentDueDate)
                {
                    response.CustomErrorMessage = "Reminder1 must be earlier than Consent Due Date.";
                    return response;
                }

                if (reminder2 != null && reminder2 >= consentDueDate)
                {
                    response.CustomErrorMessage = "Reminder2 must be earlier than Consent Due Date.";
                    return response;
                }
            }

            return response;
        }

        private void ProcessAttachments(MyRow entity, IUnitOfWork uow)
        {
            var attachments = entity.Attachment;

            if (!string.IsNullOrWhiteSpace(attachments))
            {
                var basePath = Path.Combine(_webHostEnvironment.ContentRootPath);
                var uploadPath = configuration["UploadSettings:Path"];
                var fullAttachmentPath = Path.Combine(basePath, uploadPath, attachments);

                var sanitizedAttachmentPath = fullAttachmentPath
                    .Replace("~", "")
                    .Replace("/", Path.DirectorySeparatorChar.ToString())
                    .Replace("\\\\", "\\")
                    .Replace("\\temporary", ""); // Remove "temporary" part from the path

                entity.Attachment = sanitizedAttachmentPath;

                uow.Connection.UpdateById(entity); // Update the entity with sanitized attachment path
            }
        }



        [HttpPost, AuthorizeUpdate(typeof(MyRow))]
        public SaveResponse Update(IUnitOfWork uow, SaveRequest<MyRow> request,
            [FromServices] IDueDateReminderSaveHandler handler)
        {
          
            return handler.Update(uow, request);
        }
 
        [HttpPost, AuthorizeDelete(typeof(MyRow))]
        public DeleteResponse Delete(IUnitOfWork uow, DeleteRequest request,
            [FromServices] IDueDateReminderDeleteHandler handler)
        {
            return handler.Delete(uow, request);
        }

        [HttpPost]
        public RetrieveResponse<MyRow> Retrieve(IDbConnection connection, RetrieveRequest request,
            [FromServices] IDueDateReminderRetrieveHandler handler)
        {
            return handler.Retrieve(connection, request);
        }

        [HttpPost]
        public ListResponse<MyRow> List(IDbConnection connection, ListRequest request,
            [FromServices] IDueDateReminderListHandler handler)
        {
            return handler.List(connection, request);
        }

        public FileContentResult ListExcel(IDbConnection connection, ListRequest request,
            [FromServices] IDueDateReminderListHandler handler,
            [FromServices] IExcelExporter exporter)
        {
            var data = List(connection, request, handler).Entities;
            var bytes = exporter.Export(data, typeof(Columns.DueDateReminderColumns), request.ExportColumns);
            return ExcelContentResult.Create(bytes, "DueDateReminderList_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture) + ".xlsx");
        }
    }
}