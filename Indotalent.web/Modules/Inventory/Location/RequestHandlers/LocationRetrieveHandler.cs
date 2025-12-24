using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Indotalent.Inventory.LocationRow>;
using MyRow = Indotalent.Inventory.LocationRow;

namespace Indotalent.Inventory
{
    public interface ILocationRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class LocationRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, ILocationRetrieveHandler
    {
        public LocationRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}