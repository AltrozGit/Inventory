
namespace Indotalent.Sales {

    @Serenity.Decorators.registerClass()
    export class SalesDeliveryDetailGrid extends Serenity.EntityGrid<SalesDeliveryDetailRow, any> {
        protected getColumnsKey() { return SalesDeliveryDetailColumns.columnsKey; }
        protected getDialogType() { return SalesDeliveryDetailDialog; }
        protected getIdProperty() { return SalesDeliveryDetailRow.idProperty; }
        protected getInsertPermission() { return SalesDeliveryDetailRow.insertPermission; }
        protected getLocalTextPrefix() { return SalesDeliveryDetailRow.localTextPrefix; }
        protected getService() { return SalesDeliveryDetailService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}