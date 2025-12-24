using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = Indotalent.Reminder.SmtpConfigurationRow;

namespace Indotalent.Reminder
{
    public interface ISmtpConfigurationDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class SmtpConfigurationDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, ISmtpConfigurationDeleteHandler
    {
        public SmtpConfigurationDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}