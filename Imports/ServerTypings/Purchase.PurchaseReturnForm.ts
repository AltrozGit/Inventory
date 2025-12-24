namespace Indotalent.Purchase {
    export interface PurchaseReturnForm {
        Number: Serenity.StringEditor;
        ReturnDate: Serenity.DateEditor;
        Description: Serenity.TextAreaEditor;
        PurchaseReceiptId: Serenity.LookupEditor;
        ProjectId: Serenity.LookupEditor;
        WarehouseId: Serenity.LookupEditor;
        LocationId: Serenity.LookupEditor;
        ItemList: PurchaseReturnDetailEditor;
        TotalQtyReturn: Serenity.DecimalEditor;
    }

    export class PurchaseReturnForm extends Serenity.PrefixedContext {
        static formKey = 'Purchase.PurchaseReturn';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!PurchaseReturnForm.init)  {
                PurchaseReturnForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;
                var w1 = s.DateEditor;
                var w2 = s.TextAreaEditor;
                var w3 = s.LookupEditor;
                var w4 = PurchaseReturnDetailEditor;
                var w5 = s.DecimalEditor;

                Q.initFormType(PurchaseReturnForm, [
                    'Number', w0,
                    'ReturnDate', w1,
                    'Description', w2,
                    'PurchaseReceiptId', w3,
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
