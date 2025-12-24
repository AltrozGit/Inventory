using Serenity;
using Serenity.Abstractions;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Indotalent.Inventory.MovementRow>;
using MyRow = Indotalent.Inventory.MovementRow;

namespace Indotalent.Inventory
{
    public interface IMovementListHandler : IListHandler<MyRow, MyRequest, MyResponse> 
    {
        ListResponse<MyRow> ListReport(IDbConnection connection, ListRequest request);
    }

    public class MovementListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IMovementListHandler
    {
        protected IUserRetrieveService UserRetrieveService { get; }
        public MovementListHandler(IRequestContext context, IUserRetrieveService userRetrieveService)
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

            var result = connection.Query<MovementRow>(
                @$"

;with stock as
(
--purchase receipt (in)
select cast(year(header.ReceiptDate) as varchar) + '-' + cast(month(header.ReceiptDate) as varchar) + '-' + cast(day(header.ReceiptDate) as varchar) as Period, 'GR' as Module, header.Number as Number, header.ReceiptDate as TransactionDate, detail.ProductId, n.Name as ProjectName, w.Name as WarehouseName, detail.QtyReceive * +1 as Qty from Tenant c
inner join PurchaseReceipt header on c.TenantId = header.TenantId
inner join PurchaseReceiptDetail detail on header.Id = detail.PurchaseReceiptId
inner join Project n on header.ProjectId = n.id
inner join Warehouse w on header.WarehouseId = w.Id
where c.TenantId = {tenantId}

union all

--purchase return (out)
select cast(year(header.ReturnDate) as varchar) + '-' + cast(month(header.ReturnDate) as varchar) + '-' + cast(day(header.ReturnDate) as varchar) as Period, 'GR-RETURN' as Module, header.Number as Number,  header.ReturnDate as TransactionDate, detail.ProductId, n.Name as ProjectName, w.Name as WarehouseName, detail.QtyReturn * -1 as Qty from Tenant c
inner join PurchaseReturn header on c.TenantId = header.TenantId
inner join PurchaseReturnDetail detail on header.Id = detail.PurchaseReturnId
inner join Project n on header.ProjectId = n.id
inner join Warehouse w on header.WarehouseId = w.Id
where c.TenantId = {tenantId}

union all

--sales delivery (out)
select cast(year(header.DeliveryDate) as varchar) + '-' + cast(month(header.DeliveryDate) as varchar) + '-' + cast(day(header.DeliveryDate) as varchar) as Period, 'DO' as Module, header.Number as Number, header.DeliveryDate as TransactionDate, detail.ProductId, n.Name as ProjectName, w.Name as WarehouseName, detail.QtyDelivered * -1 as Qty from Tenant c
inner join SalesDelivery header on c.TenantId = header.TenantId
inner join SalesDeliveryDetail detail on header.Id = detail.SalesDeliveryId
inner join Project n on header.ProjectId = n.id
inner join Warehouse w on header.WarehouseId = w.Id
where c.TenantId = {tenantId}

union all

--sales return (in)
select cast(year(header.ReturnDate) as varchar) + '-' + cast(month(header.ReturnDate) as varchar) + '-' + cast(day(header.ReturnDate) as varchar) as Period, 'DO-RETURN' as Module, header.Number as Number, header.ReturnDate as TransactionDate, detail.ProductId, n.Name as ProjectName, w.Name as WarehouseName, detail.QtyReturn * +1 as Qty from Tenant c
inner join SalesReturn header on c.TenantId = header.TenantId
inner join SalesReturnDetail detail on header.Id = detail.SalesReturnId
inner join Project n on header.ProjectId = n.id
inner join Warehouse w on header.WarehouseId = w.Id
where c.TenantId = {tenantId}


union all

--transfer from (out)
select cast(year(trfh.TransferDate) as varchar) + '-' + cast(month(trfh.TransferDate) as varchar) + '-' + cast(day(trfh.TransferDate) as varchar) as Period, 'TRANSFER' as Module, trfh.Number as Number, trfh.TransferDate as TransactionDate, trfd.ProductId, n.Name as ProjectName, w.Name as WarehouseName, trfd.Qty * -1 as Qty from Tenant c
inner join TransferOrder trfh on c.TenantId = trfh.TenantId
inner join TransferOrderDetail trfd on trfh.Id = trfd.TransferOrderId
inner join Project n on trfh.ProjectFromId = n.Id
inner join Warehouse w on trfh.FromId = w.Id
where c.TenantId = {tenantId}

union all

--transfer to (in)
select cast(year(trfh.TransferDate) as varchar) + '-' + cast(month(trfh.TransferDate) as varchar) + '-' + cast(day(trfh.TransferDate) as varchar) as Period, 'TRANSFER' as Module, trfh.Number as Number, trfh.TransferDate as TransactionDate, trfd.ProductId, n.Name as ProjectName, w.Name as WarehouseName, trfd.Qty * +1 as Qty from Tenant c
inner join TransferOrder trfh on c.TenantId = trfh.TenantId
inner join TransferOrderDetail trfd on trfh.Id = trfd.TransferOrderId
inner join Project n on trfh.ProjectToId = n.Id
inner join Warehouse w on trfh.ToId = w.Id
where c.TenantId = {tenantId}

union all

--positive adjustment (in)
select cast(year(header.AdjustmentDate) as varchar) + '-' + cast(month(header.AdjustmentDate) as varchar) + '-' + cast(day(header.AdjustmentDate) as varchar) as Period, 'ADJ-PLUS' as Module, header.Number as Number, header.AdjustmentDate as TransactionDate, detail.ProductId, n.Name as ProjectName, w.Name as WarehouseName, detail.Qty * +1 as Qty from Tenant c
inner join PositiveAdjustment header on c.TenantId = header.TenantId
inner join PositiveAdjustmentDetail detail on header.Id = detail.PositiveAdjustmentId
inner join Project n on header.ProjectId = n.id
inner join Warehouse w on header.WarehouseId = w.Id
where c.TenantId = {tenantId}

union all

--negative adjustment (out)
select cast(year(header.AdjustmentDate) as varchar) + '-' + cast(month(header.AdjustmentDate) as varchar) + '-' + cast(day(header.AdjustmentDate) as varchar) as Period, 'ADJ-MINUS' as Module, header.Number as Number, header.AdjustmentDate as TransactionDate, detail.ProductId, n.Name as ProjectName, w.Name as WarehouseName, detail.Qty * -1 as Qty from Tenant c
inner join NegativeAdjustment header on c.TenantId = header.TenantId
inner join NegativeAdjustmentDetail detail on header.Id = detail.NegativeAdjustmentId
inner join Project n on header.ProjectId = n.id
inner join Warehouse w on header.WarehouseId = w.Id
where c.TenantId = {tenantId}

)
select ROW_NUMBER() OVER(ORDER BY (select s.TransactionDate) DESC) as Id, s.Period, s.Module, s.Number, s.TransactionDate, p.Name as ProductName, p.InternalCode as InternalCode, p.Barcode as Barcode,s.ProjectName as ProjectName, s.WarehouseName as WarehouseName, s.Qty as Qty, u.Name as Uom 
from stock s
inner join Product p on s.ProductId = p.Id 
inner join Uom u on p.UomId = u.Id
where s.ProjectName like '%{request.ContainsText}%' or s.WarehouseName like '%{request.ContainsText}%' or p.Name like '%{request.ContainsText}%' or s.Number like '%{request.ContainsText}%' or s.Period like '%{request.ContainsText}%' or s.Module like '%{request.ContainsText}%'

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