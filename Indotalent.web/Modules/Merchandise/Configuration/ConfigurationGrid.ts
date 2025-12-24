
namespace Indotalent.Merchandise {

    @Serenity.Decorators.registerClass()
    export class ConfigurationGrid extends Serenity.EntityGrid<ConfigurationRow, any> {
        protected getColumnsKey() { return ConfigurationColumns.columnsKey; }
        protected getDialogType() { return ConfigurationDialog; }
        protected getIdProperty() { return ConfigurationRow.idProperty; }
        protected getInsertPermission() { return ConfigurationRow.insertPermission; }
        protected getLocalTextPrefix() { return ConfigurationRow.localTextPrefix; }
        protected getService() { return ConfigurationService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}