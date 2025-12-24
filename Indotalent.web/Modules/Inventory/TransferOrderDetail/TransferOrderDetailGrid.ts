
namespace Indotalent.Inventory {

    @Serenity.Decorators.registerClass()
    export class TransferOrderDetailGrid extends Serenity.EntityGrid<TransferOrderDetailRow, any> {
        protected getColumnsKey() { return TransferOrderDetailColumns.columnsKey; }
        protected getDialogType() { return TransferOrderDetailDialog; }
        protected getIdProperty() { return TransferOrderDetailRow.idProperty; }
        protected getInsertPermission() { return TransferOrderDetailRow.insertPermission; }
        protected getLocalTextPrefix() { return TransferOrderDetailRow.localTextPrefix; }
        protected getService() { return TransferOrderDetailService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}