using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = Indotalent.Reminder.PlanRow;

namespace Indotalent.Reminder
{
    public interface IPlanDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class PlanDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IPlanDeleteHandler
    {
        public PlanDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}