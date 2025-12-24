namespace Indotalent.Purchase {
    export interface PurchaseReturnDetailForm {
        ProductId: Serenity.LookupEditor;
        QtyReturn: Serenity.DecimalEditor;
    }

    export class PurchaseReturnDetailForm extends Serenity.PrefixedContext {
        static formKey = 'Purchase.PurchaseReturnDetail';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!PurchaseReturnDetailForm.init)  {
                PurchaseReturnDetailForm.init = true;

                var s = Serenity;
                var w0 = s.LookupEditor;
                var w1 = s.DecimalEditor;

                Q.initFormType(PurchaseReturnDetailForm, [
                    'ProductId', w0,
                    'QtyReturn', w1
                ]);
            }
        }
    }
}
