namespace Indotalent.Common.DashboardInventory {
    export interface MinStockRow {
        Id?: number;
        ProductName?: string;
        WarehouseName?: string;
        Qty?: number;
        MinimumQty?: number;
        Uom?: string;
    }

    export namespace MinStockRow {
        export const idProperty = 'Id';
        export const nameProperty = 'ProductName';
        export const localTextPrefix = 'Common.DashboardInventory.MinStock';
        export const deletePermission = '*';
        export const insertPermission = '*';
        export const readPermission = '*';
        export const updatePermission = '*';

        export declare const enum Fields {
            Id = "Id",
            ProductName = "ProductName",
            WarehouseName = "WarehouseName",
            Qty = "Qty",
            MinimumQty = "MinimumQty",
            Uom = "Uom"
        }
    }
}
