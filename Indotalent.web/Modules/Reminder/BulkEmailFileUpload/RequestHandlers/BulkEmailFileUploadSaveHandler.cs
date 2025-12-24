using Indotalent.Administration;
using Indotalent.Reminder.Endpoints;
using Indotalent.Web.Modules.Reminder.BulkEmailFileUpload;

using Indotalent.Web.Modules.Reminder.EmailNotification;

using Microsoft.Data.SqlClient;
using Serenity;
using Serenity.Abstractions;
using Serenity.Data;
using Serenity.Services;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using static MVC.Views.Administration;
using MyRequest = Serenity.Services.SaveRequest<Indotalent.Reminder.BulkEmailFileUploadRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Indotalent.Reminder.BulkEmailFileUploadRow;

namespace Indotalent.Reminder
{

    public interface IBulkEmailFileUploadSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> { }

    public class BulkEmailFileUploadSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IBulkEmailFileUploadSaveHandler
    {
        protected IUserAccessor UserAccessor { get; }
        private IUserRetrieveService UserRetriever { get; }
        private readonly EmailNotificationService _emailNotificationService;
        private readonly BulkEmailService _bulkEmailService;
        

        public BulkEmailFileUploadSaveHandler(IRequestContext context, EmailNotificationService emailNotificationService, BulkEmailService bulkEmailService)
            : base(context)
        {
            _emailNotificationService = emailNotificationService;
            _bulkEmailService = bulkEmailService;
            
        }

        protected override void AfterSave()
        {
            base.AfterSave();

            
            // Continue processing if the subscription is valid
            if (Row.Id == null)
            {
                // Check if the file path is set
                if (!string.IsNullOrEmpty(Row.FilePath))
                {
                    // Read bulk email data from the file
                    var bulkEmailData = _bulkEmailService.ReadBulkEmailData(Row.FilePath, (int)Row.TenantId, (int)Row.InsertUserId);

                    // Insert into EmailNotification table with the foreign key
                    _emailNotificationService.InsertIntoEmailNotification((System.Collections.Generic.IEnumerable<MyRow>)bulkEmailData, this.UnitOfWork, Row.Id.Value);
                }
            }
        }

        protected override void BeforeSave()
        {
            base.BeforeSave();

            if (this.IsCreate)
            {
                if (Row.Title.ToLower().Equals("auto"))
                {
                    var tenant = UnitOfWork.Connection.ById<TenantRow>(Row.TenantId);

                    string prefix = tenant.BulkFileUploadNumberPrefix;

                    if (tenant.BulkFileUploadNumberUseDate.HasValue && tenant.BulkFileUploadNumberUseDate.Value)
                    {
                        prefix += "_" + DateTime.Now.ToString("yyyyMMdd_HHmm");
                    }

                    Row.Title = prefix;
                }
            }
        }
    }
}