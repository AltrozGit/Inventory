namespace Indotalent.Sales {
    export interface SalesReturnRow {
        Id?: number;
        Number?: string;
        Description?: string;
        SalesGroup?: string;
        ReturnDate?: string;
        SalesOrderId?: number;
        SalesDeliveryId?: number;
        ProjectId?: number;
        WarehouseId?: number;
        LocationId?: number;
        TotalQtyReturn?: number;
        SalesDeliveryNumber?: string;
        ProjectName?: string;
        WarehouseName?: string;
        LocationName?: string;
        ItemList?: SalesReturnDetailRow[];
        CustomerId?: number;
        TenantId?: number;
        TenantName?: string;
        InsertUserId?: number;
        InsertDate?: string;
        UpdateUserId?: number;
        UpdateDate?: string;
    }

    export namespace SalesReturnRow {
        export const idProperty = 'Id';
        export const nameProperty = 'Number';
        export const localTextPrefix = 'Sales.SalesReturn';
        export const lookupKey = 'Sales.SalesReturn';

        export function getLookup(): Q.Lookup<SalesReturnRow> {
            return Q.getLookup<SalesReturnRow>('Sales.SalesReturn');
        }
        export const deletePermission = 'Sales:SalesReturn';
        export const insertPermission = 'Sales:SalesReturn';
        export const readPermission = 'Sales:SalesReturn';
        export const updatePermission = 'Sales:SalesReturn';

        export declare const enum Fields {
            Id = "Id",
            Number = "Number",
            Description = "Description",
            SalesGroup = "SalesGroup",
            ReturnDate = "ReturnDate",
            SalesOrderId = "SalesOrderId",
            SalesDeliveryId = "SalesDeliveryId",
            ProjectId = "ProjectId",
            WarehouseId = "WarehouseId",
            LocationId = "LocationId",
            TotalQtyReturn = "TotalQtyReturn",
            SalesDeliveryNumber = "SalesDeliveryNumber",
            ProjectName = "ProjectName",
            WarehouseName = "WarehouseName",
            LocationName = "LocationName",
            ItemList = "ItemList",
            CustomerId = "CustomerId",
            TenantId = "TenantId",
            TenantName = "TenantName",
            InsertUserId = "InsertUserId",
            InsertDate = "InsertDate",
            UpdateUserId = "UpdateUserId",
            UpdateDate = "UpdateDate"
        }
    }
}
