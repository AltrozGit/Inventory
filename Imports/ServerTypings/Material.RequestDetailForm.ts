namespace Indotalent.Material {
    export interface RequestDetailForm {
        ProductId: Serenity.LookupEditor;
        PurchasePrice: Serenity.DecimalEditor;
        UomId: Serenity.LookupEditor;
        InternalCode: Serenity.StringEditor;
        SacId: Serenity.LookupEditor;
        HsnId: Serenity.LookupEditor;
        QtyRequest: Serenity.DecimalEditor;
        SubTotal: Serenity.DecimalEditor;
        QuanityOfPOCreated: Serenity.IntegerEditor;
        IsPOComplete: Serenity.BooleanEditor;
    }

    export class RequestDetailForm extends Serenity.PrefixedContext {
        static formKey = 'Material.RequestDetail';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!RequestDetailForm.init)  {
                RequestDetailForm.init = true;

                var s = Serenity;
                var w0 = s.LookupEditor;
                var w1 = s.DecimalEditor;
                var w2 = s.StringEditor;
                var w3 = s.IntegerEditor;
                var w4 = s.BooleanEditor;

                Q.initFormType(RequestDetailForm, [
                    'ProductId', w0,
                    'PurchasePrice', w1,
                    'UomId', w0,
                    'InternalCode', w2,
                    'SacId', w0,
                    'HsnId', w0,
                    'QtyRequest', w1,
                    'SubTotal', w1,
                    'QuanityOfPOCreated', w3,
                    'IsPOComplete', w4
                ]);
            }
        }
    }
}
