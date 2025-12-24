namespace Indotalent.Purchase {
    export interface PurchaseOrderForm {
        Number: Serenity.StringEditor;
        OrderDate: Serenity.DateEditor;
        VendorId: Serenity.LookupEditor;
        QuotationReferenceNumber: Serenity.StringEditor;
        Description: Serenity.TextAreaEditor;
        MaterialRequestId: Serenity.LookupEditor;
        UploadQuotation: Serenity.MultipleImageUploadEditor;
        IsPRCreate: Serenity.BooleanEditor;
        IsBillCreated: Serenity.BooleanEditor;
        Status: Serenity.EnumEditor;
        ItemList: PurchaseOrderDetailEditor;
        DispatchedTo: Serenity.TextAreaEditor;
        TenantState: Serenity.StringEditor;
        CurrencyName: Serenity.StringEditor;
        Discount: Serenity.DecimalEditor;
        OtherCharge: Serenity.DecimalEditor;
        TaxType: Serenity.EnumEditor;
        TaxAmount: Serenity.DecimalEditor;
        TDS: Serenity.LookupEditor;
        TCS: Serenity.LookupEditor;
        TcsTdsTaxAmount: Serenity.DecimalEditor;
        SubTotal: Serenity.DecimalEditor;
        BeforeTax: Serenity.DecimalEditor;
        Total: Serenity.DecimalEditor;
        FinalTotalPostTDS_TCS: Serenity.DecimalEditor;
        VendorName: Serenity.StringEditor;
        VendorStreet: Serenity.StringEditor;
        VendorCity: Serenity.StringEditor;
        VendorCountryName: Serenity.StringEditor;
        VendorStateName: Serenity.StringEditor;
        VendorZipCode: Serenity.StringEditor;
        VendorPhone: Serenity.StringEditor;
        VendorEmail: Serenity.StringEditor;
        VendorGSTNumber: Serenity.StringEditor;
        VendorAccountNumber: Serenity.StringEditor;
        VendorIFSCCode: Serenity.StringEditor;
        BillList: Bills.BillEditor;
    }

    export class PurchaseOrderForm extends Serenity.PrefixedContext {
        static formKey = 'Purchase.PurchaseOrder';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!PurchaseOrderForm.init)  {
                PurchaseOrderForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;
                var w1 = s.DateEditor;
                var w2 = s.LookupEditor;
                var w3 = s.TextAreaEditor;
                var w4 = s.MultipleImageUploadEditor;
                var w5 = s.BooleanEditor;
                var w6 = s.EnumEditor;
                var w7 = PurchaseOrderDetailEditor;
                var w8 = s.DecimalEditor;
                var w9 = Bills.BillEditor;

                Q.initFormType(PurchaseOrderForm, [
                    'Number', w0,
                    'OrderDate', w1,
                    'VendorId', w2,
                    'QuotationReferenceNumber', w0,
                    'Description', w3,
                    'MaterialRequestId', w2,
                    'UploadQuotation', w4,
                    'IsPRCreate', w5,
                    'IsBillCreated', w5,
                    'Status', w6,
                    'ItemList', w7,
                    'DispatchedTo', w3,
                    'TenantState', w0,
                    'CurrencyName', w0,
                    'Discount', w8,
                    'OtherCharge', w8,
                    'TaxType', w6,
                    'TaxAmount', w8,
                    'TDS', w2,
                    'TCS', w2,
                    'TcsTdsTaxAmount', w8,
                    'SubTotal', w8,
                    'BeforeTax', w8,
                    'Total', w8,
                    'FinalTotalPostTDS_TCS', w8,
                    'VendorName', w0,
                    'VendorStreet', w0,
                    'VendorCity', w0,
                    'VendorCountryName', w0,
                    'VendorStateName', w0,
                    'VendorZipCode', w0,
                    'VendorPhone', w0,
                    'VendorEmail', w0,
                    'VendorGSTNumber', w0,
                    'VendorAccountNumber', w0,
                    'VendorIFSCCode', w0,
                    'BillList', w9
                ]);
            }
        }
    }
}
