using Indotalent.Administration;
using Indotalent.Purchase;
using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using System.Linq;
using static MVC.Views.Purchase;
using MyRequest = Serenity.Services.SaveRequest<Indotalent.Material.IssueRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Indotalent.Material.IssueRow;

namespace Indotalent.Material
{
    public interface IIssueSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> { }

    public class IssueSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IIssueSaveHandler
    {
        public IssueSaveHandler(IRequestContext context)
             : base(context)
        {
        }
        protected override void BeforeSave()
        {

              base.BeforeSave();

                Row.TotalQtyIssue = 0;

                foreach (var item in Row.ItemList)
                {
                    Row.TotalQtyIssue += item.QtyIssue;
                }
            if (Row.TotalQtyIssue == null)//change added by harsha error show for totalqty (dt.5/8/24)
            {
                throw new Exception("QuantityIssue in New issue detail can not be 0:\n");
            }
             if (this.IsCreate)
             {
                    if (Row.Number.ToLower().Equals("auto"))
                    {
                        var tenant = UnitOfWork.Connection.ById<TenantRow>(Row.TenantId);
                        var request = new GetNextNumberRequest()
                        {
                            Prefix = tenant.MaterialIssueNumberUseDate.Value ? tenant.MaterialIssueNumberPrefix + "/" + DateTime.Now.ToString("yyyyMMdd") : tenant.MaterialIssueNumberPrefix,
                            Length = tenant.MaterialIssueNumberLength.Value
                        };
                        var respone = MultiTenantHelper.GetNextNumber(UnitOfWork.Connection, request, MyRow.Fields.Number, tenant.TenantId);
                        Row.Number = respone.Serial;
                    }

                
             }
           
        }
        //protected override void AfterSave()
        //{
        //    base.AfterSave();

        //    var purchaseReceiptId = Row.PurchaseReceiptId;

        //    var materialRequestId = Row.MaterialRequestId;  

        //    if (purchaseReceiptId == null)
        //    {
        //        throw new Exception("PurchaseReceiptId is missing in the Material Issue.");
        //    }

        //    // Fetch the PurchaseReceiptRow
        //    var receipt = UnitOfWork.Connection.TryById<PurchaseReceiptRow>(purchaseReceiptId.Value);

        //    if (receipt == null)
        //    {
        //        throw new Exception($"No PurchaseReceiptRow found for PurchaseReceiptId {purchaseReceiptId}.");
        //    }

        //    // Check if the flag is already true (optional)
        //    if (receipt.IsIssueCreated != true)
        //    {
        //        // Update the flag
        //        receipt.IsIssueCreated = true;

        //        // Save the update back to the database
        //        UnitOfWork.Connection.UpdateById(receipt);
        //    }
        //}





        protected override void AfterSave()
        {
            base.AfterSave();


            var purchaseReceiptId = Row.PurchaseReceiptId;
            var requestId = Row.MaterialRequestId;


            if (purchaseReceiptId == null)
            {
                throw new Exception("purchaseReceiptId is missing in the PurchaseReceipt.");
            }


            var purchaseReceiptDetail = UnitOfWork.Connection.List<PurchaseReceiptDetailRow>(
                new Criteria(PurchaseReceiptDetailRow.Fields.PurchaseReceiptId) == purchaseReceiptId.Value
            );

            if (purchaseReceiptDetail == null || purchaseReceiptDetail.Count == 0)
            {
                throw new Exception($"No PurchaseOrderDetail rows found for PurchaseOrderId {purchaseReceiptId}.");
            }


            var purchaseReceiptDetailsMap = purchaseReceiptDetail.ToDictionary(x => x.ProductId);


            foreach (var item in Row.ItemList)
            {
                if (purchaseReceiptDetailsMap.TryGetValue(item.ProductId, out var purchaseReceiptDetails))
                {
                    // Update the QuantityOfPOCreated by adding the current PO quantity
                    purchaseReceiptDetails.QuanityOfIssueCreated = (int?)((purchaseReceiptDetails.QuanityOfIssueCreated ?? 0) + item.QtyIssue);

                    // Check if the total QuantityOfPOCreated meets or exceeds the requested quantity
                    purchaseReceiptDetails.IsIssueCreated = purchaseReceiptDetails.QuanityOfIssueCreated >= purchaseReceiptDetails.QtyReceive;

                    // Save the updated RequestDetailRow back to the database
                    UnitOfWork.Connection.UpdateById(purchaseReceiptDetails);

                }
                else
                {
                    throw new Exception($"PurchaseOrderDetail for ProductId {item.ProductId} not found in PurchaseOrder {purchaseReceiptId}.");
                }



                var requests = UnitOfWork.Connection.List<PurchaseReceiptRow>(
                    new Criteria(PurchaseReceiptRow.Fields.Id) == purchaseReceiptId.Value
                );

                var Mrequests = UnitOfWork.Connection.List<RequestRow>(
                    new Criteria(RequestRow.Fields.Id) == requestId.Value
                );

                if (requests == null || requests.Count == 0)
                {
                    throw new Exception($"No PurchaseOrderrows found for PurchaseOrderId {purchaseReceiptId}.");
                }


                foreach (var request in requests)
                {

                    bool allpurchaseReceiptDetailsComplete = purchaseReceiptDetail.All(x => x.IsIssueCreated == true);


                    if (allpurchaseReceiptDetailsComplete)
                    {
                        request.IsIssueCreated = true;
                        request.Status = (Web.Modules.Purchase.PurchaseReceipt.Status?)2;

                        UnitOfWork.Connection.UpdateById(request);
                    }
                }
                //foreach (var request in Mrequests)
                //{

                //    bool allpurchaseReceiptDetailsCompleted = purchaseReceiptDetail.All(x => x.IsIssueCreated == true);


                //    if (allpurchaseReceiptDetailsCompleted)
                //    {
                //        request.IsIssueCreated = true;
                       

                //        UnitOfWork.Connection.UpdateById(request);
                //    }
                //}
            }
            var receiptIds = UnitOfWork.Connection.Query<int>(
     "EXEC usp_GetPurchaseReceiptIdsByMaterialRequest @MaterialRequestId",
     new { MaterialRequestId = requestId }
 ).ToList();

            if (receiptIds == null || receiptIds.Count == 0)
            {
                throw new Exception($"No PurchaseReceipts found for MaterialRequestId = {requestId}.");
            }

            var receipts = UnitOfWork.Connection.List<PurchaseReceiptRow>(
                new Criteria(PurchaseReceiptRow.Fields.Id).In(receiptIds)
            );

            bool allIssued = receipts.All(x => x.IsIssueCreated == true);

            if (allIssued)
            {
                var requestRow = UnitOfWork.Connection.TryById<RequestRow>(requestId.Value);
                if (requestRow != null)
                {
                    requestRow.IsIssueCreated = true;
                    UnitOfWork.Connection.UpdateById(requestRow);
                }
            }
        }


    }
}
