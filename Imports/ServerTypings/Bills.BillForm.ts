namespace Indotalent.Bills {
    export interface BillForm {
        Number: Serenity.StringEditor;
        BillDate: Serenity.DateEditor;
        Description: Serenity.TextAreaEditor;
        PurchaseOrderId: Serenity.LookupEditor;
        ProjectId: Serenity.LookupEditor;
        ExternalReferenceNumber: Serenity.StringEditor;
        ItemList: BillDetailEditor;
        DispatchedTo: Serenity.TextAreaEditor;
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
        VendorStateName: Serenity.StringEditor;
        VendorZipCode: Serenity.StringEditor;
        VendorPhone: Serenity.StringEditor;
        VendorEmail: Serenity.StringEditor;
        VendorGSTNumber: Serenity.StringEditor;
        VendorAccountNumber: Serenity.StringEditor;
        VendorIFSCCode: Serenity.StringEditor;
        BillPaymentList: BillPaymentEditor;
    }

    export class BillForm extends Serenity.PrefixedContext {
        static formKey = 'Bills.Bill';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!BillForm.init)  {
                BillForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;
                var w1 = s.DateEditor;
                var w2 = s.TextAreaEditor;
                var w3 = s.LookupEditor;
                var w4 = BillDetailEditor;
                var w5 = s.DecimalEditor;
                var w6 = s.EnumEditor;
                var w7 = BillPaymentEditor;

                Q.initFormType(BillForm, [
                    'Number', w0,
                    'BillDate', w1,
                    'Description', w2,
                    'PurchaseOrderId', w3,
                    'ProjectId', w3,
                    'ExternalReferenceNumber', w0,
                    'ItemList', w4,
                    'DispatchedTo', w2,
                    'CurrencyName', w0,
                    'Discount', w5,
                    'OtherCharge', w5,
                    'TaxType', w6,
                    'TaxAmount', w5,
                    'TDS', w3,
                    'TCS', w3,
                    'TcsTdsTaxAmount', w5,
                    'SubTotal', w5,
                    'BeforeTax', w5,
                    'Total', w5,
                    'FinalTotalPostTDS_TCS', w5,
                    'VendorName', w0,
                    'VendorStreet', w0,
                    'VendorCity', w0,
                    'VendorStateName', w0,
                    'VendorZipCode', w0,
                    'VendorPhone', w0,
                    'VendorEmail', w0,
                    'VendorGSTNumber', w0,
                    'VendorAccountNumber', w0,
                    'VendorIFSCCode', w0,
                    'BillPaymentList', w7
                ]);
            }
        }
    }
}
