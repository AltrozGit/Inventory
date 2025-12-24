namespace Indotalent.Sales {
    export interface SalesDeliveryDetailRow {
        Id?: number;
        SalesDeliveryId?: number;
        ProductId?: number;
        QtyDelivered?: number;
        SalesDeliveryNumber?: string;
        ProductName?: string;
        TenantId?: number;
        TenantName?: string;
        InsertUserId?: number;
        InsertDate?: string;
        UpdateUserId?: number;
        UpdateDate?: string;
    }

    export namespace SalesDeliveryDetailRow {
        export const idProperty = 'Id';
        export const nameProperty = 'ProductName';
        export const localTextPrefix = 'Sales.SalesDeliveryDetail';
        export const lookupKey = 'Sales.SalesDeliveryDetail';

        export function getLookup(): Q.Lookup<SalesDeliveryDetailRow> {
            return Q.getLookup<SalesDeliveryDetailRow>('Sales.SalesDeliveryDetail');
        }
        export const deletePermission = 'Sales:SalesDeliveryDetail';
        export const insertPermission = 'Sales:SalesDeliveryDetail';
        export const readPermission = 'Sales:SalesDeliveryDetail';
        export const updatePermission = 'Sales:SalesDeliveryDetail';

        export declare const enum Fields {
            Id = "Id",
            SalesDeliveryId = "SalesDeliveryId",
            ProductId = "ProductId",
            QtyDelivered = "QtyDelivered",
            SalesDeliveryNumber = "SalesDeliveryNumber",
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
