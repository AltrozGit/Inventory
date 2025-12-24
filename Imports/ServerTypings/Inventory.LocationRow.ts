namespace Indotalent.Inventory {
    export interface LocationRow {
        Id?: number;
        Name?: string;
        Description?: string;
        TenantId?: number;
        TenantName?: string;
        InsertUserId?: number;
        InsertDate?: string;
        UpdateUserId?: number;
        UpdateDate?: string;
    }

    export namespace LocationRow {
        export const idProperty = 'Id';
        export const nameProperty = 'Name';
        export const localTextPrefix = 'Inventory.Location';
        export const lookupKey = 'Inventory.Location';

        export function getLookup(): Q.Lookup<LocationRow> {
            return Q.getLookup<LocationRow>('Inventory.Location');
        }
        export const deletePermission = 'Inventory:Location';
        export const insertPermission = 'Inventory:Location';
        export const readPermission = 'Inventory:Location';
        export const updatePermission = 'Inventory:Location';

        export declare const enum Fields {
            Id = "Id",
            Name = "Name",
            Description = "Description",
            TenantId = "TenantId",
            TenantName = "TenantName",
            InsertUserId = "InsertUserId",
            InsertDate = "InsertDate",
            UpdateUserId = "UpdateUserId",
            UpdateDate = "UpdateDate"
        }
    }
}
