namespace Indotalent.Inventory {
    export interface PositiveAdjustmentDetailRow {
        Id?: number;
        PositiveAdjustmentId?: number;
        ProductId?: number;
        Qty?: number;
        PositiveAdjustmentNumber?: string;
        ProductName?: string;
        TenantId?: number;
        TenantName?: string;
        InsertUserId?: number;
        InsertDate?: string;
        UpdateUserId?: number;
        UpdateDate?: string;
    }

    export namespace PositiveAdjustmentDetailRow {
        export const idProperty = 'Id';
        export const localTextPrefix = 'Inventory.PositiveAdjustmentDetail';
        export const lookupKey = 'Inventory.PositiveAdjustmentDetail';

        export function getLookup(): Q.Lookup<PositiveAdjustmentDetailRow> {
            return Q.getLookup<PositiveAdjustmentDetailRow>('Inventory.PositiveAdjustmentDetail');
        }
        export const deletePermission = 'Inventory:PositiveAdjustment';
        export const insertPermission = 'Inventory:PositiveAdjustment';
        export const readPermission = 'Inventory:PositiveAdjustment';
        export const updatePermission = 'Inventory:PositiveAdjustment';

        export declare const enum Fields {
            Id = "Id",
            PositiveAdjustmentId = "PositiveAdjustmentId",
            ProductId = "ProductId",
            Qty = "Qty",
            PositiveAdjustmentNumber = "PositiveAdjustmentNumber",
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
