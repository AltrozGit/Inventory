namespace Indotalent.Projects {
    export interface QuotationDetailRow {
        Id?: number;
        QuotationId?: number;
        ProductId?: number;
        Price?: number;
        Qty?: number;
        SubTotal?: number;
        Discount?: number;
        BeforeTax?: number;
        TaxPercentage?: number;
        TaxAmount?: number;
        Total?: number;
        TenantId?: number;
        ProductName?: string;
        TenantName?: string;
        TenantState?: number;
        SGST?: number;
        CGST?: number;
        IGST?: number;
        SGSTAmount?: number;
        CGSTAmount?: number;
        IGSTAmount?: number;
        InternalCode?: string;
        InsertUserId?: number;
        InsertDate?: string;
        UpdateUserId?: number;
        UpdateDate?: string;
    }

    export namespace QuotationDetailRow {
        export const idProperty = 'Id';
        export const nameProperty = 'ProductName';
        export const localTextPrefix = 'Projects.QuotationDetail';
        export const deletePermission = 'Projects:QuotationDetail';
        export const insertPermission = 'Projects:QuotationDetail';
        export const readPermission = 'Projects:QuotationDetail';
        export const updatePermission = 'Projects:QuotationDetail';

        export declare const enum Fields {
            Id = "Id",
            QuotationId = "QuotationId",
            ProductId = "ProductId",
            Price = "Price",
            Qty = "Qty",
            SubTotal = "SubTotal",
            Discount = "Discount",
            BeforeTax = "BeforeTax",
            TaxPercentage = "TaxPercentage",
            TaxAmount = "TaxAmount",
            Total = "Total",
            TenantId = "TenantId",
            ProductName = "ProductName",
            TenantName = "TenantName",
            TenantState = "TenantState",
            SGST = "SGST",
            CGST = "CGST",
            IGST = "IGST",
            SGSTAmount = "SGSTAmount",
            CGSTAmount = "CGSTAmount",
            IGSTAmount = "IGSTAmount",
            InternalCode = "InternalCode",
            InsertUserId = "InsertUserId",
            InsertDate = "InsertDate",
            UpdateUserId = "UpdateUserId",
            UpdateDate = "UpdateDate"
        }
    }
}
