
using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20250503180810)]
    public class DefaultDB_20250503_180810_AlterAvailableStockSQLView : ForwardOnlyMigration
    {

        public override void Up()
        {
            // Here, you execute the SQL to create the view
            Execute.Sql(@"
                ALTER VIEW [dbo].[vwAvailableStock] AS
WITH stock AS (
    --purchase receipt (in)
    SELECT 
        detail.ProductId, 
        proj.Id as ProjectID, 
        proj.Name as ProjectName, 
        ware.Id as WarehouseId, 
        ware.Name as WarehouseName, 
        detail.QtyReceive * +1 as Qty,
        c.TenantId as TenantId,
        pod.Price as UnitPrice,

      ((detail.QtyReceive * (pod.Price ))-pod.Discount)+ ((((detail.QtyReceive * (pod.Price ))-pod.Discount)*pod.TaxPercentage)/100) as TotalPrice
    FROM Tenant c
    INNER JOIN PurchaseReceipt header ON c.TenantId = header.TenantId
    INNER JOIN PurchaseReceiptDetail detail ON header.Id = detail.PurchaseReceiptId
    INNER JOIN PurchaseOrder po ON header.PurchaseOrderId = po.Id
    INNER JOIN PurchaseOrderDetail pod ON po.Id = pod.PurchaseOrderId AND pod.ProductId = detail.ProductId
    INNER JOIN Project proj ON header.ProjectId = proj.Id
    INNER JOIN Warehouse ware ON header.WarehouseId = ware.Id

    UNION ALL

    --purchase return (out)
    SELECT 
        detail.ProductId, 
        proj.Id as ProjectID, 
        proj.Name as ProjectName, 
        ware.Id as WarehouseId, 
        ware.Name as WarehouseName, 
        detail.QtyReturn * -1 as Qty,
        c.TenantId as TenantId,
        0 as UnitPrice,
        0 as TotalPrice
    FROM Tenant c
    INNER JOIN PurchaseReturn header ON c.TenantId = header.TenantId
    INNER JOIN PurchaseReturnDetail detail ON header.Id = detail.PurchaseReturnId
    INNER JOIN Project proj ON header.ProjectId = proj.Id
    INNER JOIN Warehouse ware ON header.WarehouseId = ware.Id

    UNION ALL

    --transfer from (out)
    SELECT 
        trfd.ProductId, 
        proj.Id as ProjectID, 
        proj.Name as ProjectName, 
        ware.Id as WarehouseId, 
        ware.Name as WarehouseName, 
        trfd.Qty * -1 as Qty,
        c.TenantId as TenantId,
        0 as UnitPrice,
        0 as TotalPrice
    FROM Tenant c
    INNER JOIN TransferOrder trfh ON c.TenantId = trfh.TenantId
    INNER JOIN TransferOrderDetail trfd ON trfh.Id = trfd.TransferOrderId
    INNER JOIN Project proj ON trfh.ProjectFromId = proj.Id
    INNER JOIN Warehouse ware ON trfh.FromId = ware.Id

    UNION ALL

    --transfer to (in)
    SELECT 
        trfd.ProductId, 
        proj.Id as ProjectID, 
        proj.Name as ProjectName, 
        ware.Id as WarehouseId, 
        ware.Name as WarehouseName, 
        trfd.Qty * +1 as Qty,
        c.TenantId as TenantId,
        0 as UnitPrice,
        0 as TotalPrice
    FROM Tenant c
    INNER JOIN TransferOrder trfh ON c.TenantId = trfh.TenantId
    INNER JOIN TransferOrderDetail trfd ON trfh.Id = trfd.TransferOrderId
    INNER JOIN Project proj ON trfh.ProjectToId = proj.Id
    INNER JOIN Warehouse ware ON trfh.ToId = ware.Id

    UNION ALL

    --positive adjustment (in)
    SELECT 
        detail.ProductId, 
        proj.Id as ProjectID, 
        proj.Name as ProjectName, 
        ware.Id as WarehouseId, 
        ware.Name as WarehouseName, 
        detail.Qty * +1 as Qty,
        c.TenantId as TenantId,
        0 as UnitPrice,
        0 as TotalPrice
    FROM Tenant c
    INNER JOIN PositiveAdjustment header ON c.TenantId = header.TenantId
    INNER JOIN PositiveAdjustmentDetail detail ON header.Id = detail.PositiveAdjustmentId
    INNER JOIN Project proj ON header.ProjectId = proj.Id
    INNER JOIN Warehouse ware ON header.WarehouseId = ware.Id

    UNION ALL

    --negative adjustment (out)
    SELECT 
        detail.ProductId, 
        proj.Id as ProjectID, 
        proj.Name as ProjectName, 
        ware.Id as WarehouseId, 
        ware.Name as WarehouseName, 
        detail.Qty * -1 as Qty,
        c.TenantId as TenantId,
        0 as UnitPrice,
        0 as TotalPrice
    FROM Tenant c
    INNER JOIN NegativeAdjustment header ON c.TenantId = header.TenantId
    INNER JOIN NegativeAdjustmentDetail detail ON header.Id = detail.NegativeAdjustmentId
    INNER JOIN Project proj ON header.ProjectId = proj.Id
    INNER JOIN Warehouse ware ON header.WarehouseId = ware.Id

    UNION ALL

    --material issue (out)
    SELECT 
        detail.ProductId, 
        proj.Id as ProjectID, 
        proj.Name as ProjectName, 
        ware.Id as WarehouseId, 
        ware.Name as WarehouseName, 
        detail.QtyIssue * -1 as Qty,
        c.TenantId as TenantId,
        0 as UnitPrice,
        0 as TotalPrice
    FROM Tenant c
    INNER JOIN MaterialIssue header ON c.TenantId = header.TenantId
    INNER JOIN MaterialIssueDetail detail ON header.Id = detail.MaterialIssueId
    INNER JOIN MaterialRequest mr ON header.MaterialRequestId = mr.Id
    INNER JOIN Project proj ON mr.ProjectId = proj.Id
    INNER JOIN Warehouse ware ON header.WarehouseId = ware.Id
)

SELECT 
    ROW_NUMBER() OVER(ORDER BY s.ProjectName ASC, s.WarehouseName ASC) as Id,
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
    MAX(p.MinimumQty) as MinimumQty,
    SUM(s.TotalPrice) as TotalPrice
FROM stock s
INNER JOIN Product p ON s.ProductId = p.Id
INNER JOIN Uom u ON p.UomId = u.Id
GROUP BY s.ProductId, s.ProjectID, s.ProjectName, s.WarehouseId, s.WarehouseName;
            ");
        }



    }
}


