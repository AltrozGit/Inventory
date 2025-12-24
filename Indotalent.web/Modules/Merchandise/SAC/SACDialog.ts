
namespace Indotalent.Merchandise {

    @Serenity.Decorators.registerClass()
    export class SACDialog extends Serenity.EntityDialog<SACRow, any> {
        protected getFormKey() { return SACForm.formKey; }
        protected getIdProperty() { return SACRow.idProperty; }
        protected getLocalTextPrefix() { return SACRow.localTextPrefix; }
        protected getNameProperty() { return SACRow.nameProperty; }
        protected getService() { return SACService.baseUrl; }
        protected getDeletePermission() { return SACRow.deletePermission; }
        protected getInsertPermission() { return SACRow.insertPermission; }
        protected getUpdatePermission() { return SACRow.updatePermission; }

        protected form = new SACForm(this.idPrefix);

    }
}