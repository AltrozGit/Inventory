namespace Indotalent.Inventory {
    export interface TransferOrderDetailRow {
        Id?: number;
        TransferOrderId?: number;
        ProductId?: number;
        Qty?: number;
        TransferOrderNumber?: string;
        ProductName?: string;
        TenantId?: number;
        TenantName?: string;
        InsertUserId?: number;
        InsertDate?: string;
        UpdateUserId?: number;
        UpdateDate?: string;
    }

    export namespace TransferOrderDetailRow {
        export const idProperty = 'Id';
        export const localTextPrefix = 'Inventory.TransferOrderDetail';
        export const lookupKey = 'Inventory.TransferOrderDetail';

        export function getLookup(): Q.Lookup<TransferOrderDetailRow> {
            return Q.getLookup<TransferOrderDetailRow>('Inventory.TransferOrderDetail');
        }
        export const deletePermission = 'Inventory:TransferOrder';
        export const insertPermission = 'Inventory:TransferOrder';
        export const readPermission = 'Inventory:TransferOrder';
        export const updatePermission = 'Inventory:TransferOrder';

        export declare const enum Fields {
            Id = "Id",
            TransferOrderId = "TransferOrderId",
            ProductId = "ProductId",
            Qty = "Qty",
            TransferOrderNumber = "TransferOrderNumber",
            ProductName = "ProductName",
            TenantId = "TenantId",
            TenantName = "TenantName",
            InsertUserId = "InsertUserId",
            InsertDate = "InsertDate",
            UpdateUserId = "UpdateUserId",
            UpdateDate = "UpdateDate"
        }
    }
}
