namespace Indotalent.Administration {
    export interface TenantForm {
        TenantName: Serenity.StringEditor;
        Description: Serenity.TextAreaEditor;
        Currency: Serenity.StringEditor;
        Street: Serenity.StringEditor;
        City: Serenity.StringEditor;
        CountryId: Serenity.LookupEditor;
        StateId: Serenity.LookupEditor;
        ZipCode: Serenity.StringEditor;
        Phone: Serenity.StringEditor;
        Email: Serenity.StringEditor;
        ReminderInDays: Serenity.IntegerEditor;
        TotalReminderCount: Serenity.IntegerEditor;
        QuotationNumberPrefix: Serenity.StringEditor;
        QuotationNumberUseDate: Serenity.BooleanEditor;
        QuotationNumberLength: Serenity.IntegerEditor;
        ProductNumberPrefix: Serenity.StringEditor;
        ProductNumberUseDate: Serenity.BooleanEditor;
        ProductNumberLength: Serenity.IntegerEditor;
        CustomerNumberPrefix: Serenity.StringEditor;
        CustomerNumberUseDate: Serenity.BooleanEditor;
        CustomerNumberLength: Serenity.IntegerEditor;
        SalesNumberPrefix: Serenity.StringEditor;
        SalesNumberUseDate: Serenity.BooleanEditor;
        SalesNumberLength: Serenity.IntegerEditor;
        InvoiceNumberPrefix: Serenity.StringEditor;
        InvoiceNumberUseDate: Serenity.BooleanEditor;
        InvoiceNumberLength: Serenity.IntegerEditor;
        InvoicePaymentNumberPrefix: Serenity.StringEditor;
        InvoicePaymentNumberUseDate: Serenity.BooleanEditor;
        InvoicePaymentNumberLength: Serenity.IntegerEditor;
        VendorNumberPrefix: Serenity.StringEditor;
        VendorNumberUseDate: Serenity.BooleanEditor;
        VendorNumberLength: Serenity.IntegerEditor;
        PurchaseNumberPrefix: Serenity.StringEditor;
        PurchaseNumberUseDate: Serenity.BooleanEditor;
        PurchaseNumberLength: Serenity.IntegerEditor;
        BillNumberPrefix: Serenity.StringEditor;
        BillNumberUseDate: Serenity.BooleanEditor;
        BillNumberLength: Serenity.IntegerEditor;
        BillPaymentNumberPrefix: Serenity.StringEditor;
        BillPaymentNumberUseDate: Serenity.BooleanEditor;
        BillPaymentNumberLength: Serenity.IntegerEditor;
        MaterialRequestNumberPrefix: Serenity.StringEditor;
        MaterialRequestNumberUseDate: Serenity.BooleanEditor;
        MaterialRequestNumberLength: Serenity.IntegerEditor;
        MaterialIssueNumberPrefix: Serenity.StringEditor;
        MaterialIssueNumberUseDate: Serenity.BooleanEditor;
        MaterialIssueNumberLength: Serenity.IntegerEditor;
        SalesDeliveryNumberPrefix: Serenity.StringEditor;
        SalesDeliveryNumberUseDate: Serenity.BooleanEditor;
        SalesDeliveryNumberLength: Serenity.IntegerEditor;
        SalesReturnNumberPrefix: Serenity.StringEditor;
        SalesReturnNumberUseDate: Serenity.BooleanEditor;
        SalesReturnNumberLength: Serenity.IntegerEditor;
        PurchaseReceiptNumberPrefix: Serenity.StringEditor;
        PurchaseReceiptNumberUseDate: Serenity.BooleanEditor;
        PurchaseReceiptNumberLength: Serenity.IntegerEditor;
        PurchaseReturnNumberPrefix: Serenity.StringEditor;
        PurchaseReturnNumberUseDate: Serenity.BooleanEditor;
        PurchaseReturnNumberLength: Serenity.IntegerEditor;
        MaterialReturnNumberPrefix: Serenity.StringEditor;
        MaterialReturnNumberUseDate: Serenity.BooleanEditor;
        MaterialReturnNumberLength: Serenity.IntegerEditor;
        PositiveAdjustmentNumberPrefix: Serenity.StringEditor;
        PositiveAdjustmentNumberUseDate: Serenity.BooleanEditor;
        PositiveAdjustmentNumberLength: Serenity.IntegerEditor;
        NegativeAdjustmentNumberPrefix: Serenity.StringEditor;
        NegativeAdjustmentNumberUseDate: Serenity.BooleanEditor;
        NegativeAdjustmentNumberLength: Serenity.IntegerEditor;
        TransferOrderNumberPrefix: Serenity.StringEditor;
        TransferOrderNumberUseDate: Serenity.BooleanEditor;
        TransferOrderNumberLength: Serenity.IntegerEditor;
        BulkFileUploadNumberPrefix: Serenity.StringEditor;
        BulkFileUploadNumberUseDate: Serenity.BooleanEditor;
        BulkFileUploadNumberLength: Serenity.IntegerEditor;
        MaximumUser: Serenity.IntegerEditor;
    }

