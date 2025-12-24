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
    public class IssueDetailGetQuantityOfIssueCreatedRequest : ServiceRequest
    {
        public int PurchaseReceiptId { get; set; }
        public int ProductId { get; set; }
    }

    public class IssueDetailGetQuantityOfIssueCreatedResponse : ServiceResponse
    {
        
        public PurchaseReceiptDetailRow PurchaseReceiptDetailRow { get; set; }
    }

    public interface IIssueDetailGetQuantityOfIssueCreatedHandler : IRequestHandler
    {
        IssueDetailGetQuantityOfIssueCreatedResponse GetQuantityOfIssueCreated(IDbConnection connection, IssueDetailGetQuantityOfIssueCreatedRequest request);
    }

    public class IssueDetailGetQuantityOfIssueCreatedHandler : IIssueDetailGetQuantityOfIssueCreatedHandler
    {
        protected IUserAccessor UserAccessor { get; }
        private IUserRetrieveService UserRetriever { get; }

        public IssueDetailGetQuantityOfIssueCreatedHandler(IUserAccessor userAccessor, IUserRetrieveService userRetriever)
        {
            UserAccessor = userAccessor;
            UserRetriever = userRetriever;
        }


        public IssueDetailGetQuantityOfIssueCreatedResponse GetQuantityOfIssueCreated(IDbConnection connection, IssueDetailGetQuantityOfIssueCreatedRequest request)
        {
            var result = new IssueDetailGetQuantityOfIssueCreatedResponse();

            var purchaseReceiptId = request.PurchaseReceiptId;
            var productId = request.ProductId;
            var rowFieldsPurchaseReceiptDetailRow = PurchaseReceiptDetailRow.Fields;


            result.PurchaseReceiptDetailRow = connection.TryFirst<PurchaseReceiptDetailRow>(row => row.SelectTableFields()
            .Where(rowFieldsPurchaseReceiptDetailRow.PurchaseReceiptId == purchaseReceiptId && rowFieldsPurchaseReceiptDetailRow.ProductId == productId));

           

            return result;
        }
    }
}
