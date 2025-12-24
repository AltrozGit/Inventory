
namespace Indotalent.Reminder {

    @Serenity.Decorators.registerClass()
    export class WhatsAppDialog extends Serenity.EntityDialog<WhatsAppRow, any> {
        protected getFormKey() { return WhatsAppForm.formKey; }
        protected getIdProperty() { return WhatsAppRow.idProperty; }
        protected getLocalTextPrefix() { return WhatsAppRow.localTextPrefix; }
        protected getNameProperty() { return WhatsAppRow.nameProperty; }
        protected getService() { return WhatsAppService.baseUrl; }
        protected getDeletePermission() { return WhatsAppRow.deletePermission; }
        protected getInsertPermission() { return WhatsAppRow.insertPermission; }
        protected getUpdatePermission() { return WhatsAppRow.updatePermission; }

        protected form = new WhatsAppForm(this.idPrefix);

    }
}