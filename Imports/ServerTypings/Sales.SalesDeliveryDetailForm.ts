namespace Indotalent.Sales {
    export interface SalesDeliveryDetailForm {
        ProductId: Serenity.LookupEditor;
        QtyDelivered: Serenity.DecimalEditor;
    }

    export class SalesDeliveryDetailForm extends Serenity.PrefixedContext {
        static formKey = 'Sales.SalesDeliveryDetail';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!SalesDeliveryDetailForm.init)  {
                SalesDeliveryDetailForm.init = true;

                var s = Serenity;
                var w0 = s.LookupEditor;
                var w1 = s.DecimalEditor;

                Q.initFormType(SalesDeliveryDetailForm, [
                    'ProductId', w0,
                    'QtyDelivered', w1
                ]);
            }
        }
    }
}
