using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Indotalent.Inventory.LocationRow>;
using MyRow = Indotalent.Inventory.LocationRow;

namespace Indotalent.Inventory
{
    public interface ILocationListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class LocationListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, ILocationListHandler
    {
        public LocationListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}