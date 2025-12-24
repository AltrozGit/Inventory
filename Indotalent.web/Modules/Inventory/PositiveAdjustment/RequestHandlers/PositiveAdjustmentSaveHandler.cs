using Indotalent.Administration;
using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<Indotalent.Inventory.PositiveAdjustmentRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Indotalent.Inventory.PositiveAdjustmentRow;

namespace Indotalent.Inventory
{
    public interface IPositiveAdjustmentSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class PositiveAdjustmentSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IPositiveAdjustmentSaveHandler
    {
        public PositiveAdjustmentSaveHandler(IRequestContext context)
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
                        Prefix = tenant.PositiveAdjustmentNumberUseDate.Value ? tenant.PositiveAdjustmentNumberPrefix + "/" + DateTime.Now.ToString("yyyyMMdd") : tenant.PositiveAdjustmentNumberPrefix,
                        Length = tenant.PositiveAdjustmentNumberLength.Value
                    };
                    var respone = MultiTenantHelper.GetNextNumber(UnitOfWork.Connection, request, MyRow.Fields.Number, tenant.TenantId);
                    Row.Number = respone.Serial;
                }

            }
        }
    }
}