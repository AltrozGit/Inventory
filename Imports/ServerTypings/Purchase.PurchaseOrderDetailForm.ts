namespace Indotalent.Purchase {
    export interface PurchaseOrderDetailForm {
        ProductId: Serenity.LookupEditor;
        AvailableStock: Serenity.DecimalEditor;
        InternalCode: Serenity.StringEditor;
        QtyRequest: Serenity.DecimalEditor;
        QuanityofPOCreated: Serenity.IntegerEditor;
        MaterialRequestId: Serenity.IntegerEditor;
        Price: Serenity.DecimalEditor;
        Qty: Serenity.DecimalEditor;
        Discount: Serenity.DecimalEditor;
        QuanityOfPRCreated: Serenity.IntegerEditor;
        IsPRCreate: Serenity.BooleanEditor;
        QuanityOfBillCreated: Serenity.IntegerEditor;
        IsBillCreated: Serenity.BooleanEditor;
        TaxPercentage: Serenity.DecimalEditor;
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

    export class PurchaseOrderDetailForm extends Serenity.PrefixedContext {
        static formKey = 'Purchase.PurchaseOrderDetail';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!PurchaseOrderDetailForm.init)  {
                PurchaseOrderDetailForm.init = true;

                var s = Serenity;
                var w0 = s.LookupEditor;
                var w1 = s.DecimalEditor;
                var w2 = s.StringEditor;
                var w3 = s.IntegerEditor;
                var w4 = s.BooleanEditor;

                Q.initFormType(PurchaseOrderDetailForm, [
                    'ProductId', w0,
                    'AvailableStock', w1,
                    'InternalCode', w2,
                    'QtyRequest', w1,
                    'QuanityofPOCreated', w3,
                    'MaterialRequestId', w3,
                    'Price', w1,
                    'Qty', w1,
                    'Discount', w1,
                    'QuanityOfPRCreated', w3,
                    'IsPRCreate', w4,
                    'QuanityOfBillCreated', w3,
                    'IsBillCreated', w4,
                    'TaxPercentage', w1,
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
