using Serenity;
using Serenity.Abstractions;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Indotalent.Inventory.StockRow>;
using MyRow = Indotalent.Inventory.StockRow;

namespace Indotalent.Inventory
{
    public interface IStockListHandler : IListHandler<MyRow, MyRequest, MyResponse> 
    {
        ListResponse<MyRow> ListReport(IDbConnection connection, ListRequest request);
    }


    public class StockListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IStockListHandler
    {
        protected IUserRetrieveService UserRetrieveService { get; }
        public StockListHandler(IRequestContext context, IUserRetrieveService userRetrieveService)
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

            var result = connection.Query<MyRow>(
                @$"
                    select Id, MAX(ProductName) as ProductName, MAX(InternalCode) as InternalCode, MAX(Barcode) as Barcode, MAX(ProjectName) as ProjectName, 
                    MAX(WarehouseName) as WarehouseName, Max(AvailableStock) as Qty, Max(Uom) as Uom,SUM(TotalPrice) as TotalPrice
                    from [dbo].[vwAvailableStock]
                    where TenantId = {tenantId} and
                        (ProjectName like '%{request.ContainsText}%' or WarehouseName like '%{request.ContainsText}%' or ProductName like '%{request.ContainsText}%')
                    group by Id
                    order by ProjectName, WarehouseName, ProductName
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