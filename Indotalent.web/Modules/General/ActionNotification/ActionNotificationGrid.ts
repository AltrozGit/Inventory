
namespace Indotalent.General {

    @Serenity.Decorators.registerClass()
    export class ActionNotificationGrid extends Serenity.EntityGrid<ActionNotificationRow, any> {
        protected getColumnsKey() { return ActionNotificationColumns.columnsKey; }
        protected getDialogType() { return ActionNotificationDialog; }
        protected getIdProperty() { return ActionNotificationRow.idProperty; }
        protected getInsertPermission() { return ActionNotificationRow.insertPermission; }
        protected getLocalTextPrefix() { return ActionNotificationRow.localTextPrefix; }
        protected getService() { return ActionNotificationService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}