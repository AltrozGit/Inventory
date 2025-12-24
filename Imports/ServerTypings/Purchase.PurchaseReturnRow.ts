namespace Indotalent.Purchase {
    export interface PurchaseReturnRow {
        Id?: number;
        Number?: string;
        Description?: string;
        ProcurementGroup?: string;
        ReturnDate?: string;
        PurchaseOrderId?: number;
        PurchaseReceiptId?: number;
        ProjectId?: number;
        WarehouseId?: number;
        LocationId?: number;
        TotalQtyReturn?: number;
        PurchaseReceiptNumber?: string;
        ProjectName?: string;
        WarehouseName?: string;
        LocationName?: string;
        ItemList?: PurchaseReturnDetailRow[];
        VendorId?: number;
        TenantId?: number;
        TenantName?: string;
    }

    export namespace PurchaseReturnRow {
        export const idProperty = 'Id';
        export const nameProperty = 'Number';
        export const localTextPrefix = 'Purchase.PurchaseReturn';
        export const lookupKey = 'Purchase.PurchaseReturn';

        export function getLookup(): Q.Lookup<PurchaseReturnRow> {
            return Q.getLookup<PurchaseReturnRow>('Purchase.PurchaseReturn');
        }
        export const deletePermission = 'Purchase:PurchaseReturn';
        export const insertPermission = 'Purchase:PurchaseReturn';
        export const readPermission = 'Purchase:PurchaseReturn';
        export const updatePermission = 'Purchase:PurchaseReturn';

        export declare const enum Fields {
            Id = "Id",
            Number = "Number",
            Description = "Description",
            ProcurementGroup = "ProcurementGroup",
            ReturnDate = "ReturnDate",
            PurchaseOrderId = "PurchaseOrderId",
            PurchaseReceiptId = "PurchaseReceiptId",
            ProjectId = "ProjectId",
            WarehouseId = "WarehouseId",
            LocationId = "LocationId",
            TotalQtyReturn = "TotalQtyReturn",
            PurchaseReceiptNumber = "PurchaseReceiptNumber",
            ProjectName = "ProjectName",
            WarehouseName = "WarehouseName",
            LocationName = "LocationName",
            ItemList = "ItemList",
            VendorId = "VendorId",
            TenantId = "TenantId",
            TenantName = "TenantName"
        }
    }
}
