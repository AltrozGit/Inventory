namespace Indotalent.Inventory {
    export interface PositiveAdjustmentRow {
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
        ItemList?: PositiveAdjustmentDetailRow[];
        TenantId?: number;
        TenantName?: string;
        InsertUserId?: number;
        InsertDate?: string;
        UpdateUserId?: number;
        UpdateDate?: string;
    }

    export namespace PositiveAdjustmentRow {
        export const idProperty = 'Id';
        export const nameProperty = 'Number';
        export const localTextPrefix = 'Inventory.PositiveAdjustment';
        export const lookupKey = 'Inventory.PositiveAdjustment';

        export function getLookup(): Q.Lookup<PositiveAdjustmentRow> {
            return Q.getLookup<PositiveAdjustmentRow>('Inventory.PositiveAdjustment');
        }
        export const deletePermission = 'Inventory:PositiveAdjustment';
        export const insertPermission = 'Inventory:PositiveAdjustment';
        export const readPermission = 'Inventory:PositiveAdjustment';
        export const updatePermission = 'Inventory:PositiveAdjustment';

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
