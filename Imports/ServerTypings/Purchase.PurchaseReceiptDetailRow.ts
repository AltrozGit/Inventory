namespace Indotalent.Purchase {
    export interface PurchaseReceiptDetailRow {
        Id?: number;
        PurchaseReceiptId?: number;
        ProductId?: number;
        QtyReceive?: number;
        PendingReceivableQty?: number;
        PurchaseReceiptNumber?: string;
        ProductName?: string;
        TenantId?: number;
        TenantName?: string;
        Qty?: number;
        QtyRequest?: number;
        QuanityofPRCreated?: number;
        PurchaseOrderId?: number;
        QuanityOfBillCreated?: number;
        IsBillCreate?: boolean;
        QuanityOfIssueCreated?: number;
        IsIssueCreated?: boolean;
        InternalCode?: string;
    }

    export namespace PurchaseReceiptDetailRow {
        export const idProperty = 'Id';
        export const nameProperty = 'ProductName';
        export const localTextPrefix = 'Purchase.PurchaseReceiptDetail';
        export const lookupKey = 'Purchase.PurchaseReceiptDetail';

        export function getLookup(): Q.Lookup<PurchaseReceiptDetailRow> {
            return Q.getLookup<PurchaseReceiptDetailRow>('Purchase.PurchaseReceiptDetail');
        }
        export const deletePermission = 'Purchase:PurchaseReceiptDetail';
        export const insertPermission = 'Purchase:PurchaseReceiptDetail';
        export const readPermission = 'Purchase:PurchaseReceiptDetail';
        export const updatePermission = 'Purchase:PurchaseReceiptDetail';

        export declare const enum Fields {
            Id = "Id",
            PurchaseReceiptId = "PurchaseReceiptId",
            ProductId = "ProductId",
            QtyReceive = "QtyReceive",
            PendingReceivableQty = "PendingReceivableQty",
            PurchaseReceiptNumber = "PurchaseReceiptNumber",
            ProductName = "ProductName",
            TenantId = "TenantId",
            TenantName = "TenantName",
            Qty = "Qty",
            QtyRequest = "QtyRequest",
            QuanityofPRCreated = "QuanityofPRCreated",
            PurchaseOrderId = "PurchaseOrderId",
            QuanityOfBillCreated = "QuanityOfBillCreated",
            IsBillCreate = "IsBillCreate",
            QuanityOfIssueCreated = "QuanityOfIssueCreated",
            IsIssueCreated = "IsIssueCreated",
            InternalCode = "InternalCode"
        }
    }
}
