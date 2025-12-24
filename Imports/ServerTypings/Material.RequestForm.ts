namespace Indotalent.Material {
    export interface RequestForm {
        Number: Serenity.StringEditor;
        Description: Serenity.TextAreaEditor;
        RequestDate: Serenity.DateEditor;
        DeliveryDate: Serenity.DateEditor;
        ProjectId: Serenity.LookupEditor;
        ItemList: RequestDetailEditor;
        TotalQtyRequest: Serenity.DecimalEditor;
        Total: Serenity.DecimalEditor;
        IsPOComplete: Serenity.BooleanEditor;
        IsIssueCreated: Serenity.BooleanEditor;
        CommentList: NotesEditor;
        StatusList: MaterialRequestStatusEditor;
    }

    export class RequestForm extends Serenity.PrefixedContext {
        static formKey = 'Material.Request';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!RequestForm.init)  {
                RequestForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;
                var w1 = s.TextAreaEditor;
                var w2 = s.DateEditor;
                var w3 = s.LookupEditor;
                var w4 = RequestDetailEditor;
                var w5 = s.DecimalEditor;
                var w6 = s.BooleanEditor;
                var w7 = NotesEditor;
                var w8 = MaterialRequestStatusEditor;

                Q.initFormType(RequestForm, [
                    'Number', w0,
                    'Description', w1,
                    'RequestDate', w2,
                    'DeliveryDate', w2,
                    'ProjectId', w3,
                    'ItemList', w4,
                    'TotalQtyRequest', w5,
                    'Total', w5,
                    'IsPOComplete', w6,
                    'IsIssueCreated', w6,
                    'CommentList', w7,
                    'StatusList', w8
                ]);
            }
        }
    }
}
