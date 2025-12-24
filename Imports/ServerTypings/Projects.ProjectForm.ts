namespace Indotalent.Projects {
    export interface ProjectForm {
        Name: Serenity.StringEditor;
        CustomerName: Serenity.StringEditor;
        Description: Serenity.TextAreaEditor;
        Street: Serenity.StringEditor;
        City: Serenity.StringEditor;
        State: Serenity.StringEditor;
        ZipCode: Serenity.StringEditor;
        Phone: Serenity.StringEditor;
        Email: Serenity.StringEditor;
        TotalAllocatedFund: Serenity.DecimalEditor;
        TotalAvailableFund: Serenity.DecimalEditor;
        TotalProjectExpense: Serenity.DecimalEditor;
        FundList: ProjectFundEditor;
    }

    export class ProjectForm extends Serenity.PrefixedContext {
        static formKey = 'Projects.Project';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!ProjectForm.init)  {
                ProjectForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;
                var w1 = s.TextAreaEditor;
                var w2 = s.DecimalEditor;
                var w3 = ProjectFundEditor;

                Q.initFormType(ProjectForm, [
                    'Name', w0,
                    'CustomerName', w0,
                    'Description', w1,
                    'Street', w0,
                    'City', w0,
                    'State', w0,
                    'ZipCode', w0,
                    'Phone', w0,
                    'Email', w0,
                    'TotalAllocatedFund', w2,
                    'TotalAvailableFund', w2,
                    'TotalProjectExpense', w2,
                    'FundList', w3
                ]);
            }
        }
    }
}
