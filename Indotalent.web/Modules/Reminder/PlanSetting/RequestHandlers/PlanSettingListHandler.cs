using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Indotalent.Reminder.PlanSettingRow>;
using MyRow = Indotalent.Reminder.PlanSettingRow;

namespace Indotalent.Reminder
{
    public interface IPlanSettingListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class PlanSettingListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IPlanSettingListHandler
    {
        public PlanSettingListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}