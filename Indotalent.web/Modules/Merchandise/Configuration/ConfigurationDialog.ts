
namespace Indotalent.Merchandise {

    @Serenity.Decorators.registerClass()
    export class ConfigurationDialog extends Serenity.EntityDialog<ConfigurationRow, any> {
        protected getFormKey() { return ConfigurationForm.formKey; }
        protected getIdProperty() { return ConfigurationRow.idProperty; }
        protected getLocalTextPrefix() { return ConfigurationRow.localTextPrefix; }
        protected getNameProperty() { return ConfigurationRow.nameProperty; }
        protected getService() { return ConfigurationService.baseUrl; }
        protected getDeletePermission() { return ConfigurationRow.deletePermission; }
        protected getInsertPermission() { return ConfigurationRow.insertPermission; }
        protected getUpdatePermission() { return ConfigurationRow.updatePermission; }

        protected form = new ConfigurationForm(this.idPrefix);

    }
}