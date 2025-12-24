using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Indotalent.Inventory.TransferOrderDetailRow>;
using MyRow = Indotalent.Inventory.TransferOrderDetailRow;

namespace Indotalent.Inventory
{
    public interface ITransferOrderDetailListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class TransferOrderDetailListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, ITransferOrderDetailListHandler
    {
        public TransferOrderDetailListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}