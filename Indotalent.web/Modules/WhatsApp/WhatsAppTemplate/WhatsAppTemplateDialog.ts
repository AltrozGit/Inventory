
namespace Indotalent.WhatsApp {

    @Serenity.Decorators.registerClass()
    export class WhatsAppTemplateDialog extends Serenity.EntityDialog<WhatsAppTemplateRow, any> {
        protected getFormKey() { return WhatsAppTemplateForm.formKey; }
        protected getIdProperty() { return WhatsAppTemplateRow.idProperty; }
        protected getLocalTextPrefix() { return WhatsAppTemplateRow.localTextPrefix; }
        protected getNameProperty() { return WhatsAppTemplateRow.nameProperty; }
        protected getService() { return WhatsAppTemplateService.baseUrl; }
        protected getDeletePermission() { return WhatsAppTemplateRow.deletePermission; }
        protected getInsertPermission() { return WhatsAppTemplateRow.insertPermission; }
        protected getUpdatePermission() { return WhatsAppTemplateRow.updatePermission; }

        protected form = new WhatsAppTemplateForm(this.idPrefix);


        constructor() {
            super();

            Indotalent.DialogUtils.pendingChangesConfirmation(this.element, () => this.getSaveState() != this.loadedState);


        }

        protected getToolbarButtons() {
            let buttons = super.getToolbarButtons();

            buttons.push({
                title: 'Send WhatsApp Message',
                cssClass: 'send-message-button',
                onClick: () => this.sendWhatsAppMessage()
               
            });

            buttons.push({
                title: 'Send Bulk Message',
                cssClass: 'send-message-button',
                onClick: () => this.sendBulkWhatsAppMessage()

            });

            return buttons;          
        }

        private sendWhatsAppMessage() {

            let vendorId = this.entity.Id; // Assuming VendorId is part of the entity
            if (!vendorId) {
                Q.alert('Please save the vendor details before sending a message.');
                return;
            }

            Q.serviceRequest('WhatsApp/WhatsAppTemplate/SendWhatsAppMessage', {
                VendorId: vendorId,
                onSuccess: response => {

                    Q.notifySuccess('Message sent successfully.');
                },
                onError: error => {

                    Q.alert('Failed to send message: ' + error);
                }
            });

        }

        private sendBulkWhatsAppMessage() {

            let vendorId = this.entity.Id; // Assuming VendorId is part of the entity
            if (!vendorId) {
                Q.alert('Please save the vendor details before sending a message.');
                return;
            }

           Q.serviceRequest('WhatsApp/WhatsAppTemplate/BulkMessages', {
                VendorId: vendorId,
                onSuccess: response => {

                    Q.notifySuccess('Message sent successfully.');
                },
                onError: error => {

                    Q.alert('Failed to send message: ' + error);
                }
            });
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