namespace Indotalent.Settings {
    export interface MyCompanyRow {
        TenantId?: number;
        TenantName?: string;
        Description?: string;
        Currency?: string;
        Street?: string;
        City?: string;
        CountryId?: number;
        CountryName?: string;
        StateId?: number;
        StateName?: string;
        ZipCode?: string;
        Phone?: string;
        Email?: string;
        GSTNumber?: string;
        AccountNumber?: string;
        IFSCCode?: string;
        MaximumUser?: number;
        ProductNumberPrefix?: string;
        ProductNumberUseDate?: boolean;
        ProductNumberLength?: number;
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
        PositiveAdjustmentNumberPrefix?: string;
        PositiveAdjustmentNumberUseDate?: boolean;
        PositiveAdjustmentNumberLength?: number;
        NegativeAdjustmentNumberPrefix?: string;
        NegativeAdjustmentNumberUseDate?: boolean;
        NegativeAdjustmentNumberLength?: number;
        TransferOrderNumberPrefix?: string;
        TransferOrderNumberUseDate?: boolean;
        TransferOrderNumberLength?: number;
        MaterialRequestNumberUseDate?: boolean;
        MaterialRequestNumberPrefix?: string;
        MaterialIssueNumberUseDate?: boolean;
        MaterialIssueNumberPrefix?: string;
        MaterialIssueNumberLength?: number;
        MaterialRequestNumberLength?: number;
        Logo?: string;
        InsertUserId?: number;
        InsertDate?: string;
        UpdateUserId?: number;
        UpdateDate?: string;
    }

    export namespace MyCompanyRow {
        export const idProperty = 'TenantId';
        export const nameProperty = 'TenantName';
        export const localTextPrefix = 'Settings.MyCompany';
        export const lookupKey = 'Settings.MyCompany';

        export function getLookup(): Q.Lookup<MyCompanyRow> {
            return Q.getLookup<MyCompanyRow>('Settings.MyCompany');
        }
        export const deletePermission = 'Settings:MyCompany';
        export const insertPermission = 'Settings:MyCompany';
        export const readPermission = 'Settings:MyCompany';
        export const updatePermission = 'Settings:MyCompany';

        export declare const enum Fields {
            TenantId = "TenantId",
            TenantName = "TenantName",
            Description = "Description",
            Currency = "Currency",
            Street = "Street",
            City = "City",
            CountryId = "CountryId",
            CountryName = "CountryName",
            StateId = "StateId",
            StateName = "StateName",
            ZipCode = "ZipCode",
            Phone = "Phone",
            Email = "Email",
            GSTNumber = "GSTNumber",
            AccountNumber = "AccountNumber",
            IFSCCode = "IFSCCode",
            MaximumUser = "MaximumUser",
            ProductNumberPrefix = "ProductNumberPrefix",
            ProductNumberUseDate = "ProductNumberUseDate",
            ProductNumberLength = "ProductNumberLength",
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
            PositiveAdjustmentNumberPrefix = "PositiveAdjustmentNumberPrefix",
            PositiveAdjustmentNumberUseDate = "PositiveAdjustmentNumberUseDate",
            PositiveAdjustmentNumberLength = "PositiveAdjustmentNumberLength",
            NegativeAdjustmentNumberPrefix = "NegativeAdjustmentNumberPrefix",
            NegativeAdjustmentNumberUseDate = "NegativeAdjustmentNumberUseDate",
            NegativeAdjustmentNumberLength = "NegativeAdjustmentNumberLength",
            TransferOrderNumberPrefix = "TransferOrderNumberPrefix",
            TransferOrderNumberUseDate = "TransferOrderNumberUseDate",
            TransferOrderNumberLength = "TransferOrderNumberLength",
            MaterialRequestNumberUseDate = "MaterialRequestNumberUseDate",
            MaterialRequestNumberPrefix = "MaterialRequestNumberPrefix",
            MaterialIssueNumberUseDate = "MaterialIssueNumberUseDate",
            MaterialIssueNumberPrefix = "MaterialIssueNumberPrefix",
            MaterialIssueNumberLength = "MaterialIssueNumberLength",
            MaterialRequestNumberLength = "MaterialRequestNumberLength",
            Logo = "Logo",
            InsertUserId = "InsertUserId",
            InsertDate = "InsertDate",
            UpdateUserId = "UpdateUserId",
            UpdateDate = "UpdateDate"
        }
    }
}
