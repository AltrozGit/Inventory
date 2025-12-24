namespace Indotalent.Bills {
    export interface BillDetailRow {
        Id?: number;
        BillId?: number;
        ProductId?: number;
        Price?: number;
        Qty?: number;
        SubTotal?: number;
        InternalCode?: string;
        IsBillPaymentGenerated?: boolean;
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
        QuanityofBillCreated?: number;
        PurchaseReceiptId?: number;
        PurchaseOrderId?: number;
    }

    export namespace BillDetailRow {
        export const idProperty = 'Id';
        export const nameProperty = 'ProductName';
        export const localTextPrefix = 'Bills.BillDetail';
        export const lookupKey = 'Bills.BillDetail';

        export function getLookup(): Q.Lookup<BillDetailRow> {
            return Q.getLookup<BillDetailRow>('Bills.BillDetail');
        }
        export const deletePermission = 'Bills:BillDetail';
        export const insertPermission = 'Bills:BillDetail';
        export const readPermission = 'Bills:BillDetail';
        export const updatePermission = 'Bills:BillDetail';

        export declare const enum Fields {
            Id = "Id",
            BillId = "BillId",
            ProductId = "ProductId",
            Price = "Price",
            Qty = "Qty",
            SubTotal = "SubTotal",
            InternalCode = "InternalCode",
            IsBillPaymentGenerated = "IsBillPaymentGenerated",
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
            QuanityofBillCreated = "QuanityofBillCreated",
            PurchaseReceiptId = "PurchaseReceiptId",
            PurchaseOrderId = "PurchaseOrderId"
        }
    }
}
