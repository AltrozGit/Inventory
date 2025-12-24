namespace Indotalent.Material {
    export interface IssueForm {
        Number: Serenity.StringEditor;
        MaterialRequestId: Serenity.LookupEditor;
        IssueDate: Serenity.DateEditor;
        PurchaseReceiptId: Serenity.LookupEditor;
        Description: Serenity.TextAreaEditor;
        ProjectId: Serenity.LookupEditor;
        WarehouseId: Serenity.LookupEditor;
        ItemList: IssueDetailEditor;
        TotalQtyIssue: Serenity.DecimalEditor;
        Total: Serenity.DecimalEditor;
    }

    export class IssueForm extends Serenity.PrefixedContext {
        static formKey = 'Material.Issue';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!IssueForm.init)  {
                IssueForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;
                var w1 = s.LookupEditor;
                var w2 = s.DateEditor;
                var w3 = s.TextAreaEditor;
                var w4 = IssueDetailEditor;
                var w5 = s.DecimalEditor;

                Q.initFormType(IssueForm, [
                    'Number', w0,
                    'MaterialRequestId', w1,
                    'IssueDate', w2,
                    'PurchaseReceiptId', w1,
                    'Description', w3,
                    'ProjectId', w1,
                    'WarehouseId', w1,
                    'ItemList', w4,
                    'TotalQtyIssue', w5,
                    'Total', w5
                ]);
            }
        }
    }
}
