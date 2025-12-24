namespace Indotalent.Common.DashboardInventory {
    export interface MostSoldRow {
        Id?: number;
        ProductName?: string;
        Qty?: number;
        Uom?: string;
    }

    export namespace MostSoldRow {
        export const idProperty = 'Id';
        export const nameProperty = 'ProductName';
        export const localTextPrefix = 'Common.DashboardInventory.MostSold';
        export const deletePermission = '*';
        export const insertPermission = '*';
        export const readPermission = '*';
        export const updatePermission = '*';

        export declare const enum Fields {
            Id = "Id",
            ProductName = "ProductName",
            Qty = "Qty",
            Uom = "Uom"
        }
    }
}
