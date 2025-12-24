using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<Indotalent.Inventory.ShipperRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Indotalent.Inventory.ShipperRow;

namespace Indotalent.Inventory
{
    public interface IShipperSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class ShipperSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IShipperSaveHandler
    {
        public ShipperSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}