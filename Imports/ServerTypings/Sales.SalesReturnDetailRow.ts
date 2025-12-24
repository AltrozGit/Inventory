namespace Indotalent.Sales {
    export interface SalesReturnDetailRow {
        Id?: number;
        SalesReturnId?: number;
        ProductId?: number;
        QtyReturn?: number;
        SalesReturnNumber?: string;
        ProductName?: string;
        TenantId?: number;
        TenantName?: string;
        InsertUserId?: number;
        InsertDate?: string;
        UpdateUserId?: number;
        UpdateDate?: string;
    }

    export namespace SalesReturnDetailRow {
        export const idProperty = 'Id';
        export const nameProperty = 'ProductName';
        export const localTextPrefix = 'Sales.SalesReturnDetail';
        export const lookupKey = 'Sales.SalesReturnDetail';

        export function getLookup(): Q.Lookup<SalesReturnDetailRow> {
            return Q.getLookup<SalesReturnDetailRow>('Sales.SalesReturnDetail');
        }
        export const deletePermission = 'Sales:SalesReturnDetail';
        export const insertPermission = 'Sales:SalesReturnDetail';
        export const readPermission = 'Sales:SalesReturnDetail';
        export const updatePermission = 'Sales:SalesReturnDetail';

        export declare const enum Fields {
            Id = "Id",
            SalesReturnId = "SalesReturnId",
            ProductId = "ProductId",
            QtyReturn = "QtyReturn",
            SalesReturnNumber = "SalesReturnNumber",
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
