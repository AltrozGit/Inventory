using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Indotalent.Inventory.WarehouseRow>;
using MyRow = Indotalent.Inventory.WarehouseRow;

namespace Indotalent.Inventory
{
    public interface IWarehouseRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class WarehouseRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IWarehouseRetrieveHandler
    {
        public WarehouseRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}