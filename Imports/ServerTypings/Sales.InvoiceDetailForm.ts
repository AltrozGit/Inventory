namespace Indotalent.Sales {
    export interface InvoiceDetailForm {
        ProductId: Serenity.LookupEditor;
        Price: Serenity.DecimalEditor;
        Qty: Serenity.DecimalEditor;
        Discount: Serenity.DecimalEditor;
        InternalCode: Serenity.StringEditor;
        TaxPercentage: Serenity.DecimalEditor;
        IsInvoicePaymentGenerated: Serenity.BooleanEditor;
        IsInvoiceGenerated: Serenity.BooleanEditor;
        IGST: Serenity.DecimalEditor;
        IGSTAmount: Serenity.DecimalEditor;
        SGST: Serenity.DecimalEditor;
        SGSTAmount: Serenity.DecimalEditor;
        CGST: Serenity.DecimalEditor;
        CGSTAmount: Serenity.DecimalEditor;
        SubTotal: Serenity.DecimalEditor;
        BeforeTax: Serenity.DecimalEditor;
        TaxAmount: Serenity.DecimalEditor;
        Total: Serenity.DecimalEditor;
    }

    export class InvoiceDetailForm extends Serenity.PrefixedContext {
        static formKey = 'Sales.InvoiceDetail';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!InvoiceDetailForm.init)  {
                InvoiceDetailForm.init = true;

                var s = Serenity;
                var w0 = s.LookupEditor;
                var w1 = s.DecimalEditor;
                var w2 = s.StringEditor;
                var w3 = s.BooleanEditor;

                Q.initFormType(InvoiceDetailForm, [
                    'ProductId', w0,
                    'Price', w1,
                    'Qty', w1,
                    'Discount', w1,
                    'InternalCode', w2,
                    'TaxPercentage', w1,
                    'IsInvoicePaymentGenerated', w3,
                    'IsInvoiceGenerated', w3,
                    'IGST', w1,
                    'IGSTAmount', w1,
                    'SGST', w1,
                    'SGSTAmount', w1,
                    'CGST', w1,
                    'CGSTAmount', w1,
                    'SubTotal', w1,
                    'BeforeTax', w1,
                    'TaxAmount', w1,
                    'Total', w1
                ]);
            }
        }
    }
}
