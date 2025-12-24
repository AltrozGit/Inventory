using Indotalent.Web.Modules.Common.Project_Summary.IssuedStock;
using Serenity;
using Serenity.Abstractions;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Indotalent.Web.Modules.Common.Project_Summary.IssuedStock.IssueStockRow>;
using MyRow = Indotalent.Web.Modules.Common.Project_Summary.IssuedStock.IssueStockRow;

namespace Indotalent.Common
{
    public interface IIssueStockListHandler : IListHandler<MyRow, MyRequest, MyResponse>
    {
        ListResponse<MyRow> ListReport(IDbConnection connection, ListRequest request);
    }


    public class IssueStockListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IIssueStockListHandler
	{
        protected IUserRetrieveService UserRetrieveService { get; }
        public IssueStockListHandler(IRequestContext context, IUserRetrieveService userRetrieveService)
             : base(context)
        {
            UserRetrieveService = userRetrieveService ?? throw new ArgumentNullException(nameof(userRetrieveService));
        }

        public ListResponse<MyRow> ListReport(IDbConnection connection, ListRequest request)
        {
            var tenantId = -1;
            var username = User?.Identity?.Name;
            if (UserRetrieveService.ByUsername(username) is UserDefinition user)
            {
                tenantId = user.TenantId;
            }

            var result = connection.Query<IssueStockRow>(
			   @$"
                    select MAX(Id) as Id, MAX(ProductName) as ProductName, MAX(InternalCode) as InternalCode, MAX(Barcode) as Barcode, MAX(WarehouseName) as WarehouseName,Max(ProjectName) as ProjectName,
	                Max(AvailableStock) as AvailableStock, Max(MinimumQty) as MinimumQty, Max(Uom) as Uom
                    from [dbo].[vwAvailableStock] 
                    where TenantId = {tenantId} and 
                        (WarehouseName like '%{request.ContainsText}%' or ProductName like '%{request.ContainsText}%')
                    group by ProductId, WarehouseName
                    having sum(AvailableStock) <= max(MinimumQty)
					order by ProductName, WarehouseName
                ",
				commandType: CommandType.Text
                ).ToList();

            var totalCount = result.Count();
            var skip = request.Skip;
            var take = request.Skip == 0 && request.Take == 0 ? totalCount : request.Take;
            var pagedResult = result.Skip(skip).Take(take).ToList();
            return new ListResponse<MyRow>()
            {
                Entities = pagedResult,
                Skip = skip,
                Take = take,
                TotalCount = totalCount
            };
        }
    }
}