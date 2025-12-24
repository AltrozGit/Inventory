namespace Indotalent.Inventory {
    export interface PositiveAdjustmentDetailForm {
        ProductId: Serenity.LookupEditor;
        Qty: Serenity.DecimalEditor;
    }

    export class PositiveAdjustmentDetailForm extends Serenity.PrefixedContext {
        static formKey = 'Inventory.PositiveAdjustmentDetail';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!PositiveAdjustmentDetailForm.init)  {
                PositiveAdjustmentDetailForm.init = true;

                var s = Serenity;
                var w0 = s.LookupEditor;
                var w1 = s.DecimalEditor;

                Q.initFormType(PositiveAdjustmentDetailForm, [
                    'ProductId', w0,
                    'Qty', w1
                ]);
            }
        }
    }
}
