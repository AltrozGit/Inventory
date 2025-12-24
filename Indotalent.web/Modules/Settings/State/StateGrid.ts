
namespace Indotalent.Settings {

    @Serenity.Decorators.registerClass()
    export class StateGrid extends Serenity.EntityGrid<StateRow, any> {
        protected getColumnsKey() { return StateColumns.columnsKey; }
        protected getDialogType() { return StateDialog; }
        protected getIdProperty() { return StateRow.idProperty; }
        protected getInsertPermission() { return StateRow.insertPermission; }
        protected getLocalTextPrefix() { return StateRow.localTextPrefix; }
        protected getService() { return StateService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}