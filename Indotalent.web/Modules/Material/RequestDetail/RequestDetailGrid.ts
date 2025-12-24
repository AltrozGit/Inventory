
namespace Indotalent.Material {

    @Serenity.Decorators.registerClass()
    export class RequestDetailGrid extends Serenity.EntityGrid<RequestDetailRow, any> {
        protected getColumnsKey() { return RequestDetailColumns.columnsKey; }
        protected getDialogType() { return RequestDetailDialog; }
        protected getIdProperty() { return RequestDetailRow.idProperty; }
        protected getInsertPermission() { return RequestDetailRow.insertPermission; }
        protected getLocalTextPrefix() { return RequestDetailRow.localTextPrefix; }
        protected getService() { return RequestDetailService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }

    }
}