namespace Indotalent.Inventory {
    export interface TransferOrderDetailForm {
        ProductId: Serenity.LookupEditor;
        Qty: Serenity.DecimalEditor;
    }

    export class TransferOrderDetailForm extends Serenity.PrefixedContext {
        static formKey = 'Inventory.TransferOrderDetail';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!TransferOrderDetailForm.init)  {
                TransferOrderDetailForm.init = true;

                var s = Serenity;
                var w0 = s.LookupEditor;
                var w1 = s.DecimalEditor;

                Q.initFormType(TransferOrderDetailForm, [
                    'ProductId', w0,
                    'Qty', w1
                ]);
            }
        }
    }
}