    export class TenantForm extends Serenity.PrefixedContext {
        static formKey = 'Administration.Tenant';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!TenantForm.init)  {
                TenantForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;
                var w1 = s.TextAreaEditor;
                var w2 = s.LookupEditor;
                var w3 = s.IntegerEditor;
                var w4 = s.BooleanEditor;

                Q.initFormType(TenantForm, [
                    'TenantName', w0,
                    'Description', w1,
                    'Currency', w0,
                    'Street', w0,
                    'City', w0,
                    'CountryId', w2,
                    'StateId', w2,
                    'ZipCode', w0,
                    'Phone', w0,
                    'Email', w0,
                    'ReminderInDays', w3,
                    'TotalReminderCount', w3,
                    'QuotationNumberPrefix', w0,
                    'QuotationNumberUseDate', w4,
                    'QuotationNumberLength', w3,
                    'ProductNumberPrefix', w0,
                    'ProductNumberUseDate', w4,
                    'ProductNumberLength', w3,
                    'CustomerNumberPrefix', w0,
                    'CustomerNumberUseDate', w4,
                    'CustomerNumberLength', w3,
                    'SalesNumberPrefix', w0,
                    'SalesNumberUseDate', w4,
                    'SalesNumberLength', w3,
                    'InvoiceNumberPrefix', w0,
                    'InvoiceNumberUseDate', w4,
                    'InvoiceNumberLength', w3,
                    'InvoicePaymentNumberPrefix', w0,
                    'InvoicePaymentNumberUseDate', w4,
                    'InvoicePaymentNumberLength', w3,
                    'VendorNumberPrefix', w0,
                    'VendorNumberUseDate', w4,
                    'VendorNumberLength', w3,
                    'PurchaseNumberPrefix', w0,
                    'PurchaseNumberUseDate', w4,
                    'PurchaseNumberLength', w3,
                    'BillNumberPrefix', w0,
                    'BillNumberUseDate', w4,
                    'BillNumberLength', w3,
                    'BillPaymentNumberPrefix', w0,
                    'BillPaymentNumberUseDate', w4,
                    'BillPaymentNumberLength', w3,
                    'MaterialRequestNumberPrefix', w0,
                    'MaterialRequestNumberUseDate', w4,
                    'MaterialRequestNumberLength', w3,
                    'MaterialIssueNumberPrefix', w0,
                    'MaterialIssueNumberUseDate', w4,
                    'MaterialIssueNumberLength', w3,
                    'SalesDeliveryNumberPrefix', w0,
                    'SalesDeliveryNumberUseDate', w4,
                    'SalesDeliveryNumberLength', w3,
                    'SalesReturnNumberPrefix', w0,
                    'SalesReturnNumberUseDate', w4,
                    'SalesReturnNumberLength', w3,
                    'PurchaseReceiptNumberPrefix', w0,
                    'PurchaseReceiptNumberUseDate', w4,
                    'PurchaseReceiptNumberLength', w3,
                    'PurchaseReturnNumberPrefix', w0,
                    'PurchaseReturnNumberUseDate', w4,
                    'PurchaseReturnNumberLength', w3,
                    'MaterialReturnNumberPrefix', w0,
                    'MaterialReturnNumberUseDate', w4,
                    'MaterialReturnNumberLength', w3,
                    'PositiveAdjustmentNumberPrefix', w0,
                    'PositiveAdjustmentNumberUseDate', w4,
                    'PositiveAdjustmentNumberLength', w3,
                    'NegativeAdjustmentNumberPrefix', w0,
                    'NegativeAdjustmentNumberUseDate', w4,
                    'NegativeAdjustmentNumberLength', w3,
                    'TransferOrderNumberPrefix', w0,
                    'TransferOrderNumberUseDate', w4,
                    'TransferOrderNumberLength', w3,
                    'BulkFileUploadNumberPrefix', w0,
                    'BulkFileUploadNumberUseDate', w4,
                    'BulkFileUploadNumberLength', w3,
                    'MaximumUser', w3
                ]);
            }
        }
    }
}
