
namespace Indotalent.Projects {

    @Serenity.Decorators.registerClass()
    export class ExpenseGrid extends Serenity.EntityGrid<ExpenseRow, any> {
        protected getColumnsKey() { return ExpenseColumns.columnsKey; }
        protected getDialogType() { return ExpenseDialog; }
        protected getIdProperty() { return ExpenseRow.idProperty; }
        protected getInsertPermission() { return ExpenseRow.insertPermission; }
        protected getLocalTextPrefix() { return ExpenseRow.localTextPrefix; }
        protected getService() { return ExpenseService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}