using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = Indotalent.Inventory.TransferOrderDetailRow;

namespace Indotalent.Inventory
{
    public interface ITransferOrderDetailDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class TransferOrderDetailDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, ITransferOrderDetailDeleteHandler
    {
        public TransferOrderDetailDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}