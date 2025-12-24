
namespace Indotalent.Purchase {

    @Serenity.Decorators.registerClass()

    export class VendorDialog extends Serenity.EntityDialog<VendorRow, any> {
        protected getFormKey() { return VendorForm.formKey; }
        protected getIdProperty() { return VendorRow.idProperty; }
        protected getLocalTextPrefix() { return VendorRow.localTextPrefix; }
        protected getNameProperty() { return VendorRow.nameProperty; }
        protected getService() { return VendorService.baseUrl; }
        protected getDeletePermission() { return VendorRow.deletePermission; }
        protected getInsertPermission() { return VendorRow.insertPermission; }
        protected getUpdatePermission() { return VendorRow.updatePermission; }

        protected form = new VendorForm(this.idPrefix);
        private loadedState: string;


        constructor() {
            super();

            Indotalent.DialogUtils.pendingChangesConfirmation(this.element, () => this.getSaveState() != this.loadedState);


        }

       /* protected getToolbarButtons(): Serenity.ToolButton[] {
            let buttons = super.getToolbarButtons();

            // Add a custom button to send a WhatsApp message
            buttons.push({
                title: 'Send WhatsApp Message',
                cssClass: 'send-whatsapp-button',
                onClick: () => {
                    this.myAction(),
                        Q.notifySuccess('Message sent successfully!');

                }

            });

            return buttons;

        }
        private myAction() {
            VendorService.SendWhatsAppMessage(
                {
                    VendorId: this.get_entityId(),
                },
                response => { Q.notifySuccess("Success! ", '', null) });
        }
        */

        protected getToolbarButtons() {
            let buttons = super.getToolbarButtons();

            buttons.push({
                title: 'Send WhatsApp Message',
                cssClass: 'send-message-button',
                onClick: () => this.sendWhatsAppMessage()
            });

            return buttons;
        }

        private sendWhatsAppMessage() {
            let vendorId = this.entity.Id; // Assuming VendorId is part of the entity
            if (!vendorId) {
                Q.alert('Please save the vendor details before sending a message.');
                return;
            }

            Q.serviceRequest('Purchase/Vendor/SendWhatsAppMessage', {
                VendorId: vendorId,
                //url: Q.resolveUrl('~/Purchase/Vendor/SendWhatsAppMessage'),
                //service: 'Vendor/SendWhatsAppMessage',
                //request: { VendorId: vendorId },
                onSuccess: response => {

                    Q.notifySuccess('Message sent successfully.');
                },
                onError: error => {

                    Q.alert('Failed to send message: ' + error);
                }

            });
        }


        
        getSaveState()
        {
            try
            {
                return $.toJSON(this.getSaveEntity());
            }
            catch (e)
            {
                return null;
            }
        }

        loadResponse(data)
        {
            super.loadResponse(data);
            this.loadedState = this.getSaveState();
        }

    }
       
}