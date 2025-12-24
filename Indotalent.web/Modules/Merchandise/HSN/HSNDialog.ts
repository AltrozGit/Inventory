
namespace Indotalent.Merchandise {

    @Serenity.Decorators.registerClass()
    export class HSNDialog extends Serenity.EntityDialog<HSNRow, any> {
        protected getFormKey() { return HSNForm.formKey; }
        protected getIdProperty() { return HSNRow.idProperty; }
        protected getLocalTextPrefix() { return HSNRow.localTextPrefix; }
        protected getNameProperty() { return HSNRow.nameProperty; }
        protected getService() { return HSNService.baseUrl; }
        protected getDeletePermission() { return HSNRow.deletePermission; }
        protected getInsertPermission() { return HSNRow.insertPermission; }
        protected getUpdatePermission() { return HSNRow.updatePermission; }

        protected form = new HSNForm(this.idPrefix);

    }
}