using Indotalent.Administration;
using Indotalent.Material;
using Indotalent.Purchase;
using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using System.Linq;
using MyRequest = Serenity.Services.SaveRequest<Indotalent.Purchase.PurchaseReceiptRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Indotalent.Purchase.PurchaseReceiptRow;

namespace Indotalent.Web.Modules.Purchase.PurchaseReceipt.RequestHandlers
{
    public interface IPurchaseReceiptSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> { }

    public class PurchaseReceiptSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IPurchaseReceiptSaveHandler
    {
        public PurchaseReceiptSaveHandler(IRequestContext context)
             : base(context)
        {
        }

        private string GetProcurement(int purchaseOrderId, IDbConnection connection)
        {
            var result = "";

            var data = connection.TryById<PurchaseOrderRow>(purchaseOrderId, q => q
                 .SelectTableFields());
            result = data.ProcurementGroup;

            //if(data.IsBillGenerated == false)
            //{


            //    throw new Exception("Bill should be  generated before creating Receipt");

            //}


            return result;
        }

        protected override void BeforeSave()
        {
            base.BeforeSave();

            Row.TotalQtyReceive = 0;
            foreach (var item in Row.ItemList)
            {
                Row.TotalQtyReceive += item.QtyReceive;
            }




            if (IsCreate)
            {
                if (Row.Number.ToLower().Equals("auto"))
                {
                    var tenant = UnitOfWork.Connection.ById<TenantRow>(Row.TenantId);
                    var request = new GetNextNumberRequest()
                    {
                        Prefix = tenant.PurchaseReceiptNumberUseDate.Value ? tenant.PurchaseReceiptNumberPrefix + "/" + DateTime.Now.ToString("yyyyMMdd") : tenant.PurchaseReceiptNumberPrefix,
                        Length = tenant.PurchaseReceiptNumberLength.Value
                    };
                    var respone = MultiTenantHelper.GetNextNumber(UnitOfWork.Connection, request, MyRow.Fields.Number, tenant.TenantId);
                    Row.Number = respone.Serial;
                    Row.ProcurementGroup = GetProcurement(Row.PurchaseOrderId.Value, UnitOfWork.Connection);
                }

            }
        }

        protected override void AfterSave()
        {
            base.AfterSave();

            
            var purchaseOrderId = Row.PurchaseOrderId;

            if (purchaseOrderId == null)
            {
                throw new Exception("PurchaseOrderId is missing in the PurchaseReceipt.");
            }

            
            var purchaseOrderDetail = UnitOfWork.Connection.List<PurchaseOrderDetailRow>(
                new Criteria(PurchaseOrderDetailRow.Fields.PurchaseOrderId) == purchaseOrderId.Value
            );

            if (purchaseOrderDetail == null || purchaseOrderDetail.Count == 0)
            {
                throw new Exception($"No PurchaseOrderDetail rows found for PurchaseOrderId {purchaseOrderId}.");
            }

            
            var purchaseOrderDetailsMap = purchaseOrderDetail.ToDictionary(x => x.ProductId);

            
            foreach (var item in Row.ItemList)
            {
                if (purchaseOrderDetailsMap.TryGetValue(item.ProductId, out var purchaseOrderDetails))
                {
                    // Update the QuantityOfPOCreated by adding the current PO quantity
                    purchaseOrderDetails.QuanityOfPRCreated = (int?)((purchaseOrderDetails.QuanityOfPRCreated ?? 0) + item.QtyReceive);

                    // Check if the total QuantityOfPOCreated meets or exceeds the requested quantity
                    purchaseOrderDetails.IsPRCreate = purchaseOrderDetails.QuanityOfPRCreated >= purchaseOrderDetails.Qty;

                    // Save the updated RequestDetailRow back to the database
                    UnitOfWork.Connection.UpdateById(purchaseOrderDetails);

                }
                else
                {
                    throw new Exception($"PurchaseOrderDetail for ProductId {item.ProductId} not found in PurchaseOrder {purchaseOrderId}.");
                }


               
                var requests = UnitOfWork.Connection.List<PurchaseOrderRow>(
                    new Criteria(PurchaseOrderRow.Fields.Id) == purchaseOrderId.Value
                );

                if (requests == null || requests.Count == 0)
                {
                    throw new Exception($"No PurchaseOrderrows found for PurchaseOrderId {purchaseOrderId}.");
                }

                
                foreach (var request in requests)
                {
                    
                    bool allpurchaseOrderDetailsComplete = purchaseOrderDetail.All(x => x.IsPRCreate == true);

                    
                    if (allpurchaseOrderDetailsComplete)
                    {
                        request.IsPRCreate = true;
                        if(request.IsBillCreated == true && request.IsPRCreate == true)
                        {
                            request.Status = (PurchaseOrder.Status?)2;
                        }
                        else
                        {
                            request.Status = (PurchaseOrder.Status?)1;
                        }
                        

                        UnitOfWork.Connection.UpdateById(request);
                    }
                }

            }
        }
    }
}
