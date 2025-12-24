namespace Indotalent.Sales {
    export interface InvoicePaymentForm {
        Number: Serenity.StringEditor;
        Description: Serenity.TextAreaEditor;
        SupportingDocuments: Serenity.MultipleImageUploadEditor;
        InvoiceId: Serenity.LookupEditor;
        InvoiceAmount: Serenity.DecimalEditor;
        CurrencyName: Serenity.StringEditor;
        PaymentDate: Serenity.DateEditor;
        CashBankId: Serenity.LookupEditor;
        PaymentAmount: Serenity.DecimalEditor;
        PaymentMode: Serenity.StringEditor;
        TransactionNumber: Serenity.StringEditor;
        CustomerName: Serenity.StringEditor;
        CustomerStreet: Serenity.StringEditor;
        CustomerCity: Serenity.StringEditor;
        CustomerCountryName: Serenity.StringEditor;
        CustomerStateName: Serenity.StringEditor;
        CustomerZipCode: Serenity.StringEditor;
        CustomerPhone: Serenity.StringEditor;
        CustomerEmail: Serenity.StringEditor;
    }

    export class InvoicePaymentForm extends Serenity.PrefixedContext {
        static formKey = 'Sales.InvoicePayment';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!InvoicePaymentForm.init)  {
                InvoicePaymentForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;
                var w1 = s.TextAreaEditor;
                var w2 = s.MultipleImageUploadEditor;
                var w3 = s.LookupEditor;
                var w4 = s.DecimalEditor;
                var w5 = s.DateEditor;

                Q.initFormType(InvoicePaymentForm, [
                    'Number', w0,
                    'Description', w1,
                    'SupportingDocuments', w2,
                    'InvoiceId', w3,
                    'InvoiceAmount', w4,
                    'CurrencyName', w0,
                    'PaymentDate', w5,
                    'CashBankId', w3,
                    'PaymentAmount', w4,
                    'PaymentMode', w0,
                    'TransactionNumber', w0,
                    'CustomerName', w0,
                    'CustomerStreet', w0,
                    'CustomerCity', w0,
                    'CustomerCountryName', w0,
                    'CustomerStateName', w0,
                    'CustomerZipCode', w0,
                    'CustomerPhone', w0,
                    'CustomerEmail', w0
                ]);
            }
        }
    }
}
