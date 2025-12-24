using Indotalent.Administration;
using Indotalent.Material;
using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using System.Linq;
using MyRequest = Serenity.Services.SaveRequest<Indotalent.Purchase.PurchaseReturnRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Indotalent.Purchase.PurchaseReturnRow;

namespace Indotalent.Purchase
{
    public interface IPurchaseReturnSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class PurchaseReturnSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IPurchaseReturnSaveHandler
    {
        public PurchaseReturnSaveHandler(IRequestContext context)
             : base(context)
        {
        }

        private string GetProcurement(int purchaseReceiptId, IDbConnection connection)
        {
            var result = "";

            var data = connection.TryById<PurchaseReceiptRow>(purchaseReceiptId, q => q
                 .SelectTableFields());

            result = data.ProcurementGroup;

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
                        Prefix = tenant.PurchaseReturnNumberUseDate.Value ? tenant.PurchaseReturnNumberPrefix + "/" + DateTime.Now.ToString("yyyyMMdd") : tenant.PurchaseReturnNumberPrefix,
                        Length = tenant.PurchaseReturnNumberLength.Value
                    };
                    var respone = MultiTenantHelper.GetNextNumber(UnitOfWork.Connection, request, MyRow.Fields.Number, tenant.TenantId);
                    Row.Number = respone.Serial;
                    Row.ProcurementGroup = GetProcurement(Row.PurchaseReceiptId.Value, UnitOfWork.Connection);
                }

            }
        }

        protected override void AfterSave()
        {
            base.AfterSave();

            // Fetch the MaterialRequestId from the PurchaseOrder
            var purchaseReceiptId = Row.PurchaseReceiptId;

            if (purchaseReceiptId == null)
            {
                throw new Exception("purchaseReceiptId is missing in the PurchaseReturn.");
            }

            
            // Iterate through each item in the PurchaseOrderDetail
            foreach (var item in Row.ItemList)
            {
               



                // Fetch all Request rows associated with the MaterialRequestId
                var requests = UnitOfWork.Connection.List<PurchaseReceiptRow>(
                    new Criteria(RequestRow.Fields.Id) == purchaseReceiptId.Value
                );

                if (requests == null || requests.Count == 0)
                {
                    throw new Exception($"No Request rows found for purchaseReceiptId {purchaseReceiptId}.");
                }

               
                foreach (var request in requests)
                {


                    if (request.IsPReturnCreated != true)
                    {
                        // Update the flag
                        request.IsPReturnCreated = true;

                        // Save the update back to the database
                        UnitOfWork.Connection.UpdateById(request);
                    }
                }
            }
        }



    }
}
