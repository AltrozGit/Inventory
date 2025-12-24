namespace Indotalent.Sales {
    export interface SalesOrderForm {
        Number: Serenity.StringEditor;
        OrderDate: Serenity.DateEditor;
        Description: Serenity.TextAreaEditor;
        CustomerId: Serenity.LookupEditor;
        SalesChannelId: Serenity.LookupEditor;
        ItemList: SalesOrderDetailEditor;
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
        BillingAddress: Serenity.StringEditor;
        ShippingAddress: Serenity.StringEditor;
        InvoiceList: InvoiceEditor;
    }

    export class SalesOrderForm extends Serenity.PrefixedContext {
        static formKey = 'Sales.SalesOrder';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!SalesOrderForm.init)  {
                SalesOrderForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;
                var w1 = s.DateEditor;
                var w2 = s.TextAreaEditor;
                var w3 = s.LookupEditor;
                var w4 = SalesOrderDetailEditor;
                var w5 = s.DecimalEditor;
                var w6 = s.EnumEditor;
                var w7 = InvoiceEditor;

                Q.initFormType(SalesOrderForm, [
                    'Number', w0,
                    'OrderDate', w1,
                    'Description', w2,
                    'CustomerId', w3,
                    'SalesChannelId', w3,
                    'ItemList', w4,
                    'DispatchedBy', w2,
                    'DispatchedTo', w2,
                    'PlaceOfSupply', w0,
                    'TenantState', w0,
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
                    'CustomerName', w0,
                    'CustomerStreet', w0,
                    'CustomerCity', w0,
                    'CustomerCountryName', w0,
                    'CustomerStateName', w0,
                    'CustomerZipCode', w0,
                    'CustomerPhone', w0,
                    'CustomerEmail', w0,
                    'BillingAddress', w0,
                    'ShippingAddress', w0,
                    'InvoiceList', w7
                ]);
            }
        }
    }
}
