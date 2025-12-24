
namespace Indotalent.Settings {

    @Serenity.Decorators.registerClass()
    export class CountryGrid extends Serenity.EntityGrid<CountryRow, any> {
        protected getColumnsKey() { return CountryColumns.columnsKey; }
        protected getDialogType() { return CountryDialog; }
        protected getIdProperty() { return CountryRow.idProperty; }
        protected getInsertPermission() { return CountryRow.insertPermission; }
        protected getLocalTextPrefix() { return CountryRow.localTextPrefix; }
        protected getService() { return CountryService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}