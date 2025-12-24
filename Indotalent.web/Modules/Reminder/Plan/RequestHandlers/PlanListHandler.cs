using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Indotalent.Reminder.PlanRow>;
using MyRow = Indotalent.Reminder.PlanRow;

namespace Indotalent.Reminder
{
    public interface IPlanListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class PlanListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IPlanListHandler
    {
        public PlanListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}