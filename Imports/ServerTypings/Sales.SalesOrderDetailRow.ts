namespace Indotalent.Sales {
    export interface SalesOrderDetailRow {
        Id?: number;
        SalesOrderId?: number;
        ProductId?: number;
        Price?: number;
        Qty?: number;
        IsInvoiceGenerated?: boolean;
        InternalCode?: string;
        SubTotal?: number;
        Discount?: number;
        BeforeTax?: number;
        TaxPercentage?: number;
        SGST?: number;
        CGST?: number;
        IGST?: number;
        SGSTAmount?: number;
        CGSTAmount?: number;
        IGSTAmount?: number;
        TaxAmount?: number;
        Total?: number;
        ProductName?: string;
        TenantId?: number;
        TenantName?: string;
        TenantState?: number;
        InsertUserId?: number;
        InsertDate?: string;
        UpdateUserId?: number;
        UpdateDate?: string;
    }

    export namespace SalesOrderDetailRow {
        export const idProperty = 'Id';
        export const nameProperty = 'ProductName';
        export const localTextPrefix = 'Sales.SalesOrderDetail';
        export const lookupKey = 'Sales.SalesOrderDetail';

        export function getLookup(): Q.Lookup<SalesOrderDetailRow> {
            return Q.getLookup<SalesOrderDetailRow>('Sales.SalesOrderDetail');
        }
        export const deletePermission = 'Sales:SalesOrder';
        export const insertPermission = 'Sales:SalesOrder';
        export const readPermission = 'Sales:SalesOrder';
        export const updatePermission = 'Sales:SalesOrder';

        export declare const enum Fields {
            Id = "Id",
            SalesOrderId = "SalesOrderId",
            ProductId = "ProductId",
            Price = "Price",
            Qty = "Qty",
            IsInvoiceGenerated = "IsInvoiceGenerated",
            InternalCode = "InternalCode",
            SubTotal = "SubTotal",
            Discount = "Discount",
            BeforeTax = "BeforeTax",
            TaxPercentage = "TaxPercentage",
            SGST = "SGST",
            CGST = "CGST",
            IGST = "IGST",
            SGSTAmount = "SGSTAmount",
            CGSTAmount = "CGSTAmount",
            IGSTAmount = "IGSTAmount",
            TaxAmount = "TaxAmount",
            Total = "Total",
            ProductName = "ProductName",
            TenantId = "TenantId",
            TenantName = "TenantName",
            TenantState = "TenantState",
            InsertUserId = "InsertUserId",
            InsertDate = "InsertDate",
            UpdateUserId = "UpdateUserId",
            UpdateDate = "UpdateDate"
        }
    }
}
