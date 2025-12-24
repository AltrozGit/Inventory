IF EXISTS(select 1 from sys.views where name='vwAvailableStock' and type='v')
DROP VIEW vwAvailableStock;
GO
CREATE VIEW [vwAvailableStock] AS
with stock as
(
--purchase receipt (in)
select 
	detail.ProductId, 
	proj.Id as ProjectID, 
	proj.Name as ProjectName, 
	ware.Id as WarehouseId, 
	ware.Name as WarehouseName, 
	detail.QtyReceive * +1 as Qty,
	c.TenantId as TenantId
from Tenant c
inner join PurchaseReceipt header on c.TenantId = header.TenantId
inner join PurchaseReceiptDetail detail on header.Id = detail.PurchaseReceiptId
inner join Project proj on header.ProjectId = proj.Id
inner join Warehouse ware on header.WarehouseId = ware.Id

union all

--purchase return (out)
select 
	detail.ProductId, 
	proj.Id as ProjectID, 
	proj.Name as ProjectName, 
	ware.Id as WarehouseId, 
	ware.Name as WarehouseName, 
	detail.QtyReturn * -1 as Qty,
	c.TenantId as TenantId
from Tenant c
inner join PurchaseReturn header on c.TenantId = header.TenantId
inner join PurchaseReturnDetail detail on header.Id = detail.PurchaseReturnId
inner join Project proj on header.ProjectId = proj.Id
inner join Warehouse ware on header.WarehouseId = ware.Id

union all

--transfer from (out)
select 
	trfd.ProductId, 
	proj.Id as ProjectID, 
	proj.Name as ProjectName, 
	ware.Id as WarehouseId, 
	ware.Name as WarehouseName, 
	trfd.Qty * -1 as Qty,
	c.TenantId as TenantId
from Tenant c
inner join TransferOrder trfh on c.TenantId = trfh.TenantId
inner join TransferOrderDetail trfd on trfh.Id = trfd.TransferOrderId
inner join Project proj on trfh.ProjectFromId = proj.Id
inner join Warehouse ware on trfh.FromId = ware.Id

union all

--transfer to (in)
select 
	trfd.ProductId, 
	proj.Id as ProjectID, 
	proj.Name as ProjectName, 
	ware.Id as WarehouseId, 
	ware.Name as WarehouseName, 
	trfd.Qty * +1 as Qty,
	c.TenantId as TenantId
from Tenant c
inner join TransferOrder trfh on c.TenantId = trfh.TenantId
inner join TransferOrderDetail trfd on trfh.Id = trfd.TransferOrderId
inner join Project proj on trfh.ProjectToId = proj.Id
inner join Warehouse ware on trfh.ToId = ware.Id

union all

--positive adjustment (in)
select 
	detail.ProductId, 
	proj.Id as ProjectID, 
	proj.Name as ProjectName, 
	ware.Id as WarehouseId, 
	ware.Name as WarehouseName, 
	detail.Qty * +1 as Qty,
	c.TenantId as TenantId
from Tenant c
inner join PositiveAdjustment header on c.TenantId = header.TenantId
inner join PositiveAdjustmentDetail detail on header.Id = detail.PositiveAdjustmentId
inner join Project proj on header.ProjectId = proj.Id
inner join Warehouse ware on header.WarehouseId = ware.Id

union all

--negative adjustment (out)
select 
	detail.ProductId, 
	proj.Id as ProjectID, 
	proj.Name as ProjectName, 
	ware.Id as WarehouseId, 
	ware.Name as WarehouseName, 
	detail.Qty * -1 as Qty,
	c.TenantId as TenantId
from Tenant c
inner join NegativeAdjustment header on c.TenantId = header.TenantId
inner join NegativeAdjustmentDetail detail on header.Id = detail.NegativeAdjustmentId
inner join Project proj on header.ProjectId = proj.Id
inner join Warehouse ware on header.WarehouseId = ware.Id

union all

--material issue (out)
select 
	detail.ProductId, 
	proj.Id as ProjectID, 
	proj.Name as ProjectName, 
	ware.Id as WarehouseId, 
	ware.Name as WarehouseName, 
	detail.QtyIssue * -1 as Qty,
	c.TenantId as TenantId
from Tenant c
inner join MaterialIssue header on c.TenantId = header.TenantId
inner join MaterialIssueDetail detail on header.Id = detail.MaterialIssueId
inner join MaterialRequest mr on header.MaterialRequestId = mr.Id
inner join Project proj on mr.ProjectId = proj.Id
inner join Warehouse ware on header.WarehouseId = ware.Id

)

select 
	ROW_NUMBER() OVER(ORDER BY s.ProjectName ASC,
	s.WarehouseName ASC) as Id,
	MAX(s.ProjectID) as ProjectId, 
	MAX(s.ProjectName) as ProjectName, 
	MAX(s.WarehouseId) as WarehouseId, 
	MAX(s.WarehouseName) as WarehouseName, 
	MAX(s.ProductId) as ProductId, 
	MAX(p.Name) as ProductName, 
	SUM(s.Qty) as AvailableStock, 
	MAX(p.InternalCode) as InternalCode, 
	MAX(p.Barcode) as Barcode, 
	MAX(u.Name) as Uom, 
	MAX(s.TenantId) as TenantId, 
	Max(p.MinimumQty) as MinimumQty
from stock s
inner join Product p on s.ProductId = p.Id
inner join Uom u on p.UomId = u.Id
group by s.ProductId, s.ProjectID, s.ProjectName , s.WarehouseId, s.WarehouseName