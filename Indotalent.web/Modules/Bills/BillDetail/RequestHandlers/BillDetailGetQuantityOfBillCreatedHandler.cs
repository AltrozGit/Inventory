using Dapper;
using DocumentFormat.OpenXml.Drawing;
using Indotalent.Administration;
using Indotalent.Material;
using Indotalent.Purchase;
using Indotalent.Web.Modules.Administration.Tenant.RequestHandlers;
using Serenity;
using Serenity.Abstractions;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Collections.Generic;
using System.Data;
using static MVC.Views.Administration;
using static MVC.Views.Purchase;

namespace Indotalent.Web.Modules.Bills.BillDetail.RequestHandlers
{
    public class BillDetailGetQuantityOfBillCreatedRequest : ServiceRequest
    {
        public int PurchaseOrderId { get; set; }
        public int ProductId { get; set; }
    }

    public class BillDetailGetQuantityOfBillCreatedResponse : ServiceResponse
    {
        
        public PurchaseOrderDetailRow PurchaseOrderDetailRow { get; set; }
    }

    public interface IBillDetailGetQuantityOfBillCreatedHandler : IRequestHandler
    {
        BillDetailGetQuantityOfBillCreatedResponse GetQuantityOfBillCreated(IDbConnection connection, BillDetailGetQuantityOfBillCreatedRequest request);
    }

    public class BillDetailGetQuantityOfBillCreatedHandler : IBillDetailGetQuantityOfBillCreatedHandler
    {
        protected IUserAccessor UserAccessor { get; }
        private IUserRetrieveService UserRetriever { get; }

        public BillDetailGetQuantityOfBillCreatedHandler(IUserAccessor userAccessor, IUserRetrieveService userRetriever)
        {
            UserAccessor = userAccessor;
            UserRetriever = userRetriever;
        }


        public BillDetailGetQuantityOfBillCreatedResponse GetQuantityOfBillCreated(IDbConnection connection, BillDetailGetQuantityOfBillCreatedRequest request)
        {
            var result = new BillDetailGetQuantityOfBillCreatedResponse();

            var purchaseOrderId = request.PurchaseOrderId;
            var productId = request.ProductId;
            var rowFieldsPurchaseOrderDetailRow = PurchaseOrderDetailRow.Fields;


            result.PurchaseOrderDetailRow = connection.TryFirst<PurchaseOrderDetailRow>(row => row.SelectTableFields()
            .Where(rowFieldsPurchaseOrderDetailRow.PurchaseOrderId == purchaseOrderId && rowFieldsPurchaseOrderDetailRow.ProductId == productId));

           

            return result;
        }
    }
}
