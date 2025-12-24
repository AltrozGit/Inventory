using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = Indotalent.Inventory.WarehouseRow;

namespace Indotalent.Inventory
{
    public interface IWarehouseDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class WarehouseDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IWarehouseDeleteHandler
    {
        public WarehouseDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}