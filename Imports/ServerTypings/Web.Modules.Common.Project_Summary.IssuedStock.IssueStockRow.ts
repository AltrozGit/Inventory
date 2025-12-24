namespace Indotalent.Web.Modules.Common.Project_Summary.IssuedStock {
    export interface IssueStockRow {
        Id?: number;
        MaterialIssueId?: number;
        ProductId?: number;
        QtyIssue?: number;
        QtyRequest?: number;
        TenantId?: number;
        TenantName?: string;
        MaterialIssueNumber?: string;
        MaterialRequestId?: number;
        MaterialRequestNumber?: string;
        PurchasePrice?: number;
        PurchaseTaxId?: number;
        ProductName?: string;
        AvailableStock?: number;
        ProjectId?: number;
        ProjectName?: string;
        WarehouseId?: number;
        WarehouseName?: string;
        TaxRatePercentage?: number;
    }

    export namespace IssueStockRow {
        export const idProperty = 'Id';
        export const nameProperty = 'MaterialIssueId';
        export const localTextPrefix = 'Web.Modules.Common.Project_Summary.IssuedStock.IssueStock';
        export const deletePermission = '*';
        export const insertPermission = '*';
        export const readPermission = '*';
        export const updatePermission = '*';

        export declare const enum Fields {
            Id = "Id",
            MaterialIssueId = "MaterialIssueId",
            ProductId = "ProductId",
            QtyIssue = "QtyIssue",
            QtyRequest = "QtyRequest",
            TenantId = "TenantId",
            TenantName = "TenantName",
            MaterialIssueNumber = "MaterialIssueNumber",
            MaterialRequestId = "MaterialRequestId",
            MaterialRequestNumber = "MaterialRequestNumber",
            PurchasePrice = "PurchasePrice",
            PurchaseTaxId = "PurchaseTaxId",
            ProductName = "ProductName",
            AvailableStock = "AvailableStock",
            ProjectId = "ProjectId",
            ProjectName = "ProjectName",
            WarehouseId = "WarehouseId",
            WarehouseName = "WarehouseName",
            TaxRatePercentage = "TaxRatePercentage"
        }
    }
}
