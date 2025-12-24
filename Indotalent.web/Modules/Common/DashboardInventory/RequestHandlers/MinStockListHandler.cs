using Serenity;
using Serenity.Abstractions;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Indotalent.Common.DashboardInventory.MinStockRow>;
using MyRow = Indotalent.Common.DashboardInventory.MinStockRow;

namespace Indotalent.Common.DashboardInventory
{
    public interface IMinStockListHandler : IListHandler<MyRow, MyRequest, MyResponse>
    {
        ListResponse<MyRow> ListReport(IDbConnection connection, ListRequest request);
    }


    public class MinStockListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IMinStockListHandler
    {
        protected IUserRetrieveService UserRetrieveService { get; }
        public MinStockListHandler(IRequestContext context, IUserRetrieveService userRetrieveService)
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

            var result = connection.Query<MinStockRow>(
                @$"
                    select MAX(Id) as Id, MAX(ProductName) as ProductName, MAX(InternalCode) as InternalCode, MAX(Barcode) as Barcode, MAX(WarehouseName) as WarehouseName, 
	                Max(AvailableStock) as Qty, Max(MinimumQty) as MinimumQty, Max(Uom) as Uom
                    from [dbo].[vwAvailableStock] 
                    where TenantId = {tenantId} and 
                        (WarehouseName like '%{request.ContainsText}%' or ProductName like '%{request.ContainsText}%')
                    group by ProductId, WarehouseName
                    having sum(AvailableStock) <= max(MinimumQty)
					order by ProductName, WarehouseName
                ",
                null,
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