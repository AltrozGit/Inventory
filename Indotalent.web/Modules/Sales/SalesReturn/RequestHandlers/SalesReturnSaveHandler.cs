using Indotalent.Administration;
using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<Indotalent.Sales.SalesReturnRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Indotalent.Sales.SalesReturnRow;

namespace Indotalent.Sales
{
    public interface ISalesReturnSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class SalesReturnSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, ISalesReturnSaveHandler
    {
        public SalesReturnSaveHandler(IRequestContext context)
             : base(context)
        {
        }


        private string GetSalesGroup(int salesDeliveryId, IDbConnection connection)
        {
            var result = "";

            var data = connection.TryById<SalesDeliveryRow>(salesDeliveryId, q => q
                 .SelectTableFields());

            result = data.SalesGroup;

            return result;
        }

        protected override void BeforeSave()
        {
            base.BeforeSave();

            Row.TotalQtyReturn = 0;
            foreach (var item in Row.ItemList)
            {
                Row.TotalQtyReturn += item.QtyReturn;
            }

            if (this.IsCreate)
            {
                if (Row.Number.ToLower().Equals("auto"))
                {
                    var tenant = UnitOfWork.Connection.ById<TenantRow>(Row.TenantId);
                    var request = new GetNextNumberRequest()
                    {
                        Prefix = tenant.SalesReturnNumberUseDate.Value ? tenant.SalesReturnNumberPrefix + "/" + DateTime.Now.ToString("yyyyMMdd") : tenant.SalesReturnNumberPrefix,
                        Length = tenant.SalesReturnNumberLength.Value
                    };
                    var respone = MultiTenantHelper.GetNextNumber(UnitOfWork.Connection, request, MyRow.Fields.Number, tenant.TenantId);
                    Row.Number = respone.Serial;
                    Row.SalesGroup = GetSalesGroup(Row.SalesDeliveryId.Value, UnitOfWork.Connection);
                }

            }
        }
    }
}
