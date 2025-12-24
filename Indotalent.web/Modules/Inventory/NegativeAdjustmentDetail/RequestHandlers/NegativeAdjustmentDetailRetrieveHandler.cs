using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Indotalent.Inventory.NegativeAdjustmentDetailRow>;
using MyRow = Indotalent.Inventory.NegativeAdjustmentDetailRow;

namespace Indotalent.Inventory
{
    public interface INegativeAdjustmentDetailRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class NegativeAdjustmentDetailRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, INegativeAdjustmentDetailRetrieveHandler
    {
        public NegativeAdjustmentDetailRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}