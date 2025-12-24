using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Indotalent.Inventory.PositiveAdjustmentDetailRow>;
using MyRow = Indotalent.Inventory.PositiveAdjustmentDetailRow;

namespace Indotalent.Inventory
{
    public interface IPositiveAdjustmentDetailListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class PositiveAdjustmentDetailListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IPositiveAdjustmentDetailListHandler
    {
        public PositiveAdjustmentDetailListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}