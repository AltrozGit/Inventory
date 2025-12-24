using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = Indotalent.Inventory.ShipperRow;

namespace Indotalent.Inventory
{
    public interface IShipperDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class ShipperDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IShipperDeleteHandler
    {
        public ShipperDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}