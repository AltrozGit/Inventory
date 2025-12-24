namespace Indotalent.Inventory {
    export interface TransferOrderForm {
        Number: Serenity.StringEditor;
        Description: Serenity.TextAreaEditor;
        TransferDate: Serenity.DateEditor;
        ProjectFromId: Serenity.LookupEditor;
        ProjectToId: Serenity.LookupEditor;
        FromId: Serenity.LookupEditor;
        ToId: Serenity.LookupEditor;
        ItemList: TransferOrderDetailEditor;
        TotalQty: Serenity.DecimalEditor;
    }

    export class TransferOrderForm extends Serenity.PrefixedContext {
        static formKey = 'Inventory.TransferOrder';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!TransferOrderForm.init)  {
                TransferOrderForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;
                var w1 = s.TextAreaEditor;
                var w2 = s.DateEditor;
                var w3 = s.LookupEditor;
                var w4 = TransferOrderDetailEditor;
                var w5 = s.DecimalEditor;

                Q.initFormType(TransferOrderForm, [
                    'Number', w0,
                    'Description', w1,
                    'TransferDate', w2,
                    'ProjectFromId', w3,
                    'ProjectToId', w3,
                    'FromId', w3,
                    'ToId', w3,
                    'ItemList', w4,
                    'TotalQty', w5
                ]);
            }
        }
    }
}
