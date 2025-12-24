using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Indotalent.Reminder.SmtpConfigurationRow>;
using MyRow = Indotalent.Reminder.SmtpConfigurationRow;

namespace Indotalent.Reminder
{
    public interface ISmtpConfigurationListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class SmtpConfigurationListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, ISmtpConfigurationListHandler
    {
        public SmtpConfigurationListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}