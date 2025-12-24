using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Indotalent.Reminder.DueDateReminderRow>;
using MyRow = Indotalent.Reminder.DueDateReminderRow;

namespace Indotalent.Reminder
{
    public interface IDueDateReminderListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class DueDateReminderListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IDueDateReminderListHandler
    {
        public DueDateReminderListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}