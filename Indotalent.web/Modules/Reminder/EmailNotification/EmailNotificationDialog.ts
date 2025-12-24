
namespace Indotalent.Reminder {

    @Serenity.Decorators.registerClass()
    export class EmailNotificationDialog extends Serenity.EntityDialog<EmailNotificationRow, any> {
      //  protected getFormKey() { return EmailNotificationForm.formKey; }
        protected getIdProperty() { return EmailNotificationRow.idProperty; }
        protected getLocalTextPrefix() { return EmailNotificationRow.localTextPrefix; }
        protected getNameProperty() { return EmailNotificationRow.nameProperty; }
        protected getService() { return EmailNotificationService.baseUrl; }
        protected getDeletePermission() { return EmailNotificationRow.deletePermission; }
        protected getInsertPermission() { return EmailNotificationRow.insertPermission; }
        protected getUpdatePermission() { return EmailNotificationRow.updatePermission; }

       // protected form = new EmailNotificationForm(this.idPrefix);
        private pdfFilePath: string;
        constructor() {
            super();
          
        }
        public loadEntityAndOpenDialog(data: any) {
            super.loadEntityAndOpenDialog(data);

            // Check if PdfFilePath is provided and render it in the dialog
            if (data.PdfFilePath) {
                this.pdfFilePath = data.PdfFilePath;
                this.renderPdf();
            }
        }
        private renderPdf(): void {
            // Render the PDF in an iframe or object tag
            if (this.pdfFilePath) {
                // Create an iframe or object to display the PDF
                let pdfViewer = `<iframe src="${this.pdfFilePath}" width="100%" height="600px"></iframe>`;

                // Append the PDF viewer to the dialog
                this.element.find('.s-DialogContent').append(pdfViewer);
            }
        }
        protected afterLoadEntity() {
            super.afterLoadEntity();
            
           
        }
        protected updateInterface(): void {
            super.updateInterface();
            var saveButton = this.toolbar.findButton('save-button');
            saveButton.hide();

        }
        protected getToolbarButtons() {
            let buttons = super.getToolbarButtons();

            // Add the Send button
            buttons.push({
                title: 'Send',
                cssClass: 'send-button',  // You can style this button if needed
                icon: 'fa fa-envelope',  // Optional icon
                onClick: () => {
                    //this.sendEmail();
                }
            });

            return buttons;
        }

       
    }
}