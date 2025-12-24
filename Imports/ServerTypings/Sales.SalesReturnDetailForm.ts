namespace Indotalent.Sales {
    export interface SalesReturnDetailForm {
        ProductId: Serenity.LookupEditor;
        QtyReturn: Serenity.DecimalEditor;
    }

    export class SalesReturnDetailForm extends Serenity.PrefixedContext {
        static formKey = 'Sales.SalesReturnDetail';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!SalesReturnDetailForm.init)  {
                SalesReturnDetailForm.init = true;

                var s = Serenity;
                var w0 = s.LookupEditor;
                var w1 = s.DecimalEditor;

                Q.initFormType(SalesReturnDetailForm, [
                    'ProductId', w0,
                    'QtyReturn', w1
                ]);
            }
        }
    }
}
