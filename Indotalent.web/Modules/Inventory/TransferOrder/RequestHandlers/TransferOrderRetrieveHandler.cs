using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Indotalent.Inventory.TransferOrderRow>;
using MyRow = Indotalent.Inventory.TransferOrderRow;

namespace Indotalent.Inventory
{
    public interface ITransferOrderRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class TransferOrderRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, ITransferOrderRetrieveHandler
    {
        public TransferOrderRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}