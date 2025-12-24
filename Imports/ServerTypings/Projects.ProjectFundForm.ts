namespace Indotalent.Projects {
    export interface ProjectFundForm {
        AddedFund: Serenity.DecimalEditor;
        FundingDate: Serenity.DateEditor;
        Description: Serenity.StringEditor;
    }

    export class ProjectFundForm extends Serenity.PrefixedContext {
        static formKey = 'Projects.ProjectFund';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!ProjectFundForm.init)  {
                ProjectFundForm.init = true;

                var s = Serenity;
                var w0 = s.DecimalEditor;
                var w1 = s.DateEditor;
                var w2 = s.StringEditor;

                Q.initFormType(ProjectFundForm, [
                    'AddedFund', w0,
                    'FundingDate', w1,
                    'Description', w2
                ]);
            }
        }
    }
}
