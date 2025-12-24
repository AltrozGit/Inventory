
namespace Indotalent.Purchase {

    @Serenity.Decorators.registerClass()
    export class PurchaseReceiptDetailGrid extends Serenity.EntityGrid<PurchaseReceiptDetailRow, any> {
        protected getColumnsKey() { return PurchaseReceiptDetailColumns.columnsKey; }
        protected getDialogType() { return PurchaseReceiptDetailDialog; }
        protected getIdProperty() { return PurchaseReceiptDetailRow.idProperty; }
        protected getInsertPermission() { return PurchaseReceiptDetailRow.insertPermission; }
        protected getLocalTextPrefix() { return PurchaseReceiptDetailRow.localTextPrefix; }
        protected getService() { return PurchaseReceiptDetailService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}