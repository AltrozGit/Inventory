namespace Indotalent.Purchase {
    export interface PurchaseReceiptDetailForm {
        ProductId: Serenity.LookupEditor;
        QtyRequest: Serenity.DecimalEditor;
        Qty: Serenity.DecimalEditor;
        InternalCode: Serenity.StringEditor;
        PurchaseOrderId: Serenity.IntegerEditor;
        QuanityofPRCreated: Serenity.IntegerEditor;
        QtyReceive: Serenity.DecimalEditor;
        PendingReceivableQty: Serenity.DecimalEditor;
        QuanityOfBillCreated: Serenity.IntegerEditor;
        IsBillCreate: Serenity.BooleanEditor;
        QuanityOfIssueCreated: Serenity.IntegerEditor;
        IsIssueCreated: Serenity.BooleanEditor;
    }

    export class PurchaseReceiptDetailForm extends Serenity.PrefixedContext {
        static formKey = 'Purchase.PurchaseReceiptDetail';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!PurchaseReceiptDetailForm.init)  {
                PurchaseReceiptDetailForm.init = true;

                var s = Serenity;
                var w0 = s.LookupEditor;
                var w1 = s.DecimalEditor;
                var w2 = s.StringEditor;
                var w3 = s.IntegerEditor;
                var w4 = s.BooleanEditor;

                Q.initFormType(PurchaseReceiptDetailForm, [
                    'ProductId', w0,
                    'QtyRequest', w1,
                    'Qty', w1,
                    'InternalCode', w2,
                    'PurchaseOrderId', w3,
                    'QuanityofPRCreated', w3,
                    'QtyReceive', w1,
                    'PendingReceivableQty', w1,
                    'QuanityOfBillCreated', w3,
                    'IsBillCreate', w4,
                    'QuanityOfIssueCreated', w3,
                    'IsIssueCreated', w4
                ]);
            }
        }
    }
}
