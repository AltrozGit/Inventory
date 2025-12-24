using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = Indotalent.Inventory.NegativeAdjustmentDetailRow;

namespace Indotalent.Inventory
{
    public interface INegativeAdjustmentDetailDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class NegativeAdjustmentDetailDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, INegativeAdjustmentDetailDeleteHandler
    {
        public NegativeAdjustmentDetailDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}