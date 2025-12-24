using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<Indotalent.Inventory.NegativeAdjustmentDetailRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Indotalent.Inventory.NegativeAdjustmentDetailRow;

namespace Indotalent.Inventory
{
    public interface INegativeAdjustmentDetailSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class NegativeAdjustmentDetailSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, INegativeAdjustmentDetailSaveHandler
    {
        public NegativeAdjustmentDetailSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}