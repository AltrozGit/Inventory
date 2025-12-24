namespace Indotalent.Inventory {
    export interface NegativeAdjustmentDetailForm {
        ProductId: Serenity.LookupEditor;
        Qty: Serenity.DecimalEditor;
    }

    export class NegativeAdjustmentDetailForm extends Serenity.PrefixedContext {
        static formKey = 'Inventory.NegativeAdjustmentDetail';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!NegativeAdjustmentDetailForm.init)  {
                NegativeAdjustmentDetailForm.init = true;

                var s = Serenity;
                var w0 = s.LookupEditor;
                var w1 = s.DecimalEditor;

                Q.initFormType(NegativeAdjustmentDetailForm, [
                    'ProductId', w0,
                    'Qty', w1
                ]);
            }
        }
    }
}
