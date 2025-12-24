namespace Indotalent.Projects {

    @Serenity.Decorators.registerClass()
    export class ProjectFundDialog extends Serenity.Extensions.GridEditorDialog<ProjectFundRow> {
        protected getFormKey() { return ProjectFundForm.formKey; }
        protected getLocalTextPrefix() { return ProjectFundRow.localTextPrefix; }

        protected form = new ProjectFundForm(this.idPrefix);
       
        constructor() {
            super();
        }
    }
}
