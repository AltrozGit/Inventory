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

namespace Indotalent.Web.Modules.Material.Issue.RequestHandlers
{
    public class PurchaseOrderDetailGetQuantityOfPOCreatedRequest : ServiceRequest
    {
        public int MaterialRequestId { get; set; }
        public int ProductId { get; set; }
    }

    public class PurchaseOrderDetailGetQuantityOfPOCreatedResponse : ServiceResponse
    {
        
        public RequestDetailRow RequestDetailRow { get; set; }
    }

    public interface IPurchaseOrderDetailGetQuantityOfPOCreatedHandler : IRequestHandler
    {
        PurchaseOrderDetailGetQuantityOfPOCreatedResponse GetQuantityOfPOCreated(IDbConnection connection, PurchaseOrderDetailGetQuantityOfPOCreatedRequest request);
    }

    public class PurchaseOrderDetailGetQuantityOfPOCreatedHandler : IPurchaseOrderDetailGetQuantityOfPOCreatedHandler
    {
        protected IUserAccessor UserAccessor { get; }
        private IUserRetrieveService UserRetriever { get; }

        public PurchaseOrderDetailGetQuantityOfPOCreatedHandler(IUserAccessor userAccessor, IUserRetrieveService userRetriever)
        {
            UserAccessor = userAccessor;
            UserRetriever = userRetriever;
        }


        public PurchaseOrderDetailGetQuantityOfPOCreatedResponse GetQuantityOfPOCreated(IDbConnection connection, PurchaseOrderDetailGetQuantityOfPOCreatedRequest request)
        {
            var result = new PurchaseOrderDetailGetQuantityOfPOCreatedResponse();

            var materialRequestId = request.MaterialRequestId;
            var productId = request.ProductId;
            var rowFieldsRequestDetailRow = RequestDetailRow.Fields;


            result.RequestDetailRow = connection.TryFirst<RequestDetailRow>(row => row.SelectTableFields()
            .Where(rowFieldsRequestDetailRow.MaterialRequestId == materialRequestId && rowFieldsRequestDetailRow.ProductId == productId));

           

            return result;
        }
    }
}
