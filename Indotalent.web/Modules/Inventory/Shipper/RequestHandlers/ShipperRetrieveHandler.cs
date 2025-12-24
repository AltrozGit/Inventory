using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Indotalent.Inventory.ShipperRow>;
using MyRow = Indotalent.Inventory.ShipperRow;

namespace Indotalent.Inventory
{
    public interface IShipperRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class ShipperRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IShipperRetrieveHandler
    {
        public ShipperRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}