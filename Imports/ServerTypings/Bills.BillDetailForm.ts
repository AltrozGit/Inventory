namespace Indotalent.Bills {
    export interface BillDetailForm {
        ProductId: Serenity.LookupEditor;
        InternalCode: Serenity.StringEditor;
        Price: Serenity.DecimalEditor;
        Qty: Serenity.DecimalEditor;
        Discount: Serenity.DecimalEditor;
        PurchaseOrderId: Serenity.IntegerEditor;
        QuanityofBillCreated: Serenity.IntegerEditor;
        TaxPercentage: Serenity.DecimalEditor;
        IsBillPaymentGenerated: Serenity.BooleanEditor;
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

    export class BillDetailForm extends Serenity.PrefixedContext {
        static formKey = 'Bills.BillDetail';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!BillDetailForm.init)  {
                BillDetailForm.init = true;

                var s = Serenity;
                var w0 = s.LookupEditor;
                var w1 = s.StringEditor;
                var w2 = s.DecimalEditor;
                var w3 = s.IntegerEditor;
                var w4 = s.BooleanEditor;

                Q.initFormType(BillDetailForm, [
                    'ProductId', w0,
                    'InternalCode', w1,
                    'Price', w2,
                    'Qty', w2,
                    'Discount', w2,
                    'PurchaseOrderId', w3,
                    'QuanityofBillCreated', w3,
                    'TaxPercentage', w2,
                    'IsBillPaymentGenerated', w4,
                    'IGST', w2,
                    'IGSTAmount', w2,
                    'SGST', w2,
                    'SGSTAmount', w2,
                    'CGST', w2,
                    'CGSTAmount', w2,
                    'SubTotal', w2,
                    'BeforeTax', w2,
                    'TaxAmount', w2,
                    'Total', w2
                ]);
            }
        }
    }
}
