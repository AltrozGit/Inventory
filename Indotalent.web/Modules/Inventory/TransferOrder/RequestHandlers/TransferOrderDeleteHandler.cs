using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = Indotalent.Inventory.TransferOrderRow;

namespace Indotalent.Inventory
{
    public interface ITransferOrderDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class TransferOrderDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, ITransferOrderDeleteHandler
    {
        public TransferOrderDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}