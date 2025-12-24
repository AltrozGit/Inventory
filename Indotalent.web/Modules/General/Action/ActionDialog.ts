
namespace Indotalent.General {

    @Serenity.Decorators.registerClass()
    export class ActionDialog extends Serenity.EntityDialog<ActionRow, any> {
        protected getFormKey() { return ActionForm.formKey; }
        protected getIdProperty() { return ActionRow.idProperty; }
        protected getLocalTextPrefix() { return ActionRow.localTextPrefix; }
        protected getNameProperty() { return ActionRow.nameProperty; }
        protected getService() { return ActionService.baseUrl; }
        protected getDeletePermission() { return ActionRow.deletePermission; }
        protected getInsertPermission() { return ActionRow.insertPermission; }
        protected getUpdatePermission() { return ActionRow.updatePermission; }

        protected form = new ActionForm(this.idPrefix);

    }
}