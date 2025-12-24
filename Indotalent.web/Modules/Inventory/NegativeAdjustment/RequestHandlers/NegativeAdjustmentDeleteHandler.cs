using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = Indotalent.Inventory.NegativeAdjustmentRow;

namespace Indotalent.Inventory
{
    public interface INegativeAdjustmentDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class NegativeAdjustmentDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, INegativeAdjustmentDeleteHandler
    {
        public NegativeAdjustmentDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}