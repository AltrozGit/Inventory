namespace Indotalent.Projects {
    export interface QuotationForm {
        Number: Serenity.StringEditor;
        QuotationDate: Serenity.DateEditor;
        Description: Serenity.TextAreaEditor;
        ProjectId: Serenity.LookupEditor;
        CustomerId: Serenity.LookupEditor;
        TenantState: Serenity.StringEditor;
        ExternalReferenceNumber: Serenity.StringEditor;
        ItemList: QuotationDetailEditor;
        CurrencyName: Serenity.StringEditor;
        SubTotal: Serenity.DecimalEditor;
        Discount: Serenity.DecimalEditor;
        BeforeTax: Serenity.DecimalEditor;
        TaxAmount: Serenity.DecimalEditor;
        OtherCharge: Serenity.DecimalEditor;
        Total: Serenity.DecimalEditor;
        CustomerName: Serenity.StringEditor;
        CustomerStreet: Serenity.StringEditor;
        CustomerCity: Serenity.StringEditor;
        CustomerCountryName: Serenity.StringEditor;
        CustomerStateName: Serenity.StringEditor;
        CustomerZipCode: Serenity.StringEditor;
        CustomerPhone: Serenity.StringEditor;
        CustomerEmail: Serenity.StringEditor;
        BillingAddress: Serenity.StringEditor;
        ShippingAddress: Serenity.StringEditor;
    }

    export class QuotationForm extends Serenity.PrefixedContext {
        static formKey = 'Projects.Quotation';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!QuotationForm.init)  {
                QuotationForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;
                var w1 = s.DateEditor;
                var w2 = s.TextAreaEditor;
                var w3 = s.LookupEditor;
                var w4 = QuotationDetailEditor;
                var w5 = s.DecimalEditor;

                Q.initFormType(QuotationForm, [
                    'Number', w0,
                    'QuotationDate', w1,
                    'Description', w2,
                    'ProjectId', w3,
                    'CustomerId', w3,
                    'TenantState', w0,
                    'ExternalReferenceNumber', w0,
                    'ItemList', w4,
                    'CurrencyName', w0,
                    'SubTotal', w5,
                    'Discount', w5,
                    'BeforeTax', w5,
                    'TaxAmount', w5,
                    'OtherCharge', w5,
                    'Total', w5,
                    'CustomerName', w0,
                    'CustomerStreet', w0,
                    'CustomerCity', w0,
                    'CustomerCountryName', w0,
                    'CustomerStateName', w0,
                    'CustomerZipCode', w0,
                    'CustomerPhone', w0,
                    'CustomerEmail', w0,
                    'BillingAddress', w0,
                    'ShippingAddress', w0
                ]);
            }
        }
    }
}
