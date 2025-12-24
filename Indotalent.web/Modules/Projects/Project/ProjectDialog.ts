
namespace Indotalent.Projects{

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.panel()
    export class ProjectDialog extends Serenity.EntityDialog<ProjectRow, any> {
        protected getFormKey() { return ProjectForm.formKey; }
        protected getIdProperty() { return ProjectRow.idProperty; }
        protected getLocalTextPrefix() { return ProjectRow.localTextPrefix; }
        protected getNameProperty() { return ProjectRow.nameProperty; }
        protected getService() { return ProjectService.baseUrl; }
        protected getDeletePermission() { return ProjectRow.deletePermission; }
        protected getInsertPermission() { return ProjectRow.insertPermission; }
        protected getUpdatePermission() { return ProjectRow.updatePermission; }

        protected form = new ProjectForm(this.idPrefix);
        private loadedState: string;

        constructor() {
            super();



            Indotalent.DialogUtils.pendingChangesConfirmation(this.element, () => this.getSaveState() != this.loadedState);
        }


        getSaveState() {
            try {
                return $.toJSON(this.getSaveEntity());
            }
            catch (e) {
                return null;
            }
        }

        loadResponse(data) {
            super.loadResponse(data);
            this.loadedState = this.getSaveState();
        }

    }
}
