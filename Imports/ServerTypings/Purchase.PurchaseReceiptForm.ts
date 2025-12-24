namespace Indotalent.Purchase {
    export interface PurchaseReceiptForm {
        Number: Serenity.StringEditor;
        ReceiptDate: Serenity.DateEditor;
        Description: Serenity.TextAreaEditor;
        PurchaseOrderId: Serenity.LookupEditor;
        VendorName: Serenity.StringEditor;
        InvoiceNumber: Serenity.StringEditor;
        InvoiceDate: Serenity.DateEditor;
        IsBillCreate: Serenity.BooleanEditor;
        ExternalReferenceNumber: Serenity.StringEditor;
        ProjectId: Serenity.LookupEditor;
        WarehouseId: Serenity.LookupEditor;
        LocationId: Serenity.LookupEditor;
        ItemList: PurchaseReceiptDetailEditor;
        TotalQtyReceive: Serenity.DecimalEditor;
    }

    export class PurchaseReceiptForm extends Serenity.PrefixedContext {
        static formKey = 'Purchase.PurchaseReceipt';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!PurchaseReceiptForm.init)  {
                PurchaseReceiptForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;
                var w1 = s.DateEditor;
                var w2 = s.TextAreaEditor;
                var w3 = s.LookupEditor;
                var w4 = s.BooleanEditor;
                var w5 = PurchaseReceiptDetailEditor;
                var w6 = s.DecimalEditor;

                Q.initFormType(PurchaseReceiptForm, [
                    'Number', w0,
                    'ReceiptDate', w1,
                    'Description', w2,
                    'PurchaseOrderId', w3,
                    'VendorName', w0,
                    'InvoiceNumber', w0,
                    'InvoiceDate', w1,
                    'IsBillCreate', w4,
                    'ExternalReferenceNumber', w0,
                    'ProjectId', w3,
                    'WarehouseId', w3,
                    'LocationId', w3,
                    'ItemList', w5,
                    'TotalQtyReceive', w6
                ]);
            }
        }
    }
}
