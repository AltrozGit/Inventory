using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Indotalent.Reminder.PlanSettingRow>;
using MyRow = Indotalent.Reminder.PlanSettingRow;

namespace Indotalent.Reminder
{
    public interface IPlanSettingRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class PlanSettingRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IPlanSettingRetrieveHandler
    {
        public PlanSettingRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}