using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = Indotalent.Reminder.DueDateReminderRow;

namespace Indotalent.Reminder
{
    public interface IDueDateReminderDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class DueDateReminderDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IDueDateReminderDeleteHandler
    {
        public DueDateReminderDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}