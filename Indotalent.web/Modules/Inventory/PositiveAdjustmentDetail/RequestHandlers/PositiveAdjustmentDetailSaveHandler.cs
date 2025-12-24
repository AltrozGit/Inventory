using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<Indotalent.Inventory.PositiveAdjustmentDetailRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Indotalent.Inventory.PositiveAdjustmentDetailRow;

namespace Indotalent.Inventory
{
    public interface IPositiveAdjustmentDetailSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class PositiveAdjustmentDetailSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IPositiveAdjustmentDetailSaveHandler
    {
        public PositiveAdjustmentDetailSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}