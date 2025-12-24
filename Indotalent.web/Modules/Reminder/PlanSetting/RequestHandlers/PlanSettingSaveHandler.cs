using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<Indotalent.Reminder.PlanSettingRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Indotalent.Reminder.PlanSettingRow;

namespace Indotalent.Reminder
{
    public interface IPlanSettingSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class PlanSettingSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IPlanSettingSaveHandler
    {
        public PlanSettingSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}