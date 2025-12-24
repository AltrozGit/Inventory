namespace Indotalent.Inventory {
    export interface MovementRow {
        Id?: number;
        Number?: string;
        Period?: string;
        Module?: string;
        TransactionDate?: string;
        ProductName?: string;
        InternalCode?: string;
        Barcode?: string;
        ProjectName?: string;
        WarehouseName?: string;
        Qty?: number;
        Uom?: string;
    }

    export namespace MovementRow {
        export const idProperty = 'Id';
        export const nameProperty = 'ProductName';
        export const localTextPrefix = 'Inventory.Movement';
        export const lookupKey = 'Inventory.Movement';

        export function getLookup(): Q.Lookup<MovementRow> {
            return Q.getLookup<MovementRow>('Inventory.Movement');
        }
        export const deletePermission = 'Inventory:Movement';
        export const insertPermission = 'Inventory:Movement';
        export const readPermission = 'Inventory:Movement';
        export const updatePermission = 'Inventory:Movement';

        export declare const enum Fields {
            Id = "Id",
            Number = "Number",
            Period = "Period",
            Module = "Module",
            TransactionDate = "TransactionDate",
            ProductName = "ProductName",
            InternalCode = "InternalCode",
            Barcode = "Barcode",
            ProjectName = "ProjectName",
            WarehouseName = "WarehouseName",
            Qty = "Qty",
            Uom = "Uom"
        }
    }
}
