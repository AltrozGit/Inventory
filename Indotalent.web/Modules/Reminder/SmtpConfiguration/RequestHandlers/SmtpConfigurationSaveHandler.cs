using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using static Indotalent.Web.Modules.Reminder.BulkEmailSender.RequestHandlers.BulkEmailAvailabilityHandler;
using MyRequest = Serenity.Services.SaveRequest<Indotalent.Reminder.SmtpConfigurationRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Indotalent.Reminder.SmtpConfigurationRow;

namespace Indotalent.Reminder
{
    public interface ISmtpConfigurationSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> { }

    public class SmtpConfigurationSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, ISmtpConfigurationSaveHandler
    {
        public SmtpConfigurationSaveHandler(IRequestContext context)
             : base(context)
        {
        }

        protected override void BeforeSave()
        {
            base.BeforeSave();

            // Only check for existence if it's an insert operation
            if (IsCreate)
            {
                // Use TryFirst to check if a record with the same UserName and FromAddress exists
                var existingRecord = this.Connection.TryFirst<MyRow>(
                    new Criteria(MyRow.Fields.UserName) == Row.UserName &
                    new Criteria(MyRow.Fields.FromAddress) == Row.FromAddress);

                // If a record exists, throw a validation error
                if (existingRecord != null)
                {
                    throw new ValidationError("RecordExists", "SMTP Configuration",
                        "An SMTP configuration with the same Username and FromAddress already exists.");
                }
            }
            if (Row.IsDefault == true)
            {
                var existingDefault = this.Connection.TryFirst<MyRow>(
      new Criteria(MyRow.Fields.IsDefault) == 1 & // Compare Boolean to 1 (true)
      new Criteria(MyRow.Fields.Id) != Row.Id.Value); // Ensure Row.Id is not null


                if (existingDefault != null)
                {
                    // Update the existing default record to set IsDefault to false
                    existingDefault.IsDefault = false;
                    this.Connection.UpdateById(existingDefault);
                }
            }

        }

    }
}
