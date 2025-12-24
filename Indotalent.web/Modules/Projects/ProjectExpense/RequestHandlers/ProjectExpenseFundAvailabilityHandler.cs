
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
using System.Data.Common;
using Indotalent.Projects; // Add Dapper namespace for explicit method resolution

namespace Indotalent.Web.Modules.Material.Issue.RequestHandlers
{
    public class ProjectExpenseFundAvailabilityRequest : ServiceRequest
    {
       
        public int ProjectId { get; set; }

        public float NewExpense { get; set; }
    }

    public class ProjectExpenseFundAvailabilityResponse : ServiceResponse
    {
        //  public List<int> PurchaseReceiptIdList { get; set; }
        //public double TotalAllocatedFund { get; set; }
        public bool IsFundAvailable { get; set; }
        public List<vwProjectFundRow> vwProjectFundLists { get; set; }
    }

    public interface IProjectExpenseFundAvailabilityHandler : IRequestHandler
    {
        ProjectExpenseFundAvailabilityResponse GetProjectExpenseFundAvailability(IDbConnection connection, ProjectExpenseFundAvailabilityRequest request);
    }

    public class ProjectExpenseFundAvailabilityHandler : IProjectExpenseFundAvailabilityHandler
    {
        protected IUserAccessor UserAccessor { get; }
        private IUserRetrieveService UserRetriever { get; }

        public ProjectExpenseFundAvailabilityHandler(IUserAccessor userAccessor, IUserRetrieveService userRetriever)
        {
            UserAccessor = userAccessor;
            UserRetriever = userRetriever;
        }

        public ProjectExpenseFundAvailabilityResponse GetProjectExpenseFundAvailability(IDbConnection connection, ProjectExpenseFundAvailabilityRequest request)
        {
            var result = new ProjectExpenseFundAvailabilityResponse();
            var prList = new List<vwProjectFundRow>();
            var rowFieldsvwProjectFundRow = vwProjectFundRow.Fields;

            var parameters = new DynamicParameters();
            parameters.Add("@ProjectId", request.ProjectId);
            parameters.Add("@NewExpense", request.NewExpense);

            // Run the stored procedure
            var isAvailable = Dapper.SqlMapper.QueryFirstOrDefault<int>(
                connection,
                "CheckFundAvailability",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            result.IsFundAvailable = (isAvailable == 1);
            
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }


            var VwProjectFundRow = connection.TryFirst<vwProjectFundRow>(
                row => row.SelectTableFields().Where(rowFieldsvwProjectFundRow.ProjectId == request.ProjectId)
            );

            if (VwProjectFundRow != null)
                prList.Add(VwProjectFundRow);

            result.vwProjectFundLists = prList;

            return result;
        }
    }


}
