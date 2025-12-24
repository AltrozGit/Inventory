using Indotalent.Administration;
using Serenity;
using Serenity.Data;
using Serenity.Services;
using Serilog;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<Indotalent.Reminder.PlanRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Indotalent.Reminder.PlanRow;

namespace Indotalent.Reminder
{
    public interface IPlanSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> { }

    public class PlanSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IPlanSaveHandler
    {
        public PlanSaveHandler(IRequestContext context)
             : base(context)
        {
        }
        
    }
}
