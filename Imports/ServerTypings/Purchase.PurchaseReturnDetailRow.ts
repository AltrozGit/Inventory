namespace Indotalent.Purchase {
    export interface PurchaseReturnDetailRow {
        Id?: number;
        PurchaseReturnId?: number;
        ProductId?: number;
        QtyReturn?: number;
        PurchaseReturnNumber?: string;
        ProductName?: string;
        TenantId?: number;
        TenantName?: string;
    }

    export namespace PurchaseReturnDetailRow {
        export const idProperty = 'Id';
        export const nameProperty = 'ProductName';
        export const localTextPrefix = 'Purchase.PurchaseReturnDetail';
        export const lookupKey = 'Purchase.PurchaseReturnDetail';

        export function getLookup(): Q.Lookup<PurchaseReturnDetailRow> {
            return Q.getLookup<PurchaseReturnDetailRow>('Purchase.PurchaseReturnDetail');
        }
        export const deletePermission = 'Purchase:PurchaseReturnDetail';
        export const insertPermission = 'Purchase:PurchaseReturnDetail';
        export const readPermission = 'Purchase:PurchaseReturnDetail';
        export const updatePermission = 'Purchase:PurchaseReturnDetail';

        export declare const enum Fields {
            Id = "Id",
            PurchaseReturnId = "PurchaseReturnId",
            ProductId = "ProductId",
            QtyReturn = "QtyReturn",
            PurchaseReturnNumber = "PurchaseReturnNumber",
            ProductName = "ProductName",
            TenantId = "TenantId",
            TenantName = "TenantName"
        }
    }
}
