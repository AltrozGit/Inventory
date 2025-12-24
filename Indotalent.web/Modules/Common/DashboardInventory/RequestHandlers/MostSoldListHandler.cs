using Serenity;
using Serenity.Abstractions;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Indotalent.Common.DashboardInventory.MostSoldRow>;
using MyRow = Indotalent.Common.DashboardInventory.MostSoldRow;

namespace Indotalent.Common.DashboardInventory
{
    public interface IMostSoldListHandler : IListHandler<MyRow, MyRequest, MyResponse> 
    {
        ListResponse<MyRow> ListReport(IDbConnection connection, ListRequest request);
    }


    public class MostSoldListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IMostSoldListHandler
    {
        protected IUserRetrieveService UserRetrieveService { get; }
        public MostSoldListHandler(IRequestContext context, IUserRetrieveService userRetrieveService)
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

            var result = connection.Query<MostSoldRow>(
                @$"

select top 20 ROW_NUMBER() OVER(ORDER BY sum(ord.Qty) DESC) as Id, prd.Name as ProductName, sum(ord.Qty) as Qty, max(um.Name) as Uom from SalesOrderDetail ord
inner join Product prd on ord.ProductId = prd.Id
inner join Uom um on prd.UomId = um.Id
inner join Tenant tnt on ord.TenantId = tnt.TenantId
where tnt.TenantId = {tenantId} and prd.Name like '%{request.ContainsText}%'
group by prd.Name
order by sum(ord.Qty) desc


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