
namespace Indotalent.Reminder {

    @Serenity.Decorators.registerClass()
    export class SmtpConfigurationDialog extends Serenity.EntityDialog<SmtpConfigurationRow, any> {
        protected getFormKey() { return SmtpConfigurationForm.formKey; }
        protected getIdProperty() { return SmtpConfigurationRow.idProperty; }
        protected getLocalTextPrefix() { return SmtpConfigurationRow.localTextPrefix; }
        protected getNameProperty() { return SmtpConfigurationRow.nameProperty; }
        protected getService() { return SmtpConfigurationService.baseUrl; }
        protected getDeletePermission() { return SmtpConfigurationRow.deletePermission; }
        protected getInsertPermission() { return SmtpConfigurationRow.insertPermission; }
        protected getUpdatePermission() { return SmtpConfigurationRow.updatePermission; }

        protected form = new SmtpConfigurationForm(this.idPrefix);

    }
}