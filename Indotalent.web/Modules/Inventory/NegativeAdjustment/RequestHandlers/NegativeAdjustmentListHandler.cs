using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Indotalent.Inventory.NegativeAdjustmentRow>;
using MyRow = Indotalent.Inventory.NegativeAdjustmentRow;

namespace Indotalent.Inventory
{
    public interface INegativeAdjustmentListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class NegativeAdjustmentListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, INegativeAdjustmentListHandler
    {
        public NegativeAdjustmentListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}