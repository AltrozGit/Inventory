namespace Indotalent.Sales {
    export interface InvoiceDetailRow {
        Id?: number;
        InvoiceId?: number;
        ProductId?: number;
        Price?: number;
        Qty?: number;
        IsInvoiceGenerated?: boolean;
        IsInvoicePaymentGenerated?: boolean;
        SubTotal?: number;
        Discount?: number;
        InternalCode?: string;
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
        InsertUserId?: number;
        InsertDate?: string;
        UpdateUserId?: number;
        UpdateDate?: string;
    }

    export namespace InvoiceDetailRow {
        export const idProperty = 'Id';
        export const nameProperty = 'ProductName';
        export const localTextPrefix = 'Sales.InvoiceDetail';
        export const lookupKey = 'Sales.InvoiceDetail';

        export function getLookup(): Q.Lookup<InvoiceDetailRow> {
            return Q.getLookup<InvoiceDetailRow>('Sales.InvoiceDetail');
        }
        export const deletePermission = 'Sales:Invoice';
        export const insertPermission = 'Sales:Invoice';
        export const readPermission = 'Sales:Invoice';
        export const updatePermission = 'Sales:Invoice';

        export declare const enum Fields {
            Id = "Id",
            InvoiceId = "InvoiceId",
            ProductId = "ProductId",
            Price = "Price",
            Qty = "Qty",
            IsInvoiceGenerated = "IsInvoiceGenerated",
            IsInvoicePaymentGenerated = "IsInvoicePaymentGenerated",
            SubTotal = "SubTotal",
            Discount = "Discount",
            InternalCode = "InternalCode",
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
            InsertUserId = "InsertUserId",
            InsertDate = "InsertDate",
            UpdateUserId = "UpdateUserId",
            UpdateDate = "UpdateDate"
        }
    }
}
