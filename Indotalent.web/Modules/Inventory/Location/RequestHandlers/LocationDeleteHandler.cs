using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = Indotalent.Inventory.LocationRow;

namespace Indotalent.Inventory
{
    public interface ILocationDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class LocationDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, ILocationDeleteHandler
    {
        public LocationDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}