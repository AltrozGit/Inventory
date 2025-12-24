namespace Indotalent.Material {
    export interface IssueDetailForm {
        ProductId: Serenity.LookupEditor;
        InternalCode: Serenity.StringEditor;
        PurchasePrice: Serenity.DecimalEditor;
        AvailableStock: Serenity.DecimalEditor;
        QuanityOfIssueCreated: Serenity.IntegerEditor;
        PurchaseReceiptId: Serenity.IntegerEditor;
        QtyRequest: Serenity.DecimalEditor;
        UomId: Serenity.LookupEditor;
        PurchasedQty: Serenity.DecimalEditor;
        QtyIssue: Serenity.DecimalEditor;
        SubTotal: Serenity.DecimalEditor;
    }

    export class IssueDetailForm extends Serenity.PrefixedContext {
        static formKey = 'Material.IssueDetail';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!IssueDetailForm.init)  {
                IssueDetailForm.init = true;

                var s = Serenity;
                var w0 = s.LookupEditor;
                var w1 = s.StringEditor;
                var w2 = s.DecimalEditor;
                var w3 = s.IntegerEditor;

                Q.initFormType(IssueDetailForm, [
                    'ProductId', w0,
                    'InternalCode', w1,
                    'PurchasePrice', w2,
                    'AvailableStock', w2,
                    'QuanityOfIssueCreated', w3,
                    'PurchaseReceiptId', w3,
                    'QtyRequest', w2,
                    'UomId', w0,
                    'PurchasedQty', w2,
                    'QtyIssue', w2,
                    'SubTotal', w2
                ]);
            }
        }
    }
}
