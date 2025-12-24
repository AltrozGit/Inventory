using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Indotalent.Inventory.PositiveAdjustmentDetailRow>;
using MyRow = Indotalent.Inventory.PositiveAdjustmentDetailRow;

namespace Indotalent.Inventory
{
    public interface IPositiveAdjustmentDetailRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class PositiveAdjustmentDetailRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IPositiveAdjustmentDetailRetrieveHandler
    {
        public PositiveAdjustmentDetailRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}