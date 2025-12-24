
namespace Indotalent.General {

    @Serenity.Decorators.registerClass()
    export class ActionGrid extends Serenity.EntityGrid<ActionRow, any> {
        protected getColumnsKey() { return ActionColumns.columnsKey; }
        protected getDialogType() { return ActionDialog; }
        protected getIdProperty() { return ActionRow.idProperty; }
        protected getInsertPermission() { return ActionRow.insertPermission; }
        protected getLocalTextPrefix() { return ActionRow.localTextPrefix; }
        protected getService() { return ActionService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}