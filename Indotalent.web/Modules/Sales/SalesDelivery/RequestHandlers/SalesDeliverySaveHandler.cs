using Indotalent.Administration;
using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<Indotalent.Sales.SalesDeliveryRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Indotalent.Sales.SalesDeliveryRow;

namespace Indotalent.Sales
{
    public interface ISalesDeliverySaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class SalesDeliverySaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, ISalesDeliverySaveHandler
    {
        public SalesDeliverySaveHandler(IRequestContext context)
             : base(context)
        {
        }



        private string GetSalesGroup(int salesOrderId, IDbConnection connection)
        {
            var result = "";

            var data = connection.TryById<SalesOrderRow>(salesOrderId, q => q
                 .SelectTableFields());
            result = data.SalesGroup;

            return result;
        }

        protected override void BeforeSave()
        {
            base.BeforeSave();

            Row.TotalQtyDelivered = 0;
            foreach (var item in Row.ItemList)
            {
                Row.TotalQtyDelivered += item.QtyDelivered;
            }

            if (this.IsCreate)
            {
                if (Row.Number.ToLower().Equals("auto"))
                {
                    var tenant = UnitOfWork.Connection.ById<TenantRow>(Row.TenantId);
                    var request = new GetNextNumberRequest()
                    {
                        Prefix = tenant.SalesDeliveryNumberUseDate.Value ? tenant.SalesDeliveryNumberPrefix + "/" + DateTime.Now.ToString("yyyyMMdd") : tenant.SalesDeliveryNumberPrefix,
                        Length = tenant.SalesDeliveryNumberLength.Value
                    };
                    var respone = MultiTenantHelper.GetNextNumber(UnitOfWork.Connection, request, MyRow.Fields.Number, tenant.TenantId);
                    Row.Number = respone.Serial;
                    Row.SalesGroup = GetSalesGroup(Row.SalesOrderId.Value, UnitOfWork.Connection);
                }

            }
        }
    }
}
