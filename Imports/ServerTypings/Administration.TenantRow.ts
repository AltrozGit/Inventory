namespace Indotalent.Administration {
    export interface TenantRow {
        TenantId?: number;
        TenantName?: string;
        Description?: string;
        Street?: string;
        City?: string;
        CountryId?: number;
        CountryName?: string;
        StateId?: number;
        StateName?: string;
        ZipCode?: string;
        Phone?: string;
        Email?: string;
        Currency?: string;
        MaximumUser?: number;
        ReminderInDays?: number;
        TotalReminderCount?: number;
        MaterialRequestNumberUseDate?: boolean;
        MaterialRequestNumberPrefix?: string;
        MaterialIssueNumberUseDate?: boolean;
        MaterialIssueNumberPrefix?: string;
        MaterialIssueNumberLength?: number;
        ProductNumberLength?: number;
        ProductNumberPrefix?: string;
        ProductNumberUseDate?: boolean;
        MaterialRequestNumberLength?: number;
        CustomerNumberPrefix?: string;
        CustomerNumberUseDate?: boolean;
        CustomerNumberLength?: number;
        SalesNumberPrefix?: string;
        SalesNumberUseDate?: boolean;
        SalesNumberLength?: number;
        InvoiceNumberPrefix?: string;
        InvoiceNumberUseDate?: boolean;
        InvoiceNumberLength?: number;
        InvoicePaymentNumberPrefix?: string;
        InvoicePaymentNumberUseDate?: boolean;
        InvoicePaymentNumberLength?: number;
        VendorNumberPrefix?: string;
        VendorNumberUseDate?: boolean;
        VendorNumberLength?: number;
        PurchaseNumberPrefix?: string;
        PurchaseNumberUseDate?: boolean;
        PurchaseNumberLength?: number;
        BillNumberPrefix?: string;
        BillNumberUseDate?: boolean;
        BillNumberLength?: number;
        BillPaymentNumberPrefix?: string;
        BillPaymentNumberUseDate?: boolean;
        BillPaymentNumberLength?: number;
        SalesDeliveryNumberPrefix?: string;
        SalesDeliveryNumberUseDate?: boolean;
        SalesDeliveryNumberLength?: number;
        SalesReturnNumberPrefix?: string;
        SalesReturnNumberUseDate?: boolean;
        SalesReturnNumberLength?: number;
        PurchaseReceiptNumberPrefix?: string;
        PurchaseReceiptNumberUseDate?: boolean;
        PurchaseReceiptNumberLength?: number;
        PurchaseReturnNumberPrefix?: string;
        PurchaseReturnNumberUseDate?: boolean;
        PurchaseReturnNumberLength?: number;
        MaterialReturnNumberPrefix?: string;
        MaterialReturnNumberUseDate?: boolean;
        MaterialReturnNumberLength?: number;
        PositiveAdjustmentNumberPrefix?: string;
        PositiveAdjustmentNumberUseDate?: boolean;
        PositiveAdjustmentNumberLength?: number;
        NegativeAdjustmentNumberPrefix?: string;
        NegativeAdjustmentNumberUseDate?: boolean;
        NegativeAdjustmentNumberLength?: number;
        TransferOrderNumberPrefix?: string;
        TransferOrderNumberUseDate?: boolean;
        TransferOrderNumberLength?: number;
        QuotationNumberPrefix?: string;
        QuotationNumberUseDate?: boolean;
        QuotationNumberLength?: number;
        BulkFileUploadNumberPrefix?: string;
        BulkFileUploadNumberUseDate?: boolean;
        BulkFileUploadNumberLength?: number;
        InsertUserId?: number;
        InsertDate?: string;
        UpdateUserId?: number;
        UpdateDate?: string;
    }

    export namespace TenantRow {
        export const idProperty = 'TenantId';
        export const nameProperty = 'TenantName';
        export const localTextPrefix = 'Administration.Tenant';
        export const lookupKey = 'Administration.Tenant';

        export function getLookup(): Q.Lookup<TenantRow> {
            return Q.getLookup<TenantRow>('Administration.Tenant');
        }
        export const deletePermission = 'Administration:Tenant';
        export const insertPermission = 'Administration:Tenant';
        export const readPermission = 'Administration:Tenant';
        export const updatePermission = 'Administration:Tenant';

        export declare const enum Fields {
            TenantId = "TenantId",
            TenantName = "TenantName",
            Description = "Description",
            Street = "Street",
            City = "City",
            CountryId = "CountryId",
            CountryName = "CountryName",
            StateId = "StateId",
            StateName = "StateName",
            ZipCode = "ZipCode",
            Phone = "Phone",
            Email = "Email",
            Currency = "Currency",
            MaximumUser = "MaximumUser",
            ReminderInDays = "ReminderInDays",
            TotalReminderCount = "TotalReminderCount",
            MaterialRequestNumberUseDate = "MaterialRequestNumberUseDate",
            MaterialRequestNumberPrefix = "MaterialRequestNumberPrefix",
            MaterialIssueNumberUseDate = "MaterialIssueNumberUseDate",
            MaterialIssueNumberPrefix = "MaterialIssueNumberPrefix",
            MaterialIssueNumberLength = "MaterialIssueNumberLength",
            ProductNumberLength = "ProductNumberLength",
            ProductNumberPrefix = "ProductNumberPrefix",
            ProductNumberUseDate = "ProductNumberUseDate",
            MaterialRequestNumberLength = "MaterialRequestNumberLength",
            CustomerNumberPrefix = "CustomerNumberPrefix",
            CustomerNumberUseDate = "CustomerNumberUseDate",
            CustomerNumberLength = "CustomerNumberLength",
            SalesNumberPrefix = "SalesNumberPrefix",
            SalesNumberUseDate = "SalesNumberUseDate",
            SalesNumberLength = "SalesNumberLength",
            InvoiceNumberPrefix = "InvoiceNumberPrefix",
            InvoiceNumberUseDate = "InvoiceNumberUseDate",
            InvoiceNumberLength = "InvoiceNumberLength",
            InvoicePaymentNumberPrefix = "InvoicePaymentNumberPrefix",
            InvoicePaymentNumberUseDate = "InvoicePaymentNumberUseDate",
            InvoicePaymentNumberLength = "InvoicePaymentNumberLength",
            VendorNumberPrefix = "VendorNumberPrefix",
            VendorNumberUseDate = "VendorNumberUseDate",
            VendorNumberLength = "VendorNumberLength",
            PurchaseNumberPrefix = "PurchaseNumberPrefix",
            PurchaseNumberUseDate = "PurchaseNumberUseDate",
            PurchaseNumberLength = "PurchaseNumberLength",
            BillNumberPrefix = "BillNumberPrefix",
            BillNumberUseDate = "BillNumberUseDate",
            BillNumberLength = "BillNumberLength",
            BillPaymentNumberPrefix = "BillPaymentNumberPrefix",
            BillPaymentNumberUseDate = "BillPaymentNumberUseDate",
            BillPaymentNumberLength = "BillPaymentNumberLength",
            SalesDeliveryNumberPrefix = "SalesDeliveryNumberPrefix",
            SalesDeliveryNumberUseDate = "SalesDeliveryNumberUseDate",
            SalesDeliveryNumberLength = "SalesDeliveryNumberLength",
            SalesReturnNumberPrefix = "SalesReturnNumberPrefix",
            SalesReturnNumberUseDate = "SalesReturnNumberUseDate",
            SalesReturnNumberLength = "SalesReturnNumberLength",
            PurchaseReceiptNumberPrefix = "PurchaseReceiptNumberPrefix",
            PurchaseReceiptNumberUseDate = "PurchaseReceiptNumberUseDate",
            PurchaseReceiptNumberLength = "PurchaseReceiptNumberLength",
            PurchaseReturnNumberPrefix = "PurchaseReturnNumberPrefix",
            PurchaseReturnNumberUseDate = "PurchaseReturnNumberUseDate",
            PurchaseReturnNumberLength = "PurchaseReturnNumberLength",
            MaterialReturnNumberPrefix = "MaterialReturnNumberPrefix",
            MaterialReturnNumberUseDate = "MaterialReturnNumberUseDate",
            MaterialReturnNumberLength = "MaterialReturnNumberLength",
            PositiveAdjustmentNumberPrefix = "PositiveAdjustmentNumberPrefix",
            PositiveAdjustmentNumberUseDate = "PositiveAdjustmentNumberUseDate",
            PositiveAdjustmentNumberLength = "PositiveAdjustmentNumberLength",
            NegativeAdjustmentNumberPrefix = "NegativeAdjustmentNumberPrefix",
            NegativeAdjustmentNumberUseDate = "NegativeAdjustmentNumberUseDate",
            NegativeAdjustmentNumberLength = "NegativeAdjustmentNumberLength",
            TransferOrderNumberPrefix = "TransferOrderNumberPrefix",
            TransferOrderNumberUseDate = "TransferOrderNumberUseDate",
            TransferOrderNumberLength = "TransferOrderNumberLength",
            QuotationNumberPrefix = "QuotationNumberPrefix",
            QuotationNumberUseDate = "QuotationNumberUseDate",
            QuotationNumberLength = "QuotationNumberLength",
            BulkFileUploadNumberPrefix = "BulkFileUploadNumberPrefix",
            BulkFileUploadNumberUseDate = "BulkFileUploadNumberUseDate",
            BulkFileUploadNumberLength = "BulkFileUploadNumberLength",
            InsertUserId = "InsertUserId",
            InsertDate = "InsertDate",
            UpdateUserId = "UpdateUserId",
            UpdateDate = "UpdateDate"
        }
    }
}
