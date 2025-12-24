using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = Indotalent.Inventory.PositiveAdjustmentRow;

namespace Indotalent.Inventory
{
    public interface IPositiveAdjustmentDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class PositiveAdjustmentDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IPositiveAdjustmentDeleteHandler
    {
        public PositiveAdjustmentDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}