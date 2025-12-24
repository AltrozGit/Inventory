namespace Indotalent.Sales {
    export interface SalesReturnForm {
        Number: Serenity.StringEditor;
        ReturnDate: Serenity.DateEditor;
        Description: Serenity.TextAreaEditor;
        SalesDeliveryId: Serenity.LookupEditor;
        ProjectId: Serenity.LookupEditor;
        WarehouseId: Serenity.LookupEditor;
        LocationId: Serenity.LookupEditor;
        ItemList: SalesReturnDetailEditor;
        TotalQtyReturn: Serenity.DecimalEditor;
    }

    export class SalesReturnForm extends Serenity.PrefixedContext {
        static formKey = 'Sales.SalesReturn';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!SalesReturnForm.init)  {
                SalesReturnForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;
                var w1 = s.DateEditor;
                var w2 = s.TextAreaEditor;
                var w3 = s.LookupEditor;
                var w4 = SalesReturnDetailEditor;
                var w5 = s.DecimalEditor;

                Q.initFormType(SalesReturnForm, [
                    'Number', w0,
                    'ReturnDate', w1,
                    'Description', w2,
                    'SalesDeliveryId', w3,
                    'ProjectId', w3,
                    'WarehouseId', w3,
                    'LocationId', w3,
                    'ItemList', w4,
                    'TotalQtyReturn', w5
                ]);
            }
        }
    }
}
