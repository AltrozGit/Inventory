namespace Indotalent.Purchase {
    export interface PurchaseReceiptRow {
        Id?: number;
        Number?: string;
        Description?: string;
        ExternalReferenceNumber?: string;
        ProcurementGroup?: string;
        ReceiptDate?: string;
        PurchaseOrderId?: number;
        ProjectId?: number;
        WarehouseId?: number;
        LocationId?: number;
        TotalQtyReceive?: number;
        PurchaseOrderNumber?: string;
        ProjectName?: string;
        WarehouseName?: string;
        LocationName?: string;
        ItemList?: PurchaseReceiptDetailRow[];
        VendorId?: number;
        VendorName?: string;
        InvoiceNumber?: string;
        InvoiceDate?: string;
        TenantId?: number;
        TenantName?: string;
        IsBillCreate?: boolean;
        IsIssueCreated?: boolean;
        Status?: Web.Modules.Purchase.PurchaseReceipt.Status;
        IsPReturnCreated?: boolean;
    }

    export namespace PurchaseReceiptRow {
        export const idProperty = 'Id';
        export const nameProperty = 'Number';
        export const localTextPrefix = 'Purchase.PurchaseReceipt';
        export const lookupKey = 'Purchase.PurchaseReceipt';

        export function getLookup(): Q.Lookup<PurchaseReceiptRow> {
            return Q.getLookup<PurchaseReceiptRow>('Purchase.PurchaseReceipt');
        }
        export const deletePermission = 'Purchase:PurchaseReceipt';
        export const insertPermission = 'Purchase:PurchaseReceipt';
        export const readPermission = 'Purchase:PurchaseReceipt';
        export const updatePermission = 'Purchase:PurchaseReceipt';

        export declare const enum Fields {
            Id = "Id",
            Number = "Number",
            Description = "Description",
            ExternalReferenceNumber = "ExternalReferenceNumber",
            ProcurementGroup = "ProcurementGroup",
            ReceiptDate = "ReceiptDate",
            PurchaseOrderId = "PurchaseOrderId",
            ProjectId = "ProjectId",
            WarehouseId = "WarehouseId",
            LocationId = "LocationId",
            TotalQtyReceive = "TotalQtyReceive",
            PurchaseOrderNumber = "PurchaseOrderNumber",
            ProjectName = "ProjectName",
            WarehouseName = "WarehouseName",
            LocationName = "LocationName",
            ItemList = "ItemList",
            VendorId = "VendorId",
            VendorName = "VendorName",
            InvoiceNumber = "InvoiceNumber",
            InvoiceDate = "InvoiceDate",
            TenantId = "TenantId",
            TenantName = "TenantName",
            IsBillCreate = "IsBillCreate",
            IsIssueCreated = "IsIssueCreated",
            Status = "Status",
            IsPReturnCreated = "IsPReturnCreated"
        }
    }
}
