namespace Indotalent.Sales {
    export interface SalesDeliveryRow {
        Id?: number;
        Number?: string;
        Description?: string;
        SalesGroup?: string;
        DeliveryDate?: string;
        SalesOrderId?: number;
        ProjectId?: number;
        WarehouseId?: number;
        LocationId?: number;
        TotalQtyDelivered?: number;
        SalesOrderNumber?: string;
        ProjectName?: string;
        WarehouseName?: string;
        LocationName?: string;
        ItemList?: SalesDeliveryDetailRow[];
        CustomerId?: number;
        ShipperId?: number;
        ShipperName?: string;
        TenantId?: number;
        TenantName?: string;
    }

    export namespace SalesDeliveryRow {
        export const idProperty = 'Id';
        export const nameProperty = 'Number';
        export const localTextPrefix = 'Sales.SalesDelivery';
        export const lookupKey = 'Sales.SalesDelivery';

        export function getLookup(): Q.Lookup<SalesDeliveryRow> {
            return Q.getLookup<SalesDeliveryRow>('Sales.SalesDelivery');
        }
        export const deletePermission = 'Sales:SalesDelivery';
        export const insertPermission = 'Sales:SalesDelivery';
        export const readPermission = 'Sales:SalesDelivery';
        export const updatePermission = 'Sales:SalesDelivery';

        export declare const enum Fields {
            Id = "Id",
            Number = "Number",
            Description = "Description",
            SalesGroup = "SalesGroup",
            DeliveryDate = "DeliveryDate",
            SalesOrderId = "SalesOrderId",
            ProjectId = "ProjectId",
            WarehouseId = "WarehouseId",
            LocationId = "LocationId",
            TotalQtyDelivered = "TotalQtyDelivered",
            SalesOrderNumber = "SalesOrderNumber",
            ProjectName = "ProjectName",
            WarehouseName = "WarehouseName",
            LocationName = "LocationName",
            ItemList = "ItemList",
            CustomerId = "CustomerId",
            ShipperId = "ShipperId",
            ShipperName = "ShipperName",
            TenantId = "TenantId",
            TenantName = "TenantName"
        }
    }
}
