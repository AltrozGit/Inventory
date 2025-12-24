
namespace Indotalent.Purchase {

    @Serenity.Decorators.registerClass()
    export class PurchaseReturnDetailGrid extends Serenity.EntityGrid<PurchaseReturnDetailRow, any> {
        protected getColumnsKey() { return PurchaseReturnDetailColumns.columnsKey; }
        protected getDialogType() { return PurchaseReturnDetailDialog; }
        protected getIdProperty() { return PurchaseReturnDetailRow.idProperty; }
        protected getInsertPermission() { return PurchaseReturnDetailRow.insertPermission; }
        protected getLocalTextPrefix() { return PurchaseReturnDetailRow.localTextPrefix; }
        protected getService() { return PurchaseReturnDetailService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}