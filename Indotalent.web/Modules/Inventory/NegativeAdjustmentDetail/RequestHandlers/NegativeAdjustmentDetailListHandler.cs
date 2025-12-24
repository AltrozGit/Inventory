using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Indotalent.Inventory.NegativeAdjustmentDetailRow>;
using MyRow = Indotalent.Inventory.NegativeAdjustmentDetailRow;

namespace Indotalent.Inventory
{
    public interface INegativeAdjustmentDetailListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class NegativeAdjustmentDetailListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, INegativeAdjustmentDetailListHandler
    {
        public NegativeAdjustmentDetailListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}