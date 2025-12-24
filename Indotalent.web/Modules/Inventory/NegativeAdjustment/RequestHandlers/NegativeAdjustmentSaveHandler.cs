using Indotalent.Administration;
using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<Indotalent.Inventory.NegativeAdjustmentRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Indotalent.Inventory.NegativeAdjustmentRow;

namespace Indotalent.Inventory
{
    public interface INegativeAdjustmentSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class NegativeAdjustmentSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, INegativeAdjustmentSaveHandler
    {
        public NegativeAdjustmentSaveHandler(IRequestContext context)
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
                        Prefix = tenant.NegativeAdjustmentNumberUseDate.Value ? tenant.NegativeAdjustmentNumberPrefix + "/" + DateTime.Now.ToString("yyyyMMdd") : tenant.NegativeAdjustmentNumberPrefix,
                        Length = tenant.NegativeAdjustmentNumberLength.Value
                    };
                    var respone = MultiTenantHelper.GetNextNumber(UnitOfWork.Connection, request, MyRow.Fields.Number, tenant.TenantId);
                    Row.Number = respone.Serial;
                }

            }
        }
    }
}