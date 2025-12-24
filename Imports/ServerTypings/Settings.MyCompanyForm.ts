namespace Indotalent.Settings {
    export interface MyCompanyForm {
        TenantName: Serenity.StringEditor;
        Description: Serenity.TextAreaEditor;
        Currency: Serenity.StringEditor;
        Logo: Serenity.ImageUploadEditor;
        Street: Serenity.StringEditor;
        City: Serenity.StringEditor;
        CountryId: Serenity.LookupEditor;
        StateId: Serenity.LookupEditor;
        ZipCode: Serenity.StringEditor;
        Phone: Serenity.StringEditor;
        Email: Serenity.StringEditor;
        GSTNumber: Serenity.StringEditor;
        AccountNumber: Serenity.StringEditor;
        IFSCCode: Serenity.StringEditor;
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
        PositiveAdjustmentNumberPrefix: Serenity.StringEditor;
        PositiveAdjustmentNumberUseDate: Serenity.BooleanEditor;
        PositiveAdjustmentNumberLength: Serenity.IntegerEditor;
        NegativeAdjustmentNumberPrefix: Serenity.StringEditor;
        NegativeAdjustmentNumberUseDate: Serenity.BooleanEditor;
        NegativeAdjustmentNumberLength: Serenity.IntegerEditor;
        TransferOrderNumberPrefix: Serenity.StringEditor;
        TransferOrderNumberUseDate: Serenity.BooleanEditor;
        TransferOrderNumberLength: Serenity.IntegerEditor;
        MaximumUser: Serenity.IntegerEditor;
    }

    export class MyCompanyForm extends Serenity.PrefixedContext {
        static formKey = 'Settings.MyCompany';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!MyCompanyForm.init)  {
                MyCompanyForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;
                var w1 = s.TextAreaEditor;
                var w2 = s.ImageUploadEditor;
                var w3 = s.LookupEditor;
                var w4 = s.BooleanEditor;
                var w5 = s.IntegerEditor;

                Q.initFormType(MyCompanyForm, [
                    'TenantName', w0,
                    'Description', w1,
                    'Currency', w0,
                    'Logo', w2,
                    'Street', w0,
                    'City', w0,
                    'CountryId', w3,
                    'StateId', w3,
                    'ZipCode', w0,
                    'Phone', w0,
                    'Email', w0,
                    'GSTNumber', w0,
                    'AccountNumber', w0,
                    'IFSCCode', w0,
                    'ProductNumberPrefix', w0,
                    'ProductNumberUseDate', w4,
                    'ProductNumberLength', w5,
                    'CustomerNumberPrefix', w0,
                    'CustomerNumberUseDate', w4,
                    'CustomerNumberLength', w5,
                    'SalesNumberPrefix', w0,
                    'SalesNumberUseDate', w4,
                    'SalesNumberLength', w5,
                    'InvoiceNumberPrefix', w0,
                    'InvoiceNumberUseDate', w4,
                    'InvoiceNumberLength', w5,
                    'InvoicePaymentNumberPrefix', w0,
                    'InvoicePaymentNumberUseDate', w4,
                    'InvoicePaymentNumberLength', w5,
                    'VendorNumberPrefix', w0,
                    'VendorNumberUseDate', w4,
                    'VendorNumberLength', w5,
                    'PurchaseNumberPrefix', w0,
                    'PurchaseNumberUseDate', w4,
                    'PurchaseNumberLength', w5,
                    'BillNumberPrefix', w0,
                    'BillNumberUseDate', w4,
                    'BillNumberLength', w5,
                    'BillPaymentNumberPrefix', w0,
                    'BillPaymentNumberUseDate', w4,
                    'BillPaymentNumberLength', w5,
                    'MaterialRequestNumberPrefix', w0,
                    'MaterialRequestNumberUseDate', w4,
                    'MaterialRequestNumberLength', w5,
                    'MaterialIssueNumberPrefix', w0,
                    'MaterialIssueNumberUseDate', w4,
                    'MaterialIssueNumberLength', w5,
                    'SalesDeliveryNumberPrefix', w0,
                    'SalesDeliveryNumberUseDate', w4,
                    'SalesDeliveryNumberLength', w5,
                    'SalesReturnNumberPrefix', w0,
                    'SalesReturnNumberUseDate', w4,
                    'SalesReturnNumberLength', w5,
                    'PurchaseReceiptNumberPrefix', w0,
                    'PurchaseReceiptNumberUseDate', w4,
                    'PurchaseReceiptNumberLength', w5,
                    'PurchaseReturnNumberPrefix', w0,
                    'PurchaseReturnNumberUseDate', w4,
                    'PurchaseReturnNumberLength', w5,
                    'PositiveAdjustmentNumberPrefix', w0,
                    'PositiveAdjustmentNumberUseDate', w4,
                    'PositiveAdjustmentNumberLength', w5,
                    'NegativeAdjustmentNumberPrefix', w0,
                    'NegativeAdjustmentNumberUseDate', w4,
                    'NegativeAdjustmentNumberLength', w5,
                    'TransferOrderNumberPrefix', w0,
                    'TransferOrderNumberUseDate', w4,
                    'TransferOrderNumberLength', w5,
                    'MaximumUser', w5
                ]);
            }
        }
    }
}
