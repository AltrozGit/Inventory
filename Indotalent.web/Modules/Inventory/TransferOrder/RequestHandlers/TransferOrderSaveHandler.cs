using Indotalent.Administration;
using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<Indotalent.Inventory.TransferOrderRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Indotalent.Inventory.TransferOrderRow;

namespace Indotalent.Inventory
{
    public interface ITransferOrderSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class TransferOrderSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, ITransferOrderSaveHandler
    {
        public TransferOrderSaveHandler(IRequestContext context)
             : base(context)
        {
        }
        protected override void BeforeSave()
        {
            base.BeforeSave();

            Row.TotalQty = 0;
            foreach (var item in Row.ItemList)
            {
                Row.TotalQty += item.Qty;
            }

            if (this.IsCreate)
            {
                if (Row.Number.ToLower().Equals("auto"))
                {
                    var tenant = UnitOfWork.Connection.ById<TenantRow>(Row.TenantId);
                    var request = new GetNextNumberRequest()
                    {
                        Prefix = tenant.TransferOrderNumberUseDate.Value ? tenant.TransferOrderNumberPrefix + "/" + DateTime.Now.ToString("yyyyMMdd") : tenant.TransferOrderNumberPrefix,
                        Length = tenant.TransferOrderNumberLength.Value
                    };
                    var respone = MultiTenantHelper.GetNextNumber(UnitOfWork.Connection, request, MyRow.Fields.Number, tenant.TenantId);
                    Row.Number = respone.Serial;
                }

            }
        }
    }
}