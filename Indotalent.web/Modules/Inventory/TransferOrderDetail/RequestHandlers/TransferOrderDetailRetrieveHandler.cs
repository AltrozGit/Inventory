using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Indotalent.Inventory.TransferOrderDetailRow>;
using MyRow = Indotalent.Inventory.TransferOrderDetailRow;

namespace Indotalent.Inventory
{
    public interface ITransferOrderDetailRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class TransferOrderDetailRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, ITransferOrderDetailRetrieveHandler
    {
        public TransferOrderDetailRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}