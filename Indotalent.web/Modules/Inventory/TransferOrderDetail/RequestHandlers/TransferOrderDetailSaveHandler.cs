using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<Indotalent.Inventory.TransferOrderDetailRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Indotalent.Inventory.TransferOrderDetailRow;

namespace Indotalent.Inventory
{
    public interface ITransferOrderDetailSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class TransferOrderDetailSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, ITransferOrderDetailSaveHandler
    {
        public TransferOrderDetailSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}