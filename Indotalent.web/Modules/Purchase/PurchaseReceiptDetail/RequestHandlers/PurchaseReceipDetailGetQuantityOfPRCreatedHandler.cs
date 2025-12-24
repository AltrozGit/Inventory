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

namespace Indotalent.Web.Modules.Purchase.PurchaseOrderDetail.RequestHandlers
{
    public class PurchaseReceipDetailGetQuantityOfPRCreatedRequest : ServiceRequest
    {
        public int PurchaseOrderId { get; set; }
        public int ProductId { get; set; }
    }

    public class PurchaseReceipDetailGetQuantityOfPRCreatedResponse : ServiceResponse
    {
        
        public PurchaseOrderDetailRow PurchaseOrderDetailRow { get; set; }
    }

    public interface IPurchaseReceipDetailGetQuantityOfPRCreatedHandler : IRequestHandler
    {
        PurchaseReceipDetailGetQuantityOfPRCreatedResponse GetQuantityOfPRCreated(IDbConnection connection, PurchaseReceipDetailGetQuantityOfPRCreatedRequest request);
    }

    public class PurchaseReceipDetailGetQuantityOfPRCreatedHandler : IPurchaseReceipDetailGetQuantityOfPRCreatedHandler
    {
        protected IUserAccessor UserAccessor { get; }
        private IUserRetrieveService UserRetriever { get; }

        public PurchaseReceipDetailGetQuantityOfPRCreatedHandler(IUserAccessor userAccessor, IUserRetrieveService userRetriever)
        {
            UserAccessor = userAccessor;
            UserRetriever = userRetriever;
        }


        public PurchaseReceipDetailGetQuantityOfPRCreatedResponse GetQuantityOfPRCreated(IDbConnection connection, PurchaseReceipDetailGetQuantityOfPRCreatedRequest request)
        {
            var result = new PurchaseReceipDetailGetQuantityOfPRCreatedResponse();

            var purchaseOrderId = request.PurchaseOrderId;
            var productId = request.ProductId;
            var rowFieldsPurchaseOrderDetailRow = PurchaseOrderDetailRow.Fields;


            result.PurchaseOrderDetailRow = connection.TryFirst<PurchaseOrderDetailRow>(row => row.SelectTableFields()
            .Where(rowFieldsPurchaseOrderDetailRow.PurchaseOrderId == purchaseOrderId && rowFieldsPurchaseOrderDetailRow.ProductId == productId));

           

            return result;
        }
    }
}
