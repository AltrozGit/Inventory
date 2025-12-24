using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Indotalent.Reminder.PlanRow>;
using MyRow = Indotalent.Reminder.PlanRow;

namespace Indotalent.Reminder
{
    public interface IPlanRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class PlanRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IPlanRetrieveHandler
    {
        public PlanRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}