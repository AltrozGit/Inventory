using Indotalent.Administration;
using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<Indotalent.Purchase.PurchaseOrderRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Indotalent.Purchase.PurchaseOrderRow;
using ItemRow = Indotalent.Purchase.PurchaseOrderDetailRow;
using Indotalent.Merchandise;
using Indotalent.Material;
using System.Linq; // Assuming you have a namespace for MaterialRequest

namespace Indotalent.Purchase
{
    public interface IPurchaseOrderSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> { }
    public class PurchaseOrderSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IPurchaseOrderSaveHandler
    {
        public PurchaseOrderSaveHandler(IRequestContext context)
        : base(context)
        {
        }
        protected override void BeforeSave()
        {
            base.BeforeSave();
            Row.SubTotal = 0;
            Row.BeforeTax = 0;
            Row.Discount = 0;
            Row.TaxAmount = 0;
            Row.Total = 0;

            foreach (var item in Row.ItemList)
            {
                Row.SubTotal += item.SubTotal;
                Row.BeforeTax += item.BeforeTax;
                Row.Discount += item.Discount;
                Row.TaxAmount += item.TaxAmount;
                Row.Total += item.Total;

                UpdateProductPrice(item);
            }

            Row.Total += Row.OtherCharge;

            if (this.IsCreate)
            {
                var productlist = Row.ItemList.ToArray();

                foreach (var item in productlist)
                {
                    var productrow = UnitOfWork.Connection.ById<ProductRow>(item.ProductId);
                    if (productrow != null)
                    {
                        productrow.PurchasePrice = item.Price;
                        UnitOfWork.Connection.UpdateById(productrow);
                    }
                    else
                    {
                        throw new Exception($"Product with ID {item.ProductId} not found.");
                    }
                }

                if (Row.Number.ToLower().Equals("auto"))
                {
                    var tenant = UnitOfWork.Connection.ById<TenantRow>(Row.TenantId);
                    var request = new GetNextNumberRequest()
                    {
                        Prefix = tenant.PurchaseNumberUseDate.Value ? tenant.PurchaseNumberPrefix + "/" + DateTime.Now.ToString("yyyyMMdd") : tenant.PurchaseNumberPrefix,
                        Length = tenant.PurchaseNumberLength.Value
                    };
                    var respone = MultiTenantHelper.GetNextNumber(UnitOfWork.Connection, request, MyRow.Fields.Number, tenant.TenantId);
                    Row.Number = respone.Serial;
                    Row.ProcurementGroup = Row.Number;
                }
            }
        }

        private void UpdateProductPrice(ItemRow item)
        {
            var product = UnitOfWork.Connection.ById<ProductRow>(item.ProductId);
            if (product != null)
            {
                product.PurchasePrice = item.Price;
                UnitOfWork.Connection.UpdateById(product);
            }
        }

        protected override void AfterSave()
        {
            base.AfterSave();

            // Fetch the MaterialRequestId from the PurchaseOrder
            var materialRequestId = Row.MaterialRequestId;

            if (materialRequestId == null)
            {
                throw new Exception("MaterialRequestId is missing in the PurchaseOrder.");
            }

            // Fetch all RequestDetail rows associated with the MaterialRequestId
            var requestDetails = UnitOfWork.Connection.List<RequestDetailRow>(
                new Criteria(RequestDetailRow.Fields.MaterialRequestId) == materialRequestId.Value
            );

            if (requestDetails == null || requestDetails.Count == 0)
            {
                throw new Exception($"No RequestDetail rows found for MaterialRequestId {materialRequestId}.");
            }

            // Create a dictionary to map ProductId to RequestDetail for quick lookup
            var requestDetailMap = requestDetails.ToDictionary(x => x.ProductId);

            // Iterate through each item in the PurchaseOrderDetail
            foreach (var item in Row.ItemList)
            {
                if (requestDetailMap.TryGetValue(item.ProductId, out var requestDetail))
                {
                    // Update the QuantityOfPOCreated by adding the current PO quantity
                    requestDetail.QuanityOfPOCreated = (int?)((requestDetail.QuanityOfPOCreated ?? 0) + item.Qty);

                    // Check if the total QuantityOfPOCreated meets or exceeds the requested quantity
                    requestDetail.IsPOComplete = requestDetail.QuanityOfPOCreated >= requestDetail.QtyRequest;

                    // Save the updated RequestDetailRow back to the database
                    UnitOfWork.Connection.UpdateById(requestDetail);
                    
                }
                else
                {
                    throw new Exception($"RequestDetail for ProductId {item.ProductId} not found in MaterialRequest {materialRequestId}.");
                }



                // Fetch all Request rows associated with the MaterialRequestId
                var requests = UnitOfWork.Connection.List<RequestRow>(
                    new Criteria(RequestRow.Fields.Id) == materialRequestId.Value
                );

                if (requests == null || requests.Count == 0)
                {
                    throw new Exception($"No Request rows found for MaterialRequestId {materialRequestId}.");
                }

                // Iterate over each RequestRow associated with the MaterialRequestId
                foreach (var request in requests)
                {
                    // Check if all RequestDetail rows are marked as complete
                    bool allRequestDetailsComplete = requestDetails.All(x => x.IsPOComplete == true);

                    // If all RequestDetails are complete, mark the Request as complete
                    if (allRequestDetailsComplete)
                    {
                        request.IsPOComplete = true;

                        // Save the updated RequestRow back to the database
                        UnitOfWork.Connection.UpdateById(request);
                    }
                }
            }
        }
        
    }
}
