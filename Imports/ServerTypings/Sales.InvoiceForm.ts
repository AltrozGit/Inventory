namespace Indotalent.Sales {
    export interface InvoiceForm {
        Number: Serenity.StringEditor;
        InvoiceDate: Serenity.DateEditor;
        SalesOrderId: Serenity.LookupEditor;
        CustomerPONumber: Serenity.StringEditor;
        PONumberDate: Serenity.DateEditor;
        PyamentTerm: Serenity.StringEditor;
        Description: Serenity.TextAreaEditor;
        ItemList: InvoiceDetailEditor;
        DispatchedBy: Serenity.TextAreaEditor;
        DispatchedTo: Serenity.TextAreaEditor;
        PlaceOfSupply: Serenity.StringEditor;
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
        CustomerName: Serenity.StringEditor;
        CustomerStreet: Serenity.StringEditor;
        CustomerCity: Serenity.StringEditor;
        CustomerCountryName: Serenity.StringEditor;
        CustomerStateName: Serenity.StringEditor;
        CustomerZipCode: Serenity.StringEditor;
        CustomerPhone: Serenity.StringEditor;
        CustomerEmail: Serenity.StringEditor;
        InvoicePaymentList: InvoicePaymentEditor;
    }

    export class InvoiceForm extends Serenity.PrefixedContext {
        static formKey = 'Sales.Invoice';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!InvoiceForm.init)  {
                InvoiceForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;
                var w1 = s.DateEditor;
                var w2 = s.LookupEditor;
                var w3 = s.TextAreaEditor;
                var w4 = InvoiceDetailEditor;
                var w5 = s.DecimalEditor;
                var w6 = s.EnumEditor;
                var w7 = InvoicePaymentEditor;

                Q.initFormType(InvoiceForm, [
                    'Number', w0,
                    'InvoiceDate', w1,
                    'SalesOrderId', w2,
                    'CustomerPONumber', w0,
                    'PONumberDate', w1,
                    'PyamentTerm', w0,
                    'Description', w3,
                    'ItemList', w4,
                    'DispatchedBy', w3,
                    'DispatchedTo', w3,
                    'PlaceOfSupply', w0,
                    'TenantState', w0,
                    'CurrencyName', w0,
                    'Discount', w5,
                    'OtherCharge', w5,
                    'TaxType', w6,
                    'TaxAmount', w5,
                    'TDS', w2,
                    'TCS', w2,
                    'TcsTdsTaxAmount', w5,
                    'SubTotal', w5,
                    'BeforeTax', w5,
                    'Total', w5,
                    'FinalTotalPostTDS_TCS', w5,
                    'CustomerName', w0,
                    'CustomerStreet', w0,
                    'CustomerCity', w0,
                    'CustomerCountryName', w0,
                    'CustomerStateName', w0,
                    'CustomerZipCode', w0,
                    'CustomerPhone', w0,
                    'CustomerEmail', w0,
                    'InvoicePaymentList', w7
                ]);
            }
        }
    }
}
