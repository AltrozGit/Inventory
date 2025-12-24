
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
using DapperSqlMapper = Dapper.SqlMapper;
using System.Data.Common; // Add Dapper namespace for explicit method resolution

namespace Indotalent.Web.Modules.Material.Issue.RequestHandlers
{
    public class IssueGetPurchaseReceiptIdRequest : ServiceRequest
    {
       
        public int MaterialRequestId { get; set; }


    }

    public class IssueGetPurchaseReceiptIdResponse : ServiceResponse
    {
      //  public List<int> PurchaseReceiptIdList { get; set; }

        public List<PurchaseReceiptRow> PurchaseReceiptLists { get; set; }
    }

    public interface IIssueGetPurchaseReceiptIdHandler : IRequestHandler
    {
        IssueGetPurchaseReceiptIdResponse GetPurchaseReceiptIdsByMaterialRequestId(IDbConnection connection, IssueGetPurchaseReceiptIdRequest request);
    }

    public class IssueGetPurchaseReceiptIdHandler : IIssueGetPurchaseReceiptIdHandler
    {
        protected IUserAccessor UserAccessor { get; }
        private IUserRetrieveService UserRetriever { get; }
        //private IDbConnection Connection { get; }

        public IssueGetPurchaseReceiptIdHandler(IUserAccessor userAccessor, IUserRetrieveService userRetriever/*, IDbConnection connection*/)
        {
            UserAccessor = userAccessor;
            UserRetriever = userRetriever;
            // Connection = connection;
        }

        public IssueGetPurchaseReceiptIdResponse GetPurchaseReceiptIdsByMaterialRequestId(IDbConnection connection, IssueGetPurchaseReceiptIdRequest request)
        {
            var result = new IssueGetPurchaseReceiptIdResponse();
            var prList = new List<PurchaseReceiptRow>();
            var rowFieldsPurchaseReceiptRow = PurchaseReceiptRow.Fields;
            var parameters = new DynamicParameters();
            parameters.Add("@MaterialRequestId", request.MaterialRequestId);

            // Execute Dapper query
            var purchaseReceiptIds = Dapper.SqlMapper.Query<int>(
                connection,
                "usp_GetPurchaseReceiptIdsByMaterialRequest",
                parameters,
                commandType: CommandType.StoredProcedure
            ).ToList();

            // Ensure the connection is open before RepoDB operations
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            foreach (var purchaseReceiptId in purchaseReceiptIds)
            {
                var purchaseReceiptRow = connection.TryFirst<PurchaseReceiptRow>(
                    row => row.SelectTableFields().Where(rowFieldsPurchaseReceiptRow.Id == purchaseReceiptId)
                );
                if (purchaseReceiptRow != null)
                {
                    prList.Add(purchaseReceiptRow);
                }
            }

            result.PurchaseReceiptLists = prList;
            return result;
        }

    }
        //public class PurchaseReceiptRow
        //{
        //    public int PurchaseReceiptId { get; set; }
        //    public int PurchaseOrderId { get; set; }
        //}

        //public class PurchaseOrderRow
        //{
        //    public int PurchaseOrderId { get; set; }
        //    public int MaterialRequestId { get; set; }
        //}

        //public class MaterialRequestRow
        //{
        //    public int MaterialRequestId { get; set; }
        //}
    }
