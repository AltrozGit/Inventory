using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = Indotalent.Reminder.PlanSettingRow;

namespace Indotalent.Reminder
{
    public interface IPlanSettingDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class PlanSettingDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IPlanSettingDeleteHandler
    {
        public PlanSettingDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}