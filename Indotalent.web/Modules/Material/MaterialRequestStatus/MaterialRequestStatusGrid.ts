
namespace Indotalent.Material {

    @Serenity.Decorators.registerClass()
    export class MaterialRequestStatusGrid extends Serenity.EntityGrid<MaterialRequestStatusRow, any> {
        protected getColumnsKey() { return MaterialRequestStatusColumns.columnsKey; }
        protected getDialogType() { return MaterialRequestStatusDialog; }
        protected getIdProperty() { return MaterialRequestStatusRow.idProperty; }
        protected getInsertPermission() { return MaterialRequestStatusRow.insertPermission; }
        protected getLocalTextPrefix() { return MaterialRequestStatusRow.localTextPrefix; }
        protected getService() { return MaterialRequestStatusService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}