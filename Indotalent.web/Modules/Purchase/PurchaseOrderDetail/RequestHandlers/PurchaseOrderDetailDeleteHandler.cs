using Indotalent.Material;
using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = Indotalent.Purchase.PurchaseOrderDetailRow;

namespace Indotalent.Purchase
{
    public interface IPurchaseOrderDetailDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class PurchaseOrderDetailDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IPurchaseOrderDetailDeleteHandler
    {
        public PurchaseOrderDetailDeleteHandler(IRequestContext context)
             : base(context)
        {
        }

    
        protected override void OnBeforeDelete()
        {
            base.OnBeforeDelete();

            var materialRequestId = Row.MaterialRequestId;

            var requestDetailsRow = UnitOfWork.Connection.List<RequestDetailRow>(
              new Criteria(RequestDetailRow.Fields.MaterialRequestId) == materialRequestId.Value
          );


            foreach (var requestDetails in requestDetailsRow)
            {
                if (Row.ProductId == requestDetails.ProductId)
                {

                    requestDetails.IsPOComplete = false;
                    requestDetails.QuanityOfPOCreated = (requestDetails.QuanityOfPOCreated) - (int)(Row.Qty);

                }
                UnitOfWork.Connection.UpdateById(requestDetails);
            }

        }
    }
}