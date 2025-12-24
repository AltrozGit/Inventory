
namespace Indotalent.Sales {

    @Serenity.Decorators.registerClass()
    export class SalesReturnDetailGrid extends Serenity.EntityGrid<SalesReturnDetailRow, any> {
        protected getColumnsKey() { return SalesReturnDetailColumns.columnsKey; }
        protected getDialogType() { return SalesReturnDetailDialog; }
        protected getIdProperty() { return SalesReturnDetailRow.idProperty; }
        protected getInsertPermission() { return SalesReturnDetailRow.insertPermission; }
        protected getLocalTextPrefix() { return SalesReturnDetailRow.localTextPrefix; }
        protected getService() { return SalesReturnDetailService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}