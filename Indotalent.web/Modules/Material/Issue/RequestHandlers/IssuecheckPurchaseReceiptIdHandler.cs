
using Serenity;
using Serenity.Abstractions;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Indotalent.Purchase;
using Indotalent.Material;
using DapperSqlMapper = Dapper.SqlMapper;
using System.Data.Common; // Add Dapper namespace for explicit method resolution

namespace Indotalent.Web.Modules.Material.Issue.RequestHandlers
{
    public class IssuecheckPurchaseReceiptIdRequest : ServiceRequest
    {
       
        public int MaterialRequestId { get; set; }

        public int PurchaseReceiptId { get; set; }


    }

    public class IssuecheckPurchaseReceiptIdResponse : ServiceResponse
    {
     

        public IssueRow IssueRow { get; set; }
      
    }

    public interface IIssuecheckPurchaseReceiptIdHandler : IRequestHandler
    {
        IssuecheckPurchaseReceiptIdResponse GetBillCretedPRId(IDbConnection connection, IssuecheckPurchaseReceiptIdRequest request);
    }

    public class IssuecheckPurchaseReceiptIdHandler : IIssuecheckPurchaseReceiptIdHandler
    {
        protected IUserAccessor UserAccessor { get; }
        private IUserRetrieveService UserRetriever { get; }
        //private IDbConnection Connection { get; }

        public IssuecheckPurchaseReceiptIdHandler(IUserAccessor userAccessor, IUserRetrieveService userRetriever/*, IDbConnection connection*/)
        {
            UserAccessor = userAccessor;
            UserRetriever = userRetriever;
            // Connection = connection;
        }

        public IssuecheckPurchaseReceiptIdResponse GetBillCretedPRId(IDbConnection connection, IssuecheckPurchaseReceiptIdRequest request)
        {
            var result = new IssuecheckPurchaseReceiptIdResponse();

            var purchaseReceiptId = request.PurchaseReceiptId;
            //var productId = request.ProductId;
            var rowFieldsIssueRow = IssueRow.Fields;


           
            var issueRow = connection.TryFirst<IssueRow>(row => row.SelectTableFields()
                .Where(rowFieldsIssueRow.PurchaseReceiptId == purchaseReceiptId));

          



            return result;
        }

    }
       

}
