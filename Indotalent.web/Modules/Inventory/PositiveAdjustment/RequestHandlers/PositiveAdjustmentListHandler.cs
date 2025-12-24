using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Indotalent.Inventory.PositiveAdjustmentRow>;
using MyRow = Indotalent.Inventory.PositiveAdjustmentRow;

namespace Indotalent.Inventory
{
    public interface IPositiveAdjustmentListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class PositiveAdjustmentListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IPositiveAdjustmentListHandler
    {
        public PositiveAdjustmentListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}