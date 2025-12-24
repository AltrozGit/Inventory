namespace Indotalent.Projects {
    export interface ExpenseForm {
        Name: Serenity.StringEditor;
        Description: Serenity.TextAreaEditor;
    }

    export class ExpenseForm extends Serenity.PrefixedContext {
        static formKey = 'Projects.Expense';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!ExpenseForm.init)  {
                ExpenseForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;
                var w1 = s.TextAreaEditor;

                Q.initFormType(ExpenseForm, [
                    'Name', w0,
                    'Description', w1
                ]);
            }
        }
    }
}
