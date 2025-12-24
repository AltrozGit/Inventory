namespace Indotalent.Inventory {
    export interface NegativeAdjustmentRow {
        Id?: number;
        Number?: string;
        Description?: string;
        AdjustmentDate?: string;
        ProjectId?: number;
        WarehouseId?: number;
        LocationId?: number;
        TotalQty?: number;
        ProjectName?: string;
        WarehouseName?: string;
        LocationName?: string;
        ItemList?: NegativeAdjustmentDetailRow[];
        TenantId?: number;
        TenantName?: string;
        InsertUserId?: number;
        InsertDate?: string;
        UpdateUserId?: number;
        UpdateDate?: string;
    }

    export namespace NegativeAdjustmentRow {
        export const idProperty = 'Id';
        export const nameProperty = 'Number';
        export const localTextPrefix = 'Inventory.NegativeAdjustment';
        export const lookupKey = 'Inventory.NegativeAdjustment';

        export function getLookup(): Q.Lookup<NegativeAdjustmentRow> {
            return Q.getLookup<NegativeAdjustmentRow>('Inventory.NegativeAdjustment');
        }
        export const deletePermission = 'Inventory:NegativeAdjustment';
        export const insertPermission = 'Inventory:NegativeAdjustment';
        export const readPermission = 'Inventory:NegativeAdjustment';
        export const updatePermission = 'Inventory:NegativeAdjustment';

        export declare const enum Fields {
            Id = "Id",
            Number = "Number",
            Description = "Description",
            AdjustmentDate = "AdjustmentDate",
            ProjectId = "ProjectId",
            WarehouseId = "WarehouseId",
            LocationId = "LocationId",
            TotalQty = "TotalQty",
            ProjectName = "ProjectName",
            WarehouseName = "WarehouseName",
            LocationName = "LocationName",
            ItemList = "ItemList",
            TenantId = "TenantId",
            TenantName = "TenantName",
            InsertUserId = "InsertUserId",
            InsertDate = "InsertDate",
            UpdateUserId = "UpdateUserId",
            UpdateDate = "UpdateDate"
        }
    }
}
