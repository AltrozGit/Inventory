using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<Indotalent.Inventory.LocationRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Indotalent.Inventory.LocationRow;

namespace Indotalent.Inventory
{
    public interface ILocationSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class LocationSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, ILocationSaveHandler
    {
        public LocationSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}