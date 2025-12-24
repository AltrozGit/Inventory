using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.IO;
using System.Threading.Tasks;
using MyRequest = Serenity.Services.SaveRequest<Indotalent.Reminder.DueDateReminderRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Indotalent.Reminder.DueDateReminderRow;

namespace Indotalent.Reminder
{
    public interface IDueDateReminderSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> { }

    public class DueDateReminderSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IDueDateReminderSaveHandler
    {
        public DueDateReminderSaveHandler(IRequestContext context)
            : base(context)
        {
        }

        protected override void BeforeSave()
        {
            base.BeforeSave();
            if (IsCreate || IsUpdate)
            {
                if (Row.CustomerId != null)
                {
                    var customerName = Connection.ById<Sales.CustomerRow>(Row.CustomerId.Value)?.Name;
                    Row.CustomerName = customerName;
                }
            }
        }

            //    //// Ensure the file is uploaded via the form's file input
            //    //var uploadedFile = Request.Entity.Attachment; // Adjust this according to your actual file input handling

            //    //if (!string.IsNullOrEmpty(uploadedFile))
            //    //{
            //    //    // Assume uploadedFile is a file name or relative path
            //    //    var filePath = Path.Combine(AppContext.BaseDirectory, "App_Data", "upload", "Emails", uploadedFile);

            //    //    // Ensure the directory exists
            //    //    var directoryPath = Path.GetDirectoryName(filePath);
            //    //    if (!Directory.Exists(directoryPath))
            //    //    {
            //    //        Directory.CreateDirectory(directoryPath);
            //    //    }


            //    //    Row.Attachment = filePath; // Save the relative or full path to the database
            //    }
            //}
        }
}

