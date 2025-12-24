using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Indotalent.Inventory.ShipperRow>;
using MyRow = Indotalent.Inventory.ShipperRow;

namespace Indotalent.Inventory
{
    public interface IShipperListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class ShipperListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IShipperListHandler
    {
        public ShipperListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}