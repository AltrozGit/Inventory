namespace Indotalent.Projects {
    export interface ProjectExpenseForm {
        ProjectId: Serenity.LookupEditor;
        Notes: Serenity.TextAreaEditor;
        ExpenseId: Serenity.LookupEditor;
        ExpenseDate: Serenity.DateEditor;
        Cost: Serenity.DecimalEditor;
    }

    export class ProjectExpenseForm extends Serenity.PrefixedContext {
        static formKey = 'Projects.ProjectExpense';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!ProjectExpenseForm.init)  {
                ProjectExpenseForm.init = true;

                var s = Serenity;
                var w0 = s.LookupEditor;
                var w1 = s.TextAreaEditor;
                var w2 = s.DateEditor;
                var w3 = s.DecimalEditor;

                Q.initFormType(ProjectExpenseForm, [
                    'ProjectId', w0,
                    'Notes', w1,
                    'ExpenseId', w0,
                    'ExpenseDate', w2,
                    'Cost', w3
                ]);
            }
        }
    }
}
