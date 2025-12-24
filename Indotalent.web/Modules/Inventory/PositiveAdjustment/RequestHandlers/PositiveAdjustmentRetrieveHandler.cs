using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Indotalent.Inventory.PositiveAdjustmentRow>;
using MyRow = Indotalent.Inventory.PositiveAdjustmentRow;

namespace Indotalent.Inventory
{
    public interface IPositiveAdjustmentRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class PositiveAdjustmentRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IPositiveAdjustmentRetrieveHandler
    {
        public PositiveAdjustmentRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}