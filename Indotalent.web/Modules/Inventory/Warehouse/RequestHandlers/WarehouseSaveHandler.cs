using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<Indotalent.Inventory.WarehouseRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Indotalent.Inventory.WarehouseRow;

namespace Indotalent.Inventory
{
    public interface IWarehouseSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class WarehouseSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IWarehouseSaveHandler
    {
        public WarehouseSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}