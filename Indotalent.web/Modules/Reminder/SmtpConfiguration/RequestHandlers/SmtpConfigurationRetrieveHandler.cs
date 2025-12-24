using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Indotalent.Reminder.SmtpConfigurationRow>;
using MyRow = Indotalent.Reminder.SmtpConfigurationRow;

namespace Indotalent.Reminder
{
    public interface ISmtpConfigurationRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class SmtpConfigurationRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, ISmtpConfigurationRetrieveHandler
    {
        public SmtpConfigurationRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}