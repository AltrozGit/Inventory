using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = Indotalent.Inventory.PositiveAdjustmentDetailRow;

namespace Indotalent.Inventory
{
    public interface IPositiveAdjustmentDetailDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class PositiveAdjustmentDetailDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IPositiveAdjustmentDetailDeleteHandler
    {
        public PositiveAdjustmentDetailDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}