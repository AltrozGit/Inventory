using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Indotalent.Inventory.TransferOrderRow>;
using MyRow = Indotalent.Inventory.TransferOrderRow;

namespace Indotalent.Inventory
{
    public interface ITransferOrderListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class TransferOrderListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, ITransferOrderListHandler
    {
        public TransferOrderListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}