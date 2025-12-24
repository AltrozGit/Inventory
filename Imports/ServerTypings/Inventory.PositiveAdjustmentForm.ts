namespace Indotalent.Inventory {
    export interface PositiveAdjustmentForm {
        Number: Serenity.StringEditor;
        Description: Serenity.TextAreaEditor;
        AdjustmentDate: Serenity.DateEditor;
        ProjectId: Serenity.LookupEditor;
        WarehouseId: Serenity.LookupEditor;
        LocationId: Serenity.LookupEditor;
        ItemList: PositiveAdjustmentDetailEditor;
        TotalQty: Serenity.DecimalEditor;
    }

    export class PositiveAdjustmentForm extends Serenity.PrefixedContext {
        static formKey = 'Inventory.PositiveAdjustment';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!PositiveAdjustmentForm.init)  {
                PositiveAdjustmentForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;
                var w1 = s.TextAreaEditor;
                var w2 = s.DateEditor;
                var w3 = s.LookupEditor;
                var w4 = PositiveAdjustmentDetailEditor;
                var w5 = s.DecimalEditor;

                Q.initFormType(PositiveAdjustmentForm, [
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
