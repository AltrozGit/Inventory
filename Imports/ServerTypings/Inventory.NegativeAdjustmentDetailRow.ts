namespace Indotalent.Inventory {
    export interface NegativeAdjustmentDetailRow {
        Id?: number;
        NegativeAdjustmentId?: number;
        ProductId?: number;
        Qty?: number;
        NegativeAdjustmentNumber?: string;
        ProductName?: string;
        TenantId?: number;
        TenantName?: string;
        InsertUserId?: number;
        InsertDate?: string;
        UpdateUserId?: number;
        UpdateDate?: string;
    }

    export namespace NegativeAdjustmentDetailRow {
        export const idProperty = 'Id';
        export const localTextPrefix = 'Inventory.NegativeAdjustmentDetail';
        export const lookupKey = 'Inventory.NegativeAdjustmentDetail';

        export function getLookup(): Q.Lookup<NegativeAdjustmentDetailRow> {
            return Q.getLookup<NegativeAdjustmentDetailRow>('Inventory.NegativeAdjustmentDetail');
        }
        export const deletePermission = 'Inventory:NegativeAdjustment';
        export const insertPermission = 'Inventory:NegativeAdjustment';
        export const readPermission = 'Inventory:NegativeAdjustment';
        export const updatePermission = 'Inventory:NegativeAdjustment';

        export declare const enum Fields {
            Id = "Id",
            NegativeAdjustmentId = "NegativeAdjustmentId",
            ProductId = "ProductId",
            Qty = "Qty",
            NegativeAdjustmentNumber = "NegativeAdjustmentNumber",
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
