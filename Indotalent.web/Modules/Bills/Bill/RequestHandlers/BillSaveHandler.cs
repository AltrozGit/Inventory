using Indotalent.Administration;
using Indotalent.Material;
using Indotalent.Purchase;
using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using System.Linq;
using static MVC.Views.Material;
using static MVC.Views.Purchase;
using MyRequest = Serenity.Services.SaveRequest<Indotalent.Bills.BillRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Indotalent.Bills.BillRow;

namespace Indotalent.Bills
{
    public interface IBillSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> { }

    public class BillSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IBillSaveHandler
    {
        public BillSaveHandler(IRequestContext context)
             : base(context)
        {
        }

        private string GetProcurement(int purchaseOrderId, IDbConnection connection)
        {
            var result = "";

            var data = connection.TryById<PurchaseOrderRow>(purchaseOrderId, q => q
                 .SelectTableFields());
            result = data.ProcurementGroup;

            data.IsBillGenerated = true;
            connection.UpdateById<PurchaseOrderRow>(data);

            return result;



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
            }

            Row.Total += Row.OtherCharge;

            if (this.IsCreate)
            {
                if (Row.Number.ToLower().Equals("auto"))
                {
                    var tenant = UnitOfWork.Connection.ById<TenantRow>(Row.TenantId);
                    var request = new GetNextNumberRequest()
                    {
                        Prefix = tenant.BillNumberUseDate.Value ? tenant.BillNumberPrefix + "/" + DateTime.Now.ToString("yyyyMMdd") : tenant.BillNumberPrefix,
                        Length = tenant.BillNumberLength.Value
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
                throw new Exception("purchaseOrderId is missing in the Bill.");
            }


            var purchaseOrderDetail = UnitOfWork.Connection.List<PurchaseOrderDetailRow>(
                new Criteria(PurchaseOrderDetailRow.Fields.PurchaseOrderId) == purchaseOrderId.Value
            );

            if (purchaseOrderDetail == null || purchaseOrderDetail.Count == 0)
            {
                throw new Exception($"No purchaseOrderDetail rows found for purchaseOrderId {purchaseOrderId}.");
            }


            var purchaseOrderDetailsMap = purchaseOrderDetail.ToDictionary(x => x.ProductId);


            foreach (var item in Row.ItemList)
            {
                if (purchaseOrderDetailsMap.TryGetValue(item.ProductId, out var purchaseOrderDetails))
                {

                    purchaseOrderDetails.QuanityOfBillCreated = (int?)((purchaseOrderDetails.QuanityOfBillCreated ?? 0) + item.Qty);


                    purchaseOrderDetails.IsBillCreated = purchaseOrderDetails.QuanityOfBillCreated >= purchaseOrderDetails.Qty;


                    UnitOfWork.Connection.UpdateById(purchaseOrderDetails);

                }
                else
                {
                    throw new Exception($"purchaseOrderDetail for ProductId {item.ProductId} not found in purchaseOrderId {purchaseOrderId}.");
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

                    bool allpurchaseOrderDetailsComplete = purchaseOrderDetail.All(x => x.IsBillCreated == true);


                    if (allpurchaseOrderDetailsComplete)
                    {
                        request.IsBillCreated = true;
                        if (request.IsBillCreated == true && request.IsPRCreate == true)
                        {
                            request.Status = (Web.Modules.Purchase.PurchaseOrder.Status?)2;
                        }
                        else
                        {
                            request.Status = (Web.Modules.Purchase.PurchaseOrder.Status?)1;
                        }


                        UnitOfWork.Connection.UpdateById(request);
                    }
                }


                //// Fetch all Request rows associated with the MaterialRequestId
                //var requests = UnitOfWork.Connection.List<RequestRow>(
                //    new Criteria(RequestRow.Fields.Id) == materialRequestId.Value
                //);

                //if (requests == null || requests.Count == 0)
                //{
                //    throw new Exception($"No Request rows found for MaterialRequestId {materialRequestId}.");
                //}

                //// Iterate over each RequestRow associated with the MaterialRequestId
                //foreach (var request in requests)
                //{
                //    // Check if all RequestDetail rows are marked as complete
                //    bool allRequestDetailsComplete = requestDetails.All(x => x.IsPOComplete == true);

                //    // If all RequestDetails are complete, mark the Request as complete
                //    if (allRequestDetailsComplete)
                //    {
                //        request.IsPOComplete = true;

                //        // Save the updated RequestRow back to the database
                //        UnitOfWork.Connection.UpdateById(request);
                //    }
                //}

            }
        }
    }
}
