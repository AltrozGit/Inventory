using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Indotalent.Reminder.DueDateReminderRow>;
using MyRow = Indotalent.Reminder.DueDateReminderRow;

namespace Indotalent.Reminder
{
    public interface IDueDateReminderRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class DueDateReminderRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IDueDateReminderRetrieveHandler
    {
        public DueDateReminderRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}