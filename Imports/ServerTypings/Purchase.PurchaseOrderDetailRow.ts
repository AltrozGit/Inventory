namespace Indotalent.Purchase {
    export interface PurchaseOrderDetailRow {
        Id?: number;
        PurchaseOrderId?: number;
        ProductId?: number;
        Price?: number;
        Qty?: number;
        QuanityofPOCreated?: number;
        IsBillGenerated?: boolean;
        SubTotal?: number;
        Select?: boolean;
        InternalCode?: string;
        MaterialRequestId?: number;
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
        Description?: string;
        QtyRequest?: number;
        AvailableStock?: number;
        PurchaseTaxId?: number;
        QuanityOfPRCreated?: number;
        IsPRCreate?: boolean;
        QuanityOfBillCreated?: number;
        IsBillCreated?: boolean;
        IsSelected?: boolean;
        InsertUserId?: number;
        InsertDate?: string;
        UpdateUserId?: number;
        UpdateDate?: string;
    }

    export namespace PurchaseOrderDetailRow {
        export const idProperty = 'Id';
        export const nameProperty = 'ProductName';
        export const localTextPrefix = 'PurchaseOrder.PurchaseOrderDetail';
        export const lookupKey = 'PurchaseOrder.PurchaseOrderDetail';

        export function getLookup(): Q.Lookup<PurchaseOrderDetailRow> {
            return Q.getLookup<PurchaseOrderDetailRow>('PurchaseOrder.PurchaseOrderDetail');
        }
        export const deletePermission = 'Purchase:PurchaseOrder';
        export const insertPermission = 'Purchase:PurchaseOrder';
        export const readPermission = 'Purchase:PurchaseOrder';
        export const updatePermission = 'Purchase:PurchaseOrder';

        export declare const enum Fields {
            Id = "Id",
            PurchaseOrderId = "PurchaseOrderId",
            ProductId = "ProductId",
            Price = "Price",
            Qty = "Qty",
            QuanityofPOCreated = "QuanityofPOCreated",
            IsBillGenerated = "IsBillGenerated",
            SubTotal = "SubTotal",
            Select = "Select",
            InternalCode = "InternalCode",
            MaterialRequestId = "MaterialRequestId",
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
            Description = "Description",
            QtyRequest = "QtyRequest",
            AvailableStock = "AvailableStock",
            PurchaseTaxId = "PurchaseTaxId",
            QuanityOfPRCreated = "QuanityOfPRCreated",
            IsPRCreate = "IsPRCreate",
            QuanityOfBillCreated = "QuanityOfBillCreated",
            IsBillCreated = "IsBillCreated",
            IsSelected = "IsSelected",
            InsertUserId = "InsertUserId",
            InsertDate = "InsertDate",
            UpdateUserId = "UpdateUserId",
            UpdateDate = "UpdateDate"
        }
    }
}
