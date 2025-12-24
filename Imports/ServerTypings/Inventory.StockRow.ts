namespace Indotalent.Inventory {
    export interface StockRow {
        Id?: number;
        ProductName?: string;
        InternalCode?: string;
        Barcode?: string;
        ProjectName?: string;
        WarehouseName?: string;
        Qty?: number;
        Uom?: string;
        TotalPrice?: number;
    }

    export namespace StockRow {
        export const idProperty = 'Id';
        export const nameProperty = 'ProductName';
        export const localTextPrefix = 'Inventory.Stock';
        export const lookupKey = 'Inventory.Stock';

        export function getLookup(): Q.Lookup<StockRow> {
            return Q.getLookup<StockRow>('Inventory.Stock');
        }
        export const deletePermission = 'Inventory:Stock';
        export const insertPermission = 'Inventory:Stock';
        export const readPermission = 'Inventory:Stock';
        export const updatePermission = 'Inventory:Stock';

        export declare const enum Fields {
            Id = "Id",
            ProductName = "ProductName",
            InternalCode = "InternalCode",
            Barcode = "Barcode",
            ProjectName = "ProjectName",
            WarehouseName = "WarehouseName",
            Qty = "Qty",
            Uom = "Uom",
            TotalPrice = "TotalPrice"
        }
    }
}
