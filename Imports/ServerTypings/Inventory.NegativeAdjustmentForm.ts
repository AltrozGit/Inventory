namespace Indotalent.Inventory {
    export interface NegativeAdjustmentForm {
        Number: Serenity.StringEditor;
        Description: Serenity.TextAreaEditor;
        AdjustmentDate: Serenity.DateEditor;
        ProjectId: Serenity.LookupEditor;
        WarehouseId: Serenity.LookupEditor;
        LocationId: Serenity.LookupEditor;
        ItemList: NegativeAdjustmentDetailEditor;
        TotalQty: Serenity.DecimalEditor;
    }

    export class NegativeAdjustmentForm extends Serenity.PrefixedContext {
        static formKey = 'Inventory.NegativeAdjustment';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!NegativeAdjustmentForm.init)  {
                NegativeAdjustmentForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;
                var w1 = s.TextAreaEditor;
                var w2 = s.DateEditor;
                var w3 = s.LookupEditor;
                var w4 = NegativeAdjustmentDetailEditor;
                var w5 = s.DecimalEditor;

                Q.initFormType(NegativeAdjustmentForm, [
                    'Number', w0,
                    'Description', w1,
                    'AdjustmentDate', w2,
                    'ProjectId', w3,
                    'WarehouseId', w3,
                    'LocationId', w3,
                    'ItemList', w4,
                    'TotalQty', w5
                ]);
            }
        }
    }
}
