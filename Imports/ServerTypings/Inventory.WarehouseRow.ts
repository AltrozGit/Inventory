namespace Indotalent.Inventory {
    export interface WarehouseRow {
        Id?: number;
        Name?: string;
        Description?: string;
        Street?: string;
        City?: string;
        State?: string;
        ZipCode?: string;
        Phone?: string;
        Email?: string;
        TenantId?: number;
        TenantName?: string;
        InsertUserId?: number;
        InsertDate?: string;
        UpdateUserId?: number;
        UpdateDate?: string;
    }

    export namespace WarehouseRow {
        export const idProperty = 'Id';
        export const nameProperty = 'Name';
        export const localTextPrefix = 'Inventory.Warehouse';
        export const lookupKey = 'Inventory.Warehouse';

        export function getLookup(): Q.Lookup<WarehouseRow> {
            return Q.getLookup<WarehouseRow>('Inventory.Warehouse');
        }
        export const deletePermission = 'Inventory:Warehouse';
        export const insertPermission = 'Inventory:Warehouse';
        export const readPermission = 'Inventory:Warehouse';
        export const updatePermission = 'Inventory:Warehouse';

        export declare const enum Fields {
            Id = "Id",
            Name = "Name",
            Description = "Description",
            Street = "Street",
            City = "City",
            State = "State",
            ZipCode = "ZipCode",
            Phone = "Phone",
            Email = "Email",
            TenantId = "TenantId",
            TenantName = "TenantName",
            InsertUserId = "InsertUserId",
            InsertDate = "InsertDate",
            UpdateUserId = "UpdateUserId",
            UpdateDate = "UpdateDate"
        }
    }
}
