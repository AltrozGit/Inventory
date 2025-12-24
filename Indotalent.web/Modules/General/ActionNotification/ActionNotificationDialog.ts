
namespace Indotalent.General {

    @Serenity.Decorators.registerClass()
    export class ActionNotificationDialog extends Serenity.EntityDialog<ActionNotificationRow, any> {
        protected getFormKey() { return ActionNotificationForm.formKey; }
        protected getIdProperty() { return ActionNotificationRow.idProperty; }
        protected getLocalTextPrefix() { return ActionNotificationRow.localTextPrefix; }
        protected getNameProperty() { return ActionNotificationRow.nameProperty; }
        protected getService() { return ActionNotificationService.baseUrl; }
        protected getDeletePermission() { return ActionNotificationRow.deletePermission; }
        protected getInsertPermission() { return ActionNotificationRow.insertPermission; }
        protected getUpdatePermission() { return ActionNotificationRow.updatePermission; }

        protected form = new ActionNotificationForm(this.idPrefix);

    }
}