using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Indotalent.Inventory.NegativeAdjustmentRow>;
using MyRow = Indotalent.Inventory.NegativeAdjustmentRow;

namespace Indotalent.Inventory
{
    public interface INegativeAdjustmentRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class NegativeAdjustmentRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, INegativeAdjustmentRetrieveHandler
    {
        public NegativeAdjustmentRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}